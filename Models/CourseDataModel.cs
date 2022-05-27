using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCRUD.Models
{
    public class CourseDataModel
    {

       
        public string Location { get;  set; }
        
        public int CourseId { get; internal set; }
        public string CourseName { get; internal set; }
        public string CourseMaterial { get; internal set; }
        public object Id { get; internal set; }
        public string Duration { get; internal set; }

        public CourseDataModel()
        {

            CourseId= 0;
            CourseName = "";
            CourseMaterial = "";
            Location = "";



        }

        public bool IsValid()
        {
            //if (Id <= 0)
            //{
            //    return false;
            //}

            if (CourseId<=10)
            {
                return false;
            }
            if (CourseName== null || CourseName.Trim().Length > 1 || CourseName.Trim() == "")
            {
                return false;
            }
            if (CourseMaterial == null || CourseMaterial.Trim().Length > 1 || CourseMaterial.Trim() == "")
            {
                return false;
            }
           
            if (Location == null || Location.Trim().Length > 50 || Location.Trim() == "")
            {
                return false;
            }
            return true;
        }





    }
}



