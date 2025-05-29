using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.Dtos
{
    public class TaskDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }

/*        public string? StartDateStr => StartDate?.ToString("dd/MM/yyyy");
        public string? DueDateStr => DueDate?.ToString("dd/MM/yyyy");
*/
        public string? PriorityName { get; set; }
        public string? StatusName { get; set; }
        public string? UserFullName { get; set; }
    }



}
