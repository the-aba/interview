CREATE TABLE [dbo].[Answer] (
    [AnswerId]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [QuestionId]   BIGINT         NOT NULL,
    [Text]         NVARCHAR (150) NULL,
    [DisplayOrder] TINYINT        NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([AnswerId] ASC),
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId]) REFERENCES [dbo].[Question] ([QuestionId])
);

