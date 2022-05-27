using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCRUD.Models;
using ProjectCRUD.DataAccess;

namespace ProjectCRUD.Pages.Courses

{
    public class ListModel : PageModel
    {
        [BindProperty]
        public int CourseId { get;  set; }
        public string CourseName { get;  set; }
        public string CourseMaterial { get;  set; }
        public string Location { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public List<CourseDataModel> courses { get; set; }


        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            courses = new List<CourseDataModel>();
        }


        public void OnGet()
        {
            var coursedata = new CourseDataAccess();
            courses = coursedata.GetAll();
        }
        public void OnPostSearch()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Search";
                return;
            }

            if (string.IsNullOrEmpty(SearchText))
            {
                ErrorMessage = "Invalid Data";
                return;

            }

            var departmentData = new CourseDataAccess();
             courses = departmentData.GetDepartmentByName(SearchText);

            if (courses != null && courses.Count > 0)

            {
                SuccessMessage = $"{courses.Count} Coursess Found ";

            }
            else
            {
                ErrorMessage = "No departments found";

            }

        }









    }
}
