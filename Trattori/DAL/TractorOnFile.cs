using System.Text.Json;
using Trattori.Controllers;
using Trattori.Models;

namespace Trattori.DAL
{
    public class TractorOnFile : IDal
    {
        private static readonly string tractorFilePath = "Tractors.txt";
        public IEnumerable<T> ReadAndDeserialize<T>()
        {
            var jsonTractors = File.ReadAllText(tractorFilePath);
            if (jsonTractors == string.Empty)
            {
                return new List<T>();
            }
            var tractorsCollection = JsonSerializer.Deserialize<IEnumerable<T>>(jsonTractors);
            return tractorsCollection;
        }

        public void WriteAndSerialize<T>(IEnumerable<T> collection)
        {
            string jsonTractors = JsonSerializer.Serialize(collection);
            File.WriteAllText(tractorFilePath, jsonTractors);
        }
    }
}
