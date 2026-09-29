using System;
using System.Collections.Generic;
using System.Text;

namespace TodoAppKozmos.Core.Models
{
    public class Todo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
