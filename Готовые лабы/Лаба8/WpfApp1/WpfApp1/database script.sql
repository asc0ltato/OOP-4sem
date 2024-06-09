use master
CREATE DATABASE Airport
use Airport;

CREATE TABLE PLANE(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Type] [nvarchar](80) NULL,
	[Model] [nvarchar](80) NULL,
	[Capacity] [int] NULL,
	[Year] [int] NULL,
	[Load_Capacity] [nvarchar](80) NULL,
	[Maintenance_Date] [date] NULL);

CREATE TABLE CREW_MEMBERS(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Name_Surname] [nvarchar](80) NOT NULL,
	[Position] [nvarchar](80) NOT NULL,
	[Age] [int] NOT NULL,
	[Experience] [int] NOT NULL,
	[Photo] VARBINARY(MAX) NULL,
	[Plane_ID] [int] NULL FOREIGN KEY REFERENCES PLANE(ID));

CREATE PROCEDURE UpdatePlane
    @Id INT,
    @Param NVARCHAR(50),
    @Value NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Param = 'Type' OR @Param = 'Model' OR @Param = 'Load_Capacity' OR @Param = 'Maintenance_Date'
    BEGIN
        IF @Param = 'Maintenance_Date'
        BEGIN
            DECLARE @SqlUpdate3 NVARCHAR(MAX);
            SET @SqlUpdate3 = 'UPDATE PLANE SET ' + QUOTENAME(@Param) + ' = CAST(@Value AS DATETIME) WHERE ID = @Id;';
            EXEC sp_executesql @SqlUpdate3, N'@Value NVARCHAR(MAX), @Id INT', @Value, @Id;
        END
        ELSE
        BEGIN
            DECLARE @SqlUpdate1 NVARCHAR(MAX);
            SET @SqlUpdate1 = 'UPDATE PLANE SET ' + QUOTENAME(@Param) + ' = @Value WHERE ID = @Id;';
            EXEC sp_executesql @SqlUpdate1, N'@Value NVARCHAR(MAX), @Id INT', @Value, @Id;
        END
    END
    ELSE IF @Param = 'Capacity' OR @Param = 'Year'
    BEGIN
        DECLARE @SqlUpdate2 NVARCHAR(MAX);
        SET @SqlUpdate2 = 'UPDATE PLANE SET ' + QUOTENAME(@Param) + ' = CAST(@Value AS INT) WHERE ID = @Id;';
        EXEC sp_executesql @SqlUpdate2, N'@Value NVARCHAR(MAX), @Id INT', @Value, @Id;
    END
    ELSE
    BEGIN
        RAISERROR('Неверный параметр', 16, 1);
    END
END



drop procedure UpdatePlane;
drop table PLANE;
drop table CREW_MEMBERS;

select * from CREW_MEMBERS;
select * from PLANE;