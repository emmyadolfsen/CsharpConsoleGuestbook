using static System.Console;
using System.Collections.Generic;


namespace Guestbook
{
    public class CreatePosts
    {
        public string MyName { get; set; }  // för namn i inlägg
        public string MyPost { get; set; }  // för meddelande i inlägg
        
        

    public void CreateNewPost()
        {
            var serialize = new FileHandling(); // instansiera klassen filehandling
            string Name = "";
            string Post = "";



            Clear();
            do  // do-while loop körs om input i namn eller post är tomt
            {
            WriteLine(" - Namn och inlägg får inte vara tomt - ");
            Write("Skriv in ditt namn: ");
            Name = ReadLine();              // läs in input
            Write("Skriv ditt inlägg: ");
            Post = ReadLine();              // läs in input
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