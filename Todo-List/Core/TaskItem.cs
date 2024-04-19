using System;
using System.ComponentModel.DataAnnotations;

namespace Todo_List.Core
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string TaskDescription { get; set; }
        public bool TaskStatus { get; set; }
        public DateTime? CompletionTime { get; set; } // Nullable DateTime to store completion time
    }
}