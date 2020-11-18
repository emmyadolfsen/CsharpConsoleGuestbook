using static System.Console;
using System.Collections.Generic;
using System.IO;


namespace Guestbook
{
    public class WriteMenu
    {
        public void WriteMenuAndLoop()
        {
            var serialize = new FileHandling();
            string jsonPath = @"posts.json";    // Sökväg för json-fil

            WriteLine("Emmys Gästbok\n");
            WriteLine("1) Skriv i gästbok");
            WriteLine("2) Radera post");
            WriteLine("3) Avsluta\n");

            if (File.Exists(jsonPath))  // om filen finns
            {
                serialize.DeSerialize(out string jsonData, out List<CreatePosts> postList); // kör funktionen deserialize

                int indx = 1;                   // index börjar på ett för att det är snyggare och konventionellt
                foreach (var post in postList)  // foreach-loop för att skriva ut alla poster
                {                               
                WriteLine($"[{indx}]{post.MyName} - {post.MyPost}");
                indx ++;    // öka index med ett
                } 
            }
        }
    }
}