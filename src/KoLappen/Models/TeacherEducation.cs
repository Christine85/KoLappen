namespace KoLappen.Models
{
    public class TeacherEducation
    {
        public int TeacherEducactionId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int EducationId { get; set; }
        public Education Education { get; set; }
    }
}