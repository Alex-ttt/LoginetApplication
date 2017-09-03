using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TestApp.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string UserName { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }

    }
}
