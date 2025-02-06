CREATE PROCEDURE dbo.InsertResponse
    @ResponseTime DATETIME,
    @Answer BIGINT,
    @Question BIGINT
AS
BEGIN
    DECLARE @AnswerForResponse NVARCHAR(MAX);
    SELECT @AnswerForResponse = Text
    FROM dbo.Answer
    WHERE @Answer = AnswerId
          AND @Question = QuestionId;

    INSERT INTO dbo.Response
    (
        Question,
        Answer,
        WhenDidTheResponseHappenAt
    )
    VALUES
    (   @Question,          -- Question - bigint
        @AnswerForResponse, -- Answer - nvarchar(150)
        @ResponseTime       -- WhenDidTheResponseHappenAt - datetime
        );
END;