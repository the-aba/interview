CREATE TABLE [dbo].[Question] (
    [QuestionId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [Text]       NVARCHAR (150) NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([QuestionId] ASC)
);

