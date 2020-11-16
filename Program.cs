using System;
using static System.Console;


namespace Guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            Clear();
            bool showMenu = true;   // bool satt som true
            while (showMenu)        // så länge showMenu är true körs loopen
            {
                showMenu = MainMenu();
            }
        }
        
        private static bool MainMenu()
        {
            var pageOne = new CreatePosts();   // Instansiera klassen createposts
            var pageTwo = new DeletePosts();
            var writeMenu = new WriteMenu();

            writeMenu.WriteMenuAndLoop();   // kör funktionen writemenuandloop
            
            switch (ReadLine())
            {
                case "1":                   // vid input 1
                pageOne.CreateNewPost();    // kör funktionen CreateNewPost
                Clear();
                return true;                // gå tillbaks till loop

                case "2":                   // vid input 2
                pageTwo.DeletePost();       // kör deleteindex i deletepost-klassen
                return true;                // gå tillbaks till loop

                case "3":                   // vid input 3
                Clear();
                WriteLine("\nTack för idag!\n");
                return false;               // avsluta

                default:                    // vid annan input
                Clear();
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("- Du måste välja något av alternativen. - \n");
                ForegroundColor = ConsoleColor.Gray;
                return true;                // gå tillbaks till loop

            }

        }

    }
}