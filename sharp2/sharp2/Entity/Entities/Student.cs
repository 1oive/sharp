using System.ComponentModel.DataAnnotations;

namespace entity.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Grade>? Grades { get; set; }
    }
}
