using System;
using System.ComponentModel.DataAnnotations;

namespace T3_Grupo4.Models
{
    public class Libro
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(100)]
        public string Autor { get; set; }

        [Required]
        [StringLength(100)]
        public string Tema { get; set; }

        [Required]
        [StringLength(100)]
        public string Editorial { get; set; }

        [Required]
        [Range(1900, 3000, ErrorMessage = "El año de publicación debe estar entre 1900 y 3000.")]
        public int AnioPublicacion { get; set; }

        [Required]
        [Range(10, 1000, ErrorMessage = "El número de páginas debe estar entre 10 y 1000.")]
        public int Paginas { get; set; }

        [Required]
        [StringLength(50)]
        public string Categoria { get; set; }
    }
}
