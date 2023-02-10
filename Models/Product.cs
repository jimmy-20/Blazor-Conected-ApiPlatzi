using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BlazorWebAssemblyApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<string> Images { get; set; }

        [JsonIgnore]
        public string Image{get;set;}
    }
}