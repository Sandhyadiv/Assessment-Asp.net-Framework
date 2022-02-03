using System.ComponentModel.DataAnnotations;

namespace WebApicore.Models
{
    public class movie { 
    
        [Key]
        public int Id { get; set; }
        public object ID { get; internal set; }
        public string MovieName { get; set; }
        public string Descriptions { get; set; }
        public string Movie_Type { get; set; }
        public string Languages { get; set; }
    }
}
