CREATE TABLE [dbo].[CityClimate] (
    [Id]         UNIQUEIDENTIFIER NOT NULL PRIMARY KEY ,
    [city_name]  VARCHAR (100)    NULL,
    [state]      VARCHAR (50)     NULL,
    [updated_at] DATETIME         NULL 
);


