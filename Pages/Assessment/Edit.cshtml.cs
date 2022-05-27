using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using ProjectCRUD.Pages.DataAccess;

namespace ProjectCRUD.Pages.Assessment
{
    public class EditModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty, Required, MinLength(1), MaxLength(2)]
        [Display(Name = "Grade")]
        public string Grade { set; get; }
        public List<SelectListItem> Grades { get; set; }
       


        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        private List<SelectListItem> GetGrade()
        {
            var selectitems = new List<SelectListItem>();
            selectitems.Add(new SelectListItem { Text = "A", Value = "A" });
            selectitems.Add(new SelectListItem { Text = "B", Value = "B" });
            selectitems.Add(new SelectListItem { Text = "C", Value = "C" });


            return selectitems;

        }


        public void OnGet(int id)
        {
            Id=id;
            Grades = GetGrade();
        }


        public void OnPost()
        {
            Grades = GetGrade();
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data. Please try again.";
                return;
            }

            var studentcoursedata = new ParticipantCourseDataAccess();
            var result = studentcoursedata.Update(Id, Grade);

            if (result)
            {
                SuccessMessage = "Grade Updated Successfully";
                ErrorMessage = "";
            }
            else
            {
                ErrorMessage = $"Error! Updating Grade - {studentcoursedata.ErrorMessage}";
                SuccessMessage = "";
            }
        }

    }
}
