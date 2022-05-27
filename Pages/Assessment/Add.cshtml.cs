using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectCRUD.DataAccess;
using ProjectCRUD.Pages.DataAccess;
using System.ComponentModel.DataAnnotations;


namespace ProjectCRUD.Pages.Assessment
{
    public class AddModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Participant")]
        public int SelectedParticipantId { get; set; }
        [BindProperty]
        public List<SelectListItem> ParticipantList { get; set; }
        [BindProperty]
        [Display(Name = "Course")]
        public int SelectedCourseId { get; set; }
        [BindProperty]
        public List<SelectListItem> CourseList { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public AddModel()
        {
            SuccessMessage = "";
            ErrorMessage = "";
            SelectedParticipantId = 0;
            ParticipantList = GetParticipantList();
            SelectedCourseId = 0;
            CourseList = GetCourses();
        }

        private List<SelectListItem> GetParticipantList()
        {
            var employeeData = new ParticipantDataAccess();
            var students = employeeData.GetAll();
            var studentsList = new List<SelectListItem>();

            foreach (var employee in students)
            {
                studentsList.Add(new SelectListItem
                {
                    Text = employee.ParticipantName,
                    Value = employee.Id.ToString()
                });
            }

            return studentsList;
        }

        private List<SelectListItem> GetCourses()
        {
            var courseData = new CourseDataAccess();
            var courses = courseData.GetAll();
            var coursesList = new List<SelectListItem>();

            foreach (var c in courses)
            {
                coursesList.Add(new SelectListItem
                {
                    Text = c.CourseName,
                    Value = c.CourseId.ToString()
                });
            }

            return coursesList;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

            ParticipantList = GetParticipantList();
            CourseList = GetCourses();


            var studentcourse = new ParticipantCourseDataAccess();
            var result = studentcourse.Insert(SelectedParticipantId, SelectedCourseId);


            if (result)
            {
                SuccessMessage = "Successfully Inserted!";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error adding Participant Course - {studentcourse.ErrorMessage}";
                SuccessMessage = "";
            }
        }
    }
}
