CREATE TABLE [dbo].[LocalizationLanguage] (
    [LocalizationKey]      VARCHAR (500)  NOT NULL,
    [LocalizationLanguage] VARCHAR (10)   NOT NULL,
    [LocalizationValue]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_LocalizationLanguage_1] PRIMARY KEY CLUSTERED ([LocalizationKey] ASC, [LocalizationLanguage] ASC)
);

