using ProjectCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCRUD.DataAccess;

namespace ProjectCRUD.Pages.Participants
{
    public class AddModel : PageModel
    {

        [BindProperty]
        [Display(Name = "ParticipantName")]
        [Required]
        public string ParticipantName { get; set; }

        [BindProperty]
        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }

        public List<SelectListItem> Genders { get; set; }

        [BindProperty]
        [Display(Name = "DOB")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [BindProperty]
        [Display(Name = "MobileNumber")]
        [Required]
        public string MobileNumber { get; set; }

        [BindProperty]
        [Display(Name = "Address")]
        [Required]
        public string Address { get; set; }
        [BindProperty]
        [Display(Name = "City")]
        [Required]
        public string City { get; set; }
        [BindProperty]
        [Display(Name = "State")]
        [Required]
        public string State { get; set; }

        [BindProperty]
        [Display(Name = "Pincode")]
        [Required]
        public string Pincode { get; set; }


        [BindProperty]

        public List<SelectListItem> Locations { get; set; }

        [BindProperty]
        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }


        


        [BindProperty]
        [Display(Name = "Course")]
        public int SelectedCourse { get; set; }

        public List<SelectListItem> CourseList { get; set; }



        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        

        public AddModel()
        {
            ParticipantName = "";
            Gender = "";
            DOB = DateTime.Now.AddYears(-20);
            MobileNumber = "";
            Address = "";
            City = "";
            State = "";
            Pincode = "";
            Location = "";
            SuccessMessage = "";
            ErrorMessage = "";
            CourseList = GetCourses();
            Locations = GetLocations();
            Genders = GetGenders();

        }

        public void OnGet()
        {

        }

        private List<SelectListItem> GetCourses()
        {
            //Get Data from Data Access
            var coursedataAccess = new CourseDataAccess();
            var courseList = coursedataAccess.GetAll();

            //Create SelectListItem
            
            var courseSelectList = new List<SelectListItem>();
            foreach (var course in courseList)
            {
                courseSelectList.Add(new SelectListItem
                {
                    Text = $"{course.CourseName}",
                    Value = course.CourseId.ToString(),
                });
            }
            return courseSelectList;
        }

        private List<SelectListItem> GetLocations()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "1st Floor", Value = "1st Floor" });
            selectItems.Add(new SelectListItem { Text = "2nd Floor", Value = "2nd Floor" });
            selectItems.Add(new SelectListItem { Text = "3rd Floor", Value = "3rd Floor" });
            selectItems.Add(new SelectListItem { Text = "4th Floor", Value = "4th Floor" });

            return selectItems;
        }

        private List<SelectListItem> GetGenders()
        {
            var selectItems = new List<SelectListItem>();
            selectItems.Add(new SelectListItem { Text = "Male", Value = "M" });
            selectItems.Add(new SelectListItem { Text = "Female", Value = "F" });
            selectItems.Add(new SelectListItem { Text = "Unspecified", Value = "U" });

            return selectItems;
        }

        public void OnPost()
        {
            CourseList = GetCourses();
            Locations = GetLocations();
            Genders = GetGenders();
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data.Please try again";
                return;
            }
            
            
            var studataaccess = new ParticipantDataAccess();
            var newStudent = new ParticipantDataModel
            {
                ParticipantName = ParticipantName,
                Gender = Gender,
                DOB = DOB,
                MobileNumber = MobileNumber,
                Address = Address,
                City = City,
                State = State,
                Pincode = Pincode,
                Location = Location,
                Course = SelectedCourse
               


            };
            var insertedParticipant = studataaccess.Insert(newStudent);

            if (insertedParticipant!= null && insertedParticipant.Id > 0)
            {
                SuccessMessage = $"Successfully Inserted Participant {insertedParticipant.Id}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Error! Add Failed.Please try Again";
            }
        }
    }
}
