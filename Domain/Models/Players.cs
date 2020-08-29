using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PalmeirasPlayers.Domain.Models
{
    [Table("tb_players")]
    public class Players
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter 3 a 60 caracteres")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter 2 a 60 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve conter 2 a 60 caracteres")]
        public string PlayingPosition { get; set; }
       
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int ShirtNumber { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Age { get; set; }
    }
}
