using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLevel.DTO
{
    public class Page
    {
        public int Number { get; set; }
        public Book SelectedBook { get; set; }
        public bool IsSavedPage { get; set; }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public Page FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Page>(json);
        }
    }
}
