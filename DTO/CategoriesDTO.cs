using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoriesDTO
    {
        public int CategoryId { get; set; }

        public int UserCode { get; set; }

        public string CategoryName { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string userName { get; set; } = null!;
        public int TasksCount { get; set; }
    }
}
