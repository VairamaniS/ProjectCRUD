namespace ProjectCRUD.Models
{
    public class ParticipantDataModel
    {
        public int ParticipantId { get; set; }
        public int Id { get; internal set; }
        public string ParticipantName { get; internal set; }
        
        public string Gender { get; internal set; }
        public DateTime DOB { get; internal set; }
        public string MobileNumber { get; internal set; }
        public string Address { get; internal set; }
        public string City { get; internal set; }
        public string State { get; internal set; }
        public string Pincode { get; internal set; }
        public string Location { get; internal set; }
        public  int Course { get; internal set; }

        public ParticipantDataModel()
        {

            ParticipantName = "";
            Gender = "male";
            DOB = DateTime.Now.AddYears(-20);
            MobileNumber = "";
            Address = "";
            City = "";
            State = "";
            Pincode = "";
            Location = "";
            Course = 0;
         
            
            


        }

        public bool IsValid()
        {
            //if (ParticipantId <= 0)
            //{
            //    return false;
            //}

            if (ParticipantName == null || ParticipantName.Trim().Length > 20 || ParticipantName.Trim() == "")
            {
                return false;
            }
            if (Gender == null || Gender.Trim().Length > 1 || Gender.Trim() == "")
            {
                return false;
            }
            if (DOB > DateTime.Now.AddYears(-20))
            {
                return false;
            }
            if (MobileNumber == null || MobileNumber.Trim().Length > 10 || MobileNumber.Trim() == "")
            {
                return false;
            }
            if (Address == null || Address.Trim().Length > 10 || Address.Trim() == "")
            {
                return false;
            }
            if (City == null || City.Trim().Length > 10 || City.Trim() == "")
            {
                return false;
            }
            if (State == null || State.Trim().Length > 10 || State.Trim() == "")
            {
                return false;
            }
            if (Pincode == null || Pincode.Trim().Length > 10 || Pincode.Trim() == "")
            {
                return false;
            }

            return true;




        }

    }
}

