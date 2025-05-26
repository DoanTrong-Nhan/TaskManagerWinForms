using System;
using System.Collections.Generic;

namespace WinFormsApp.Models;

public partial class TaskStatus
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
