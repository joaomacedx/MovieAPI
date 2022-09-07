using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The title field is required, it cannot be null")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Director field is required, it cannot be null")]
        public string Director { get; set; }

        [StringLength(50, ErrorMessage = "The gender field cannot exceed 50 characters")]
        public string Gender { get; set; }

        [Range(1, 600, ErrorMessage = "The duration must be a minimum of 1 minute and a maximum of 600 minutes")]
        public int Duration { get; set; }
      
    }
}
