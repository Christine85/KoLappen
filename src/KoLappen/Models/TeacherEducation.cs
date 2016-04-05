namespace KoLappen.Models
{
    public class TeacherEducation
    {
        public int TeacherEducactionId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherRoleId { get; set; }
        public TeacherRole TeacherRole { get; set; }
    }
}