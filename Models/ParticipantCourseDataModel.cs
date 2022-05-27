namespace ProjectCRUD.Models
{
    public class ParticipantCourseDataModel
    {
        public int ParticipantId { get; set; }
        public int Id { get; internal set; }
        public int CourseId { get; internal set; }
        public string ParticipantName { get; internal set; }
        public string CourseName { get; internal set; }
        public DateTime StartDate { get; internal set; }
        public DateTime? CompletionDate { get; internal set; }
        
        public string? Grade { get; internal set; }

        public ParticipantCourseDataModel()
        {
            
            Id = 0;
            ParticipantName = "";
            CourseName = "";
            StartDate = DateTime.Now;
            CompletionDate = DateTime.Now;
            Grade = "";


        }

       
    }
}

