using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title {  get; set; }
        public string Author { get; set; }
        public int NumberOfCopies { get; set; }

        public bool IsAvailiable()
        {
            return NumberOfCopies > 0;
        }
        public void DisplayBookInfo()
        {
            Console.WriteLine("Book ID" + BookID);
            Console.WriteLine("Title " + Title);
            Console.WriteLine("Author " + Author);
            Console.WriteLine("Number Of Copies "+NumberOfCopies);
            if(IsAvailiable())
            {
                Console.WriteLine("Status:Available");
            }
            else 
            {
                Console.WriteLine("Status: Not Available");
            
            }
            Console.WriteLine("-----------------------------------------------");


        }
    }
}
