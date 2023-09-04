CREATE TABLE [dbo].[AirportClimate]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [moisture] INT NULL, 
    [visibility] VARCHAR(50) NULL, 
    [code_icao] NCHAR(10) NULL, 
    [atmospheric_pressure] INT NULL, 
    [wind] INT NULL, 
    [wind_direction] INT NULL, 
    [condition] VARCHAR(50) NULL, 
    [condition_description] VARCHAR(150) NULL,
    [temperature] INT NULL, 
    [updated_at] DATETIME NULL
)
