CREATE TABLE [dbo].[CityClimate] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [city_name]  VARCHAR (100)    NULL,
    [state]      VARCHAR (50)     NULL,
    [updated_at] DATETIME         NULL,
    [climate_id] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK1_ClimateId_ClimateArrayId] FOREIGN KEY ([climate_id]) REFERENCES [dbo].[CityClimateArray] ([Id])
);


