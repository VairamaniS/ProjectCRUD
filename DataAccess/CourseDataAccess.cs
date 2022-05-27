using System.Data.SqlClient;
using ProjectCRUD.Helpers;
using ProjectCRUD.Models;


namespace ProjectCRUD.DataAccess
{
    public class CourseDataAccess
    {


        public string ErrorMessage { get; set; }
        public List<CourseDataModel> GetAll()
        {
            try
            {
                ErrorMessage = "";
                List<CourseDataModel> courses = new List<CourseDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select CourseId, CourseName,CourseMaterial from Course order by CourseName";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CourseDataModel course = new CourseDataModel();

                                course.CourseId = reader.GetInt32(0);
                                course.CourseName = reader.GetString(1);
                                course.CourseMaterial = reader.GetString(2);
                                


                                courses.Add(course);
                            }
                        }
                    }
                }
                return courses;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }
        public CourseDataModel GetDepartmentById(int id)

        {
            try
            {

                ErrorMessage = "";

                CourseDataModel course = null;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select CourseId, CourseName, CourseMaterial, Duration from  Course where CourseId ={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                course = new CourseDataModel();
                                course.CourseId = reader.GetInt32(0);
                                course.CourseName = reader.GetString(1);
                                course.CourseMaterial = reader.GetString(2);
                                course.Duration= reader.GetString(3);


                            }
                        }
                    }
                }
                return course;

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return null;
            }
        }







        public List<CourseDataModel> GetDepartmentByName(string name)
        {
            try
            {
                ErrorMessage = "";

                CourseDataModel course = null;
                List<CourseDataModel> courses = new List<CourseDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select CourseId, CourseName,CourseMaterial,Duration from  Course where CourseName like '%{name}%'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                course = new CourseDataModel();
                                course.CourseId = reader.GetInt32(0);
                                course.CourseName = reader.GetString(1);
                                course.CourseMaterial = reader.GetString(2);
                                course.Duration = reader.GetString(3);
                                courses.Add(course);


                            }
                        }
                    }
                }
                return courses;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }



        public CourseDataModel Insert(CourseDataModel newDepartment)
        {
            try
            {
                ErrorMessage = "";



                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Insert into Course ( CourseName,CourseMaterial,Duration) values ('{newDepartment.CourseName}', '{newDepartment.CourseMaterial}','{newDepartment.Duration}'); select scope_identity()";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        {
                            int numOfRows = Convert.ToInt32(cmd.ExecuteScalar());
                            if (numOfRows > 0)
                            {
                                newDepartment.CourseId = numOfRows;
                                return newDepartment;
                            }


                        }

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }





        public CourseDataModel update(CourseDataModel updcourses)
        {
            try
            {
                ErrorMessage = "";


                CourseDataModel course = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"update Course set CourseName='{updcourses.CourseName}', CourseMaterial='{updcourses.CourseMaterial}' where CourseId={updcourses.CourseId} ";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {



                        {
                            int numOfRows = cmd.ExecuteNonQuery();
                            if (numOfRows > 0)
                            {
                                return updcourses;
                            }



                        }

                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }


        public int Delete(int id)
        {
            try
            {
                ErrorMessage = "";


                int numOfRows = 0;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    string sqlStmt = $"DELETE FROM Department Where Id = {id}";

                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        numOfRows = cmd.ExecuteNonQuery();
                    }
                }
                return numOfRows;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return 0;
            }






        }
    }


}

