use master
CREATE DATABASE Airport
use Airport;

CREATE TABLE MANUFACTURER(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Name] [nvarchar](80) NOT NULL,
	[Country] [nvarchar](80) NOT NULL,
	[Year] [int] NULL);

CREATE TABLE PLANE(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Type] [nvarchar](80) NULL,
	[Model] [nvarchar](80) NULL,
	[Capacity] [int] NULL,
	[Year] [int] NULL,
	[Load_Capacity] [nvarchar](80) NULL,
	[Maintenance_Date] [date] NULL,
	[Manufacturer_ID] [int] NOT NULL FOREIGN KEY REFERENCES MANUFACTURER(ID));

CREATE TABLE CREW_MEMBERS(
	[ID] [int] NOT NULL PRIMARY KEY,
	[Name_Surname] [nvarchar](80) NOT NULL,
	[Position] [nvarchar](80) NOT NULL,
	[Age] [int] NOT NULL,
	[Experience] [int] NOT NULL,
	[Photo] VARBINARY(MAX) NULL,
	[Plane_ID] [int] NULL FOREIGN KEY REFERENCES PLANE(ID));

CREATE PROCEDURE UpdateManufacturer
    @Id INT,
    @Param VARCHAR(50),
    @Value VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Sql NVARCHAR(MAX);

    IF @Param = 'Name' OR @Param = 'Country'
    BEGIN
        SET @Sql = N'UPDATE MANUFACTURER SET ' + QUOTENAME(@Param) + ' = @Value WHERE ID = @Id';
        EXEC sp_executesql @Sql, N'@Id INT, @Value VARCHAR(100)', @Id, @Value;
    END
    ELSE IF @Param = 'Year'
    BEGIN
        SET @Sql = N'UPDATE MANUFACTURER SET ' + QUOTENAME(@Param) + ' = @Value WHERE ID = @Id';
        EXEC sp_executesql @Sql, N'@Id INT, @Value VARCHAR(100)', @Id, @Value;
    END
    ELSE
    BEGIN
        RAISERROR('Неверный параметр', 16, 1);
    END
END;

drop procedure UpdateManufacturer;

select * from CREW_MEMBERS;