using System;
using System.Collections.Generic;

namespace WinFormsApp.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DueDate { get; set; }

    public int? StatusId { get; set; }

    public int? PriorityId { get; set; }

    public int? UserId { get; set; }

    public virtual TaskPriority? Priority { get; set; }

    public virtual TaskStatus? Status { get; set; }

    public virtual ICollection<TaskComment> TaskComments { get; set; } = new List<TaskComment>();

    public virtual User? User { get; set; }
}
