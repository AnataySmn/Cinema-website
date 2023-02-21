using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace comp2084_project.Models
{
    public class Movie 
    {
        
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Director { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }
    }

 
    
}
