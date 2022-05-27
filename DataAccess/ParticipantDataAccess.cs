using ProjectCRUD.Helpers;
using ProjectCRUD.Models;
using System.Data.SqlClient;

namespace ProjectCRUD.DataAccess
{
    public class ParticipantDataAccess
    {

        public string ErrorMessage { get; private set; }
        public List<ParticipantDataModel> GetAll()
        {
            try
            {
                ErrorMessage = "";
                List<ParticipantDataModel> participants = new List<ParticipantDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = "Select ParticipantId , ParticipantName, Gender, DOB,MobileNumber,Address,City,State,Pincode from Participant order by ParticipantId asc";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ParticipantDataModel participant = new ParticipantDataModel();

                                participant.Id = reader.GetInt32(0);
                                participant.ParticipantName = reader.GetString(1);
                                participant.Gender = reader.GetString(2);
                                participant.DOB = reader.GetDateTime(3);
                                participant.MobileNumber = reader.GetString(4);
                                participant.Address = reader.GetString(5);
                                participant.City = reader.GetString(6);
                                participant.State= reader.GetString(7);
                                participant.Pincode= reader.GetString(8);



                                participants.Add(participant);
                            }
                        }
                    }
                }
                return participants;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }






        public ParticipantDataModel GetEmployeeById(int id)

        {
            try
            {

                ErrorMessage = "";

                ParticipantDataModel participant = null;

                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select ParticipantId, ParticipantName,Gender,DOB,MobileNumber,Address,City,State,Pincode from Participant where ParticipantId={id}";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                participant = new ParticipantDataModel();
                                participant.Id = reader.GetInt32(0);
                                participant.ParticipantName = reader.GetString(1);
                                participant.Gender = reader.GetString(2);
                                participant.DOB = reader.GetDateTime(3);
                                participant.MobileNumber = reader.GetString(4);
                                participant.Address = reader.GetString(5);
                                participant.City = reader.GetString(6);
                                participant.State = reader.GetString(7);
                                participant.Pincode = reader.GetString(8);



                            }
                        }
                    }
                }
                return participant;

            }
            catch (Exception ex)
            {

                ErrorMessage = ex.Message;
                return null;
            }
        }







        public List<ParticipantDataModel> GetEmployeeByName(string name)
        {
            try
            {
                ErrorMessage = "";

                ParticipantDataModel participant = null;
                List<ParticipantDataModel> Participants = new List<ParticipantDataModel>();
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Select ParticipantId, ParticipantName,Gender,DOB,MobileNumber,Address,City,State,Pincode from  Participant where name like '%{name}%'";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                participant = new ParticipantDataModel();
                                participant.Id = reader.GetInt32(0);
                                participant.ParticipantName = reader.GetString(1);
                                participant.Gender = reader.GetString(2);
                                participant.DOB = reader.GetDateTime(3);
                                participant.MobileNumber = reader.GetString(4);
                                participant.Address = reader.GetString(5);
                                participant.City = reader.GetString(6);
                                participant.State = reader.GetString(7);
                                participant.Pincode = reader.GetString(8);
                                
                                
                                Participants.Add(participant);


                            }
                        }
                    }
                }
                return Participants;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                return null;
            }
        }



        public ParticipantDataModel Insert(ParticipantDataModel newParticipant)
        {
            try
            {
                ErrorMessage = "";



                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"Insert into Participant( ParticipantName,Gender,DOB,MobileNumber,Address,City,state,Pincode) values ('{newParticipant.ParticipantName}','{newParticipant.Gender}','{newParticipant.DOB.ToString("yyyy-MM-dd")}','{newParticipant.MobileNumber}','{newParticipant.Address}','{newParticipant.City}','{newParticipant.State}','{newParticipant.Pincode}'); select scope_identity();";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {
                        {
                            int numOfRows = Convert.ToInt32(cmd.ExecuteScalar());
                            if (numOfRows > 0)
                            {
                                newParticipant.Id = numOfRows;
                                return newParticipant;
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





        public ParticipantDataModel Update(ParticipantDataModel updParticipant)
        {
            try
            {
                ErrorMessage = "";


                ParticipantDataModel department = null;
                using (SqlConnection conn = Database.GetConnection())
                {
                    conn.Open();
                    var sqlStmt = $"update Participant set Name='{updParticipant.ParticipantName}',Gender='{updParticipant.Gender}',DOB='{updParticipant.DOB.ToString("yyyy-MM-dd")}',MobileNumber='{updParticipant.MobileNumber}',Address='{updParticipant.Address}',City='{updParticipant.City}',State='{updParticipant.State}',Pincode='{updParticipant.Pincode},Location='{updParticipant.Location}',Course='{updParticipant.Course}' where ParticipantId={updParticipant.Id} ";
                    using (SqlCommand cmd = new SqlCommand(sqlStmt, conn))
                    {



                        {
                            int numOfRows = cmd.ExecuteNonQuery();
                            if (numOfRows > 0)
                            {
                                return updParticipant;
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
                    string sqlStmt = $"DELETE FROM employee Where Id = {id}";

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

