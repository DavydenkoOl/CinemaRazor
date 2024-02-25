
using System.ComponentModel.DataAnnotations;


namespace CinemaRazor.Models
{
    public class Kino
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Genre { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Director { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string? Description { get; set; }
        public string? Poster { get; set; }

        public Kino() { }

    }
}
