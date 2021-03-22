using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnrolmentSystem.Pages
{
    public class EditModel : PageModel
    {
        public EditModel(EnrolmentDBContext enrollmentdbcontext)
        {
            _enrollmentdbcontext = enrollmentdbcontext;
        }

        private readonly EnrolmentDBContext _enrollmentdbcontext;

        [BindProperty]
        public Student Student { get; set; }

        public void OnGet(int id)
        {
            Student = _enrollmentdbcontext.Students.
                FirstOrDefault(students => students.StudentId == id);
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //--------------------------------------
            //first approach is to use a generic variable
            //--------------------------------------
            ////get the student to edit
            //var stud = _enrollmentdbcontext.Students.FirstOrDefault(student => student.StudentId==Student.StudentId);


            //--------------------------------------
            //second approach is to use a generic variable
            //--------------------------------------
            Student stud = new Student();
            stud = _enrollmentdbcontext.Students.FirstOrDefault(student => student.StudentId == Student.StudentId);

            if (stud != null)
            {
                //update each field based on the submitted POST values
                stud.Name = Student.Name;
                stud.Age = Student.Age;
                stud.Address = Student.Address;

                //update the student
                _enrollmentdbcontext.Update(stud);
                //save the changes
                _enrollmentdbcontext.SaveChanges();
            }
            return Redirect("Student");
            
        }
    }
}
