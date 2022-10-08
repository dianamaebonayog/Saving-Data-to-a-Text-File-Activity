using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace BonayogDianaMae.SaveJsonFile.Pages
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public StudentModel? ViewModel { get; set; }
        public IActionResult OnGet(string? firstName)
        {
            this.ViewModel = new StudentModel();
            this.ViewModel.FirstName = firstName;

            return Page();
        }
        public IActionResult OnPost()
        {

            string fileName = @"C:\Temp\diana.txt";

            {
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    var fileText = "{studentNumber:" + this.ViewModel.StudentNumber + "''";
                    fileText = "{firstName:" + this.ViewModel.FirstName + "''";
                    fileText = "{lastName:" + this.ViewModel.LastName + "''";
                    fileText = "{dateofBirth" + this.ViewModel.DateofBirth + "''";
                    fileText = "{yearLevel:" + this.ViewModel.YearLevel + "''";
                    fileText = "{course:" + this.ViewModel.Course + "''";


                    Byte[] title = new UTF8Encoding(true).GetBytes(fileText);
                    fs.Write(title, 0, title.Length);

            }
         }
       

            return Page();
        }
       public class StudentModel
        {
            public int? StudentNumber { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public DateTime? DateofBirth { get; set; }
            public int? YearLevel { get; set; }
            public Course? Course { get; set; }
            
        }


        public enum Course
        {
            BSIS,
            BSTM,
            BSCA,
            BSCRIM,
            BSBA
            
        }

    }

}

