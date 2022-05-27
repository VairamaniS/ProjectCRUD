using ProjectCRUD.DataAccess;
using ProjectCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ProjectCRUD.Pages.Participants
{ [Authorize(Roles="Admin")]
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "ParticipantName")]
        
        public string ParticipantName { get; set; }

    
        [BindProperty]
        [Display(Name = "Gender")]
       
        public string Gender { get; set; }

        

        [BindProperty]
        [Display(Name = "DOB")]
        
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [BindProperty]
        [Display(Name = "MobileNumber")]
        
        public string MobileNumber { get; set; }

        [BindProperty]
        [Display(Name = "Address")]
        
        public string Address { get; set; }
        [BindProperty]
        [Display(Name = "City")]
       
        public string City { get; set; }
        [BindProperty]
        [Display(Name = "State")]
        
        public string State { get; set; }

        [BindProperty]
        [Display(Name = "Pincode")]
        
        public string Pincode { get; set; }

        [BindProperty]
        [Display(Name = "Location")]
        
        public string Location { get; set; }

        [BindProperty]
        public List<SelectListItem> LocationsList { get; set; }

        [BindProperty]
        public List<SelectListItem> CourseList { get; set; }

        [BindProperty]
        public List<SelectListItem> Genders { get; set; }

        [BindProperty]
        [Display(Name = "Course")]
        public int SelectedCourse { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        


       // public EditModel()
        //{
        //    ParticipantName = "";
        //    Gender = "";
        //    DOB = DateTime.Now.AddYears(-20);
        //    Pincode = "";
        //    MobileNumber = "";
           
        //    Genders = GetGenders();

        //}

        


       

        private List<SelectListItem> GetGenders()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Male", Value = "M" });
            selectItems.Add(new SelectListItem { Text = "Female", Value = "F" });
            selectItems.Add(new SelectListItem { Text = "Unspecified", Value = "U" });

            return selectItems;
        }




        public void OnGet(int id)
        {
            Id = id;
            if (Id < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }
           
            Genders = GetGenders();


            var studentdata = new ParticipantDataAccess();
            var student = studentdata.GetEmployeeById(Id);
            if (student != null)
            {
               
                ParticipantName = student.ParticipantName;
                
                DOB = student.DOB;
                MobileNumber= student.MobileNumber;
                Address = student.Address;
                City = student.City;
                State = student.State;
                Pincode = student.Pincode;


            }
            else
            {
                ErrorMessage = "No record found with this id";
            }
        }

        

        public void OnPost()
        {
           
            Genders = GetGenders();
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data.Please try again";
                return;
            }
          
           
            var employeeDataAccess = new ParticipantDataAccess();
            var newEmployee = new ParticipantDataModel
            {
                ParticipantId = Id,
                ParticipantName = ParticipantName,
                Gender = Gender,
                DOB = DOB,
                MobileNumber = MobileNumber,
                Address = Address,
                City = City,
                State = State,
                Pincode = Pincode,
               


            };
            var insertedParticipant = employeeDataAccess.Update(newEmployee);

            if (insertedParticipant != null && insertedParticipant.Id > 0)
            {
                SuccessMessage = $"Successfully Inserted Employee {insertedParticipant.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Error! Add Failed.Please try Again";
            }
        }
    }
}