using System.IO;
using Newtonsoft.Json.Linq;

namespace Auxo.Location
{
    public class Locale
    {
        private readonly JObject _json;

        public Locale(string file)
        {
            _json = JObject.Parse(File.ReadAllText(file));
        }

        public string this[string path] => (string) _json.SelectToken(path); 
    }
}