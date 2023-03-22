using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comp2084_project.Models
{
    public class CinemaRoom
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Seats_no { get; set; }
        [Required]

        public int CinemaRoomNumber { get; set; }

        [Display(Name = "Movie")]

        [Required]
        public int MovieId { get; set; }

        public Movie? Movie { get; set; }


    }
}
