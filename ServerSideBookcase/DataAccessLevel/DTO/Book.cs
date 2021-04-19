using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.DTO
{
    [Serializable]
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PathToBook { get; set; }
        public string PathToTitleImage { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public Book FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Book>(json);
        }
    }
}
