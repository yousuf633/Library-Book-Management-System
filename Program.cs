using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Book_Management_System
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("How many books do you want to enter?");
            int numberOfBook = Convert.ToInt32(Console.ReadLine());
            Book[] books = new Book[numberOfBook];
            // Enter books information
            for (int i = 0; i < books.Length; i++)
            {
                Console.WriteLine("\n Enter Infomation for book " + (i + 1));
                books[i] = new Book();
                Console.WriteLine("Enter Book ID: ");
                books[i].BookID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Book Title: ");
                books[i].Title = Console.ReadLine();
                Console.WriteLine("Enter Book Author: ");
                books[i].Author = Console.ReadLine();
                Console.Write("Enter Number of Copies: ");
                books[i].NumberOfCopies = Convert.ToInt32(Console.ReadLine());
                while (books[i].NumberOfCopies < 0)
                {
                    Console.WriteLine("Number of copies cannot be negative.");
                    Console.Write("Enter Number of Copies again: ");
                    books[i].NumberOfCopies = Convert.ToInt32(Console.ReadLine());
                }
            }
            // Display all books
            Console.WriteLine("\n========== ALL BOOKS ==========");
            for (int i = 0; i < books.Length; i++)
            {
                books[i].DisplayBookInfo();
            }
            // Summary
            int availableBooks = 0;
            int unavailableBooks = 0;
            Book highestCopiesBook = books[0];
            for(int i=0;i<books.Length;i++)
            {
                if (books[i].IsAvailiable())
                {
                    availableBooks++;

                }
                else
                {
                    unavailableBooks++;
                }
                if (books[i].NumberOfCopies>highestCopiesBook.NumberOfCopies)
                {
                    highestCopiesBook = books[i];
                }
            }
            Console.WriteLine("\n========== SUMMARY ==========");

            Console.WriteLine("Total number of books: "+books.Length);
            Console.WriteLine("Number of available books: " + availableBooks);
            Console.WriteLine("Number of unavailable books: " + unavailableBooks);
            Console.WriteLine("\nBook with the highest number of copies:");
            highestCopiesBook.DisplayBookInfo();
            // Display available books
            Console.WriteLine("\n========== AVAILABLE BOOKS ==========");
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].IsAvailiable())
                {
                    books[i].DisplayBookInfo();
                }
            }
            // Borrow a book
            Console.WriteLine("\nEnter Book ID to borrow: ");
            int borrowID = Convert.ToInt32(Console.ReadLine());
            bool borrowFound = false;
            for(int i = 0; i < books.Length;i++)
            {
                if (books[i].BookID==borrowID)
                {
                    borrowFound = true;
                    if (books[i].IsAvailiable())
                    {
                        books[i].NumberOfCopies--;
                        Console.WriteLine("Book borrowed successfully.");
                        Console.WriteLine("Remaining Copies: " + books[i].NumberOfCopies);
                    }
                    else
                    {
                        Console.WriteLine("Book is not available.");
                    }
                    break;
                }
            }

            if (!borrowFound)
            {
                Console.WriteLine("Book not found.");
            }
            // Return a book
            Console.Write("\nEnter Book ID to return: ");
            int returnID = Convert.ToInt32(Console.ReadLine());
            bool returnFound = false;

            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].BookID == returnID)
                {
                    returnFound = true;

                    books[i].NumberOfCopies++;

                    Console.WriteLine("Book returned successfully.");
                    Console.WriteLine("Current copies: " + books[i].NumberOfCopies);

                    break;
                }
            }
            if (!returnFound)
            {
                Console.WriteLine("Book not found.");
            }
            Console.WriteLine("\n========== FINAL BOOKS ==========");

            for (int i = 0; i < books.Length; i++)
            {
                books[i].DisplayBookInfo();
            }

        }
    }
}
