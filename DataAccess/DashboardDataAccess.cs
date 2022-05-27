using System.Data.SqlClient;
using ProjectCRUD.Helpers;
using ProjectCRUD.Pages.Models;

namespace ProjectCRUD.Pages.DataAccess
{
    public class DashboardDataAccess
    {

        public string ErrorMessage { get; set; }

        public DashboardDataAccess()
        {
            ErrorMessage = "";
        }

        public DashboardDataModel GetAll()
        {
            try
            {

                var db = new DashboardDataModel();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "select count(*) as ParticipantId from Participant; select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))

                    {
                        db.ParticipantCount = Convert.ToInt32(cmd.ExecuteScalar());


                    }
                   
                    sqlStmt = "select count(*) as TrainingCount from StudentCourse";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.TrainingCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    sqlStmt = "select count(*) as CompletedTrainingCount from Course";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        db.CourseCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                }





                return db;


            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





    }
}
