using System;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;

namespace WpfApp1
{
    public partial class App : Application
    {
        private string masterConnectionString = @"Data Source=ASCOLTAT0;Integrated Security=True;MultipleActiveResultSets=True;";
        private string connectionString = ConfigurationManager.ConnectionStrings["Airport"].ConnectionString;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            EnsureDatabaseExists();
        }

        private void EnsureDatabaseExists()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                }
            }
            catch (SqlException)
            {
                CreateDatabase();
            }
        }

         private void CreateDatabase()
        {
            try
            {
                using (SqlConnection masterConnection = new SqlConnection(masterConnectionString + "Initial Catalog=master;"))
                {
                    masterConnection.Open();
                    using (SqlCommand command = masterConnection.CreateCommand())
                    {
                        command.CommandText = "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'Airport') CREATE DATABASE Airport;";
                        command.ExecuteNonQuery();
                    }
                }

                using (SqlConnection connection = new SqlConnection(masterConnectionString + "Initial Catalog=Airport;"))
                {
                    connection.Open();
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = @"
                            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PLANE')
                            BEGIN
                                CREATE TABLE PLANE(
	                                [ID] [int] NOT NULL PRIMARY KEY,
	                                [Type] [nvarchar](80) NULL,
	                                [Model] [nvarchar](80) NULL,
	                                [Capacity] [int] NULL,
	                                [Year] [int] NULL,
	                                [Load_Capacity] [nvarchar](80) NULL,
	                                [Maintenance_Date] [date] NULL);
                            END;

                            IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'CREW_MEMBERS')
                            BEGIN
                                CREATE TABLE CREW_MEMBERS(
	                                [ID] [int] NOT NULL PRIMARY KEY,
	                                [Name_Surname] [nvarchar](80) NOT NULL,
	                                [Position] [nvarchar](80) NOT NULL,
	                                [Age] [int] NOT NULL,
	                                [Experience] [int] NOT NULL,
                                    [Photo] VARBINARY(MAX) NULL,
	                                [Plane_ID] [int] NULL FOREIGN KEY REFERENCES PLANE(ID));
                            END;";

                        command.ExecuteNonQuery();

                        command.CommandText = @"
                        IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdatePlane')
                        BEGIN
                            EXEC sp_executesql N'
                                CREATE PROCEDURE UpdatePlane
                                @Id INT,
                                @Param NVARCHAR(50),
                                @Value NVARCHAR(MAX)
                                AS
                                BEGIN
                                    SET NOCOUNT ON;

                                    IF @Param = ''Type'' OR @Param = ''Model'' OR @Param = ''Load_Capacity'' OR @Param = ''Maintenance_Date''
                                    BEGIN
                                        IF @Param = ''Maintenance_Date''
                                        BEGIN
                                            DECLARE @SqlUpdate3 NVARCHAR(MAX);
                                            SET @SqlUpdate3 = ''UPDATE PLANE SET '' + QUOTENAME(@Param) + '' = CAST(@Value AS DATETIME) WHERE ID = @Id;'';
                                            EXEC sp_executesql @SqlUpdate3, N''@Value NVARCHAR(MAX), @Id INT'', @Value, @Id;
                                        END
                                        ELSE
                                        BEGIN
                                            DECLARE @SqlUpdate1 NVARCHAR(MAX);
                                            SET @SqlUpdate1 = ''UPDATE PLANE SET '' + QUOTENAME(@Param) + '' = @Value WHERE ID = @Id;'';
                                            EXEC sp_executesql @SqlUpdate1, N''@Value NVARCHAR(MAX), @Id INT'', @Value, @Id;
                                        END
                                    END
                                    ELSE IF @Param = ''Capacity'' OR @Param = ''Year''
                                    BEGIN
                                        DECLARE @SqlUpdate2 NVARCHAR(MAX);
                                        SET @SqlUpdate2 = ''UPDATE PLANE SET '' + QUOTENAME(@Param) + '' = CAST(@Value AS INT) WHERE ID = @Id;'';
                                        EXEC sp_executesql @SqlUpdate2, N''@Value NVARCHAR(MAX), @Id INT'', @Value, @Id;
                                    END
                                    ELSE
                                    BEGIN
                                        RAISERROR(''Неверный параметр'', 16, 1);
                                    END
                                END';
                        END;";

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("База данных и таблицы успешно созданы.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании базы данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}