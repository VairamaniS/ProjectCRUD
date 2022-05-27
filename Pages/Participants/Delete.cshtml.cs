using ProjectCRUD.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCRUD.DataAccess;

namespace ProjectCRUD.Pages.Participants
{
    public class DeleteModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int ParticipantId { get; set; }

        public bool ShowButton { get; set; }

        public string ParticipantName { get; set; }

        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }

        public DeleteModel()
        {
            ParticipantName = "";
            SuccessMessage = "";
            ErrorMessage = "";
            ShowButton = true;
        }

        public void OnGet(int id)
        {
            ParticipantId = ParticipantId;

            if (ParticipantId <= 0)
            {
                ErrorMessage = "Invalid Id";
                return;
            }

            var employeeData = new ParticipantDataAccess();
            var student = employeeData.GetEmployeeById(id);

            if (student != null)
            {
                ParticipantName = student.ParticipantName;
                ;
            }
            else
            {
                ErrorMessage = "No Record found with that Id";
            }
        }

        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid Data";
                return;
            }

            var studentData = new ParticipantDataAccess();
            var numOfRows = studentData.Delete(ParticipantId);
            if (numOfRows > 0)
            {
                SuccessMessage = $"Employee {ParticipantId} deleted successfully!";
                ShowButton = false;
            }
            else
            {
                ErrorMessage = $"Error! Unable to delete Participant {ParticipantId}";
            }
        }
    }
}