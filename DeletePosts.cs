using System;
using static System.Console;
using System.Collections.Generic;


namespace Guestbook
{
    public class DeletePosts
    {
        public void DeletePost()
        {
            
            bool deleteCheck = true;
            while (deleteCheck)
            {
            //bool showMenu = false;
            var serialize = new FileHandling();
            WriteLine();
            Write("Radera inlägg nummer: ");

            string deleteInput = ReadLine();

            try // prova om det är rätt input
            {
            int deleteIndex = Convert.ToInt32(deleteInput) - 1; // gör om string till int
            // kör funktionen deserialize
            serialize.DeSerialize(out string jsonData, out List<CreatePosts> postList);
            // Radera i listan där index = deleteIndex
            postList.RemoveAt(deleteIndex);
            // kör funktionen serialisera
            serialize.Serialize(jsonData, postList);
            Clear();
            deleteCheck = false;
            }
            catch (ArgumentOutOfRangeException) // om input är mer än vad som finns i listan
            {
                Clear();
                ForegroundColor = ConsoleColor.Red; 
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
                ForegroundColor = ConsoleColor.Red; 
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