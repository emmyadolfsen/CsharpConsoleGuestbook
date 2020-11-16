using System.Collections.Generic;
using Newtonsoft.Json;

namespace Guestbook
{
    public class FileHandling
    {
        public void DeSerialize(out string jsonData, out List<CreatePosts> postList)
        {       
        string jsonPath = @"posts.json";    // Sökväg för json-fil

        // Läs in json data
        var jsonD = System.IO.File.ReadAllText(jsonPath);
        // Deserialisera till objekt eller skapa ny lista
        var postL = JsonConvert.DeserializeObject<List<CreatePosts>>(jsonD) 
        ?? new List<CreatePosts>();
        jsonData = jsonD;
        postList = postL;
        }
        
        public void Serialize(string jsonData, List<CreatePosts> postList)
        {
            string jsonPath = @"posts.json"; // sökväg till json-fil

            // serialisera den uppdaterade datan till json-fil
            jsonData = JsonConvert.SerializeObject(postList);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        }
    }
}