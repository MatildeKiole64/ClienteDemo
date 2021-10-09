using System;
using System.ComponentModel.DataAnnotations;

namespace ClienteDemo.Infrastucture.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nome is a required field")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Codigo is a required field")]
        public string Codigo { get; set; }
        public bool IsActive { get; set; }
    }
}
