using System.Collections.Generic;
using Newtonsoft.Json;

namespace Guestbook
{
    public class FileHandling
    {
        string jsonPath = @"posts.json"; // sökväg till json-fil
        public void DeSerialize(out string jsonData, out List<CreatePosts> postList)
        {       
            // Läs in json data
            var jsonD = System.IO.File.ReadAllText(jsonPath);

            // Deserialisera till objekt eller skapa ny lista
            var postL = JsonConvert.DeserializeObject<List<CreatePosts>>(jsonD) 
            ?? new List<CreatePosts>();

            jsonData = jsonD;   // ändra till rätt variabelnamn
            postList = postL;
        }
        
        public void Serialize(string jsonData, List<CreatePosts> postList)
        {
            // serialisera den uppdaterade datan och spara till json-fil
            jsonData = JsonConvert.SerializeObject(postList);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        }
    }
}