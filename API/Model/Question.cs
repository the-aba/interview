using System;
using System.Collections.Generic;

namespace InterviewMinuteAPI.Model;

public partial class Question
{
    public long QuestionId { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
}
