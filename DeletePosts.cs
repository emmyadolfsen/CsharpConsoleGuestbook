using System;
using static System.Console;
using System.Collections.Generic;


namespace Guestbook
{
    public class DeletePosts
    {
        public void DeletePost()
        {
            
            bool deleteCheck = true;    // sätt en bool till tru
            while (deleteCheck)         // loopa så länge bool är true
            {
            
            var serialize = new FileHandling(); // instansiera klassen filehandling
            WriteLine();
            Write("Radera inlägg nummer: ");

            string deleteInput = ReadLine();    // läs input

            try // prova om det är rätt input
            {
            int deleteIndex = Convert.ToInt32(deleteInput) - 1; // gör om string till int, ta bort ett
            
            serialize.DeSerialize(out string jsonData, out List<CreatePosts> postList); // kör funktionen deserialize
            
            postList.RemoveAt(deleteIndex); // Radera i listan där index = deleteIndex
            
            serialize.Serialize(jsonData, postList);    // kör funktionen serialisera
            Clear();
            deleteCheck = false;
            }
            catch (ArgumentOutOfRangeException) // om input är mer än vad som finns i listan
            {
                Clear();
                ForegroundColor = ConsoleColor.Red; // ändra textfärg
                WriteLine("- Numret finns inte i listan, försök igen. - \n");
                ForegroundColor = ConsoleColor.Gray;

                serialize.DeSerialize(out string jsonData, out List<CreatePosts> postList); // kör funktionen deserialize

                int indx = 1;                   // index börjar på ett för att det är snyggare
                foreach (var post in postList)  // foreach-loop för att skriva ut alla poster
                {                               
                WriteLine($"[{indx}]{post.MyName} - {post.MyPost}");
                indx ++;
                } 
                deleteCheck = true;
            }
            
             catch (FormatException) // om input inte är nummer
            {
                Clear();
                ForegroundColor = ConsoleColor.Red; // ändra textfärg
                WriteLine("- Du måste välja ett nummer, försök igen. - \n");
                ForegroundColor = ConsoleColor.Gray;

                serialize.DeSerialize(out string jsonData, out List<CreatePosts> postList); // kör funktionen deserialize

                int indx = 1;                   // index börjar på ett för att det är snyggare
                foreach (var post in postList)  // foreach-loop för att skriva ut alla poster
                {                               
                WriteLine($"[{indx}]{post.MyName} - {post.MyPost}");
                indx ++;
                } 
                deleteCheck = true;
            }
            
            }
            
        }
    }
}