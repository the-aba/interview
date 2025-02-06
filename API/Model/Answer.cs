using System;
using System.Collections.Generic;

namespace InterviewMinuteAPI.Model;

public partial class Answer
{
    public long AnswerId { get; set; }

    public long QuestionId { get; set; }

    public string? Text { get; set; }

    public byte? DisplayOrder { get; set; }

    public virtual Question Question { get; set; } = null!;
}
