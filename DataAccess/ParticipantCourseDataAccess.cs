using System.Data.SqlClient;
using ProjectCRUD.Helpers;
using ProjectCRUD.Models;

namespace ProjectCRUD.Pages.DataAccess
{
    public class ParticipantCourseDataAccess
    {



        public string ErrorMessage { get; set; }

        public ParticipantCourseDataAccess()
        {
            ErrorMessage = "";
        }

        public List<ParticipantCourseDataModel> GetAll()
        {
            try
            {
                ErrorMessage = string.Empty;
                List<ParticipantCourseDataModel> participantrecords = new List<ParticipantCourseDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "select a.participantid as ParticipantId ,c.participantname as ParticipantName ,b.coursename as CourseName,a.startdate as StartDate,a.completiondate as CompletionDate,a.grade as Grade " +
                                   "from dbo.studentcourse a inner join dbo.course b on a.courseid = b.courseid inner " +
                                   "join dbo.participant c on c.participantid = a.participantid ";














                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read() == true)
                            {
                                ParticipantCourseDataModel students = new ParticipantCourseDataModel();
                                students.ParticipantId = reader.GetInt32(0);
                                students.ParticipantName = reader.GetString(1);
                                students.CourseName = reader.GetString(2);
                                students.StartDate = reader.GetDateTime(3);
                                students.CompletionDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                                students.Grade = reader.IsDBNull(5) ? null : reader.GetString(5);
                                participantrecords.Add(students);






                            }
                        }
                    }
                }
                return participantrecords;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
        //get by id
        public ParticipantCourseDataModel GetById(int id)

        {
            try
            {

                ErrorMessage = "";
                ParticipantCourseDataModel student = null;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $" select a.participantid as ParticipantId ,c.participantname as ParticipantName ,b.coursename as CourseName,a.startdate as StartDate,a.completiondate as CompletionDate,a.grade as Grade " +
                                   "from dbo.studentcourse a inner join dbo.course b on a.courseid = b.courseid inner " +
                                   $"join dbo.participant c on c.participantid = a.participantid  where a.ParticipantId={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                student = new ParticipantCourseDataModel();
                                student.ParticipantId = reader.GetInt32(0);
                                student.ParticipantName = reader.GetString(1);
                                student.CourseName = reader.GetString(2);
                                student.StartDate = reader.GetDateTime(3);
                                student.CompletionDate = reader.IsDBNull(4) ? null : reader.GetDateTime(4);
                                student.Grade = reader.IsDBNull(5) ? null : reader.GetString(5);
                                



                            }
                        }
                    }
                }
                return student;

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return null;
            }
        }
        public bool Insert(int ParticipantId, int CourseId)
        {
            try
            {
                ErrorMessage = string.Empty;
                int idInserted = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"INSERT INTO dbo.StudentCourse (ParticipantId, CourseId) VALUES ({ParticipantId}, {CourseId}); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        idInserted = Convert.ToInt32(cmd.ExecuteScalar());
                        if (idInserted > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return false;
            }
        }

        public bool Update(int id, string grade)
        {
            try
            {
                ErrorMessage = "";
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"UPDATE dbo.StudentCourse SET Grade = '{grade}', " +
                        $"CompletionDate = GETDATE() " +
                        $"where ParticipantId = {id} " ;

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        int numOfRows = cmd.ExecuteNonQuery();
                        if (numOfRows > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return false;
        }



    }
}
