using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCRUD.DataAccess;
using System.ComponentModel.DataAnnotations;
using ProjectCRUD.DataAccess;
using ProjectCRUD.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProjectCRUD.Pages.Departments
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {

        [BindProperty(SupportsGet = true)]
        public int CourseId { get; set; }

        [BindProperty]
        [Display(Name = "CourseName")]
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string CourseName { get; set; }



        [BindProperty]
        [Display(Name = "CourseMaterial")]
        [Required]
        
        public string CourseMaterial { get; set; }

       

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnGet(int id)
        {
            CourseId = id;
            if (CourseId < 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }
            var departmentData = new CourseDataAccess();
            var course= departmentData.GetDepartmentById(id);
            if (course != null)
            {
                CourseName = course.CourseName;
                CourseMaterial = course.CourseMaterial;

            }
            else
            {
                ErrorMessage = "No record found with this id";
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data... Please enter again";
                return;
            }
            var departmentData = new CourseDataAccess();
            var depToUpdate = new CourseDataModel { CourseId = CourseId, CourseName = CourseName, CourseMaterial = CourseMaterial };
            var updatedcourse = departmentData.update(depToUpdate);

            if (updatedcourse != null)
            {
                SuccessMessage = $"Course {updatedcourse.CourseId} updated successfully";
            }
            else
            {
                ErrorMessage = $"Error! Updating";
            }
        }


    }
}