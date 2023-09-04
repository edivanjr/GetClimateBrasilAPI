CREATE TABLE [dbo].[AirportCodes]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Acronym] VARCHAR(50) NULL, 
    [Airport] VARCHAR(150) NULL, 
    [State] NCHAR(10) NULL, 
    [LinkAirportClimateLocal] VARCHAR(150) NULL, 
    [LinkAirportClimateBrasilAPI] VARCHAR(150) NULL
)
