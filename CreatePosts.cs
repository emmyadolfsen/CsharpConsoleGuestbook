using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace Guestbook
{
    public class CreatePosts
    {
        public string MyName { get; set; }  // för namn i inlägg
        public string MyPost { get; set; }  // för meddelande i inlägg
        string jsonPath = @"posts.json";    // Sökväg för json-fil
        

    public void CreateNewPost()
        {
            var serialize = new FileHandling();
            string Name = "";
            string Post = "";

            // om filen inte finns - skapa ny fil med filestream
            if (!File.Exists(jsonPath))
            {
                FileStream fs = File.Create(jsonPath);
            }

            Clear();
            do  // do-wile loop körs om input i namn eller post är tomt
            {
            WriteLine("(Namn och inlägg får inte vara tomt)");
            Write("Skriv in ditt namn: ");
            Name = ReadLine();
            Write("Skriv ditt inlägg: ");
            Post = ReadLine();
            }

            while(string.IsNullOrEmpty(Post) || string.IsNullOrEmpty(Name));

            serialize.DeSerialize(out string jsonData, out List<CreatePosts> postList); // kör funktionen deserialize

            postList.Add(new CreatePosts()  // Lägg till ny post
            {
                MyName = Name,
                MyPost = Post,
            });

            serialize.Serialize(jsonData, postList); // kör funktionen serialize

        }
    }
}