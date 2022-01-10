using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompleteExample.Entities
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }
        public decimal Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }

    }
}
