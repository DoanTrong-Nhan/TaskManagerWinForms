using System;
using System.Collections.Generic;

namespace WinFormsApp.Models;

public partial class TaskComment
{
    public int CommentId { get; set; }

    public int? TaskId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CommentDate { get; set; }

    public virtual Task? Task { get; set; }
}
