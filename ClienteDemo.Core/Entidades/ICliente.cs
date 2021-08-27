using System;
using System.ComponentModel.DataAnnotations;

namespace ClienteDemo.Core.Entidades
{
    public interface ICliente
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Cliente is a required a field")]
        string Cliente { get; set; }
        [Required(ErrorMessage = "Nome is a required a field")]
        string Nome { get; set; }
        bool isDeleted { get; set; }
    }
}