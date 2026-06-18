using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TasksDTO
    {
        public int TaskId { get; set; }

        public int? CategoryId { get; set; }

        public string TaskDescription { get; set; } = null!;

        public DateOnly RegistrationDate { get; set; }

        public DateOnly FromDate { get; set; }

        public DateOnly ToDate { get; set; }

        public DateOnly DoneDate { get; set; }

        public string Notes { get; set; } = null!;

        public string CategoryName { get; set; } = null!;
        public string status { get; set; } = null!;
    }
}
