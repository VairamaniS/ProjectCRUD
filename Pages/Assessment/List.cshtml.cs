using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectCRUD.Models;
using ProjectCRUD.Pages.DataAccess;

namespace ProjectCRUD.Pages.Assessment
{
    public class ListModel : PageModel
    {
        public List<ParticipantCourseDataModel> ParticipantRecords { get; set; }

        
        public void OnGet()
        {
            var studentdata = new ParticipantCourseDataAccess();
            ParticipantRecords = studentdata.GetAll();
        }

    }
}
