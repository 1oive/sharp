using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entity.Entities
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string Subject { get; set; }
        public int Score { get; set; }
        public DateOnly Date { get; set; }
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }
    }
}
