using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using ProjectCRUD.Models;
using ProjectCRUD.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace ProjectCRUD.Pages.Courses
{
    [Authorize]
    public class AddModel : PageModel
    {

        [BindProperty]
        [Display(Name = "CourseName")]
        [Required]
        public string CourseName { get; set; }
       


        [BindProperty]
        [Display(Name = "CourseMaterial")]
        [Required]
        public string CourseMaterial { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public AddModel()
        {
           // CourseName = "";
            //CourseMaterial = "";
            SuccessMessage = "";
            ErrorMessage = "";
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
            var courseData = new CourseDataAccess();
            var newcourse = new CourseDataModel { CourseName = CourseName, CourseMaterial = CourseMaterial };
            var insertedcourse = courseData.Insert(newcourse);

            if (insertedcourse != null && insertedcourse.CourseId > 0)
            {
                SuccessMessage = $"Successfully inserted Course {insertedcourse.CourseId}";
                ModelState.Clear();
            }
            else
            {
                ErrorMessage = "Error! Add Failed.Please Try Again";
            }
        }
    }
}
