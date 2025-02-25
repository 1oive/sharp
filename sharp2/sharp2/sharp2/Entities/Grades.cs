using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sharp2.Entities
{
    public class Grades
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
        public DateOnly Date { get; set; }
    }
}
