CREATE PROCEDURE dbo.GetResponses
AS
BEGIN
    SELECT Question.Text AS qtext,
           QuestionId AS qid
    INTO #Questions
    FROM dbo.Question
    WHERE QuestionId IN
          (
              SELECT Question FROM dbo.Response
          );

    SELECT *
    FROM #Questions
        JOIN dbo.Response
            ON qid = Question;

    IF OBJECT_ID('tempdb..#Questions') IS NOT NULL
    BEGIN
        DROP TABLE #Questions;
    END;
END;