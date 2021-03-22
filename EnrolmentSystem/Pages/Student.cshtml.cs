using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnrolmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EnrolmentSystem.Pages
{
    public class StudentModel : PageModel
    {
        public StudentModel(EnrolmentDBContext enrollcontext)
        {
            _enrollmentdbcontext = enrollcontext;
        }

        //create property for DBContext instance
        private readonly EnrolmentDBContext _enrollmentdbcontext;

        [BindProperty]
        public Student Student { get; set; }

        public List<Student> Students = new List<Student>();

        public void OnGet()
        {
            Students = _enrollmentdbcontext.Students.ToList();   
        }
        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Students = _enrollmentdbcontext.Students.ToList();
                return Page();
            }
            _enrollmentdbcontext.Students.Add(Student);
            _enrollmentdbcontext.SaveChanges();
            return Redirect("/student");
        }

        public void OnGetDelete(int id)
        {
            //query the student to delete
            var stud = _enrollmentdbcontext.Students
                .FirstOrDefault(s => s.StudentId == id);

            //perform null check
            if(stud != null)
            {
                //remove and update DB
                _enrollmentdbcontext.Students.Remove(stud);
                _enrollmentdbcontext.SaveChanges();
            }
           

            //refresh the page
            OnGet();

        }
    }
}
