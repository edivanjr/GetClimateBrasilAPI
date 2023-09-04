CREATE TABLE [dbo].[CityClimateArray]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [date] DATETIME NULL, 
    [condition] VARCHAR(50) NULL, 
    [condition_description] VARCHAR(50) NULL, 
    [min] INT NULL, 
    [max] INT NULL, 
    [uv_index] INT NULL,
    [ownerId] UNIQUEIDENTIFIER NOT NULL
)
