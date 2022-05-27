using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCRUD.Models;
using ProjectCRUD.DataAccess;

namespace ProjectCRUD.Pages.Participants

{
    public class ListModel : PageModel
    {
        [BindProperty]
        public int ParticipantId { get; set; }
        public string ParticipantName { get;  set; }
        public string CourseName { get; set; }
        public string Gender { get;  set; }
        public DateTime DOB { get;  set; }
        public string MobileNumber { get;  set; }
        public string Address { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Pincode { get;  set; }
        public string Location { get; set; }
   
        public string SearchText { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public List<ParticipantDataModel> participants { get; set; }


        public ListModel()
        {
            SearchText = "";
            SuccessMessage = "";
            ErrorMessage = "";
            participants = new List<ParticipantDataModel>();
        }


        public void OnGet()
        {
            var participantData = new ParticipantDataAccess();
            participants = participantData.GetAll();
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

           var branchData = new ParticipantDataAccess();
           participants = branchData.GetEmployeeByName(SearchText);

           if (participants != null && participants.Count > 0)

           {
               SuccessMessage = $"{participants.Count} Courses found ";

           }
           else
           {
               ErrorMessage = "No courses found";

           }

       }


       public void OnPostClear()
       {
           SearchText = "";
           ModelState.Clear();
           OnGet();
       }




    }
}
