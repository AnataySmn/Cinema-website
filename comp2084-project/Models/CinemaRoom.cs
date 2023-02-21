using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comp2084_project.Models
{
    public class CinemaRoom
    {
        public int CinemaRoomId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Seats_no { get; set; }

        public int CinemaRoomNumber { get; set; }

        [Display(Name = "Movie")]
        public virtual int Id { get; set; }
        [ForeignKey("Id")]
        public virtual Movie Movies { get; set; }


    }
}
