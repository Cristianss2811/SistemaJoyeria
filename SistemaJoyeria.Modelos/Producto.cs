using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SistemaJoyeria.Modelos
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(30, ErrorMessage = "Maximo 30 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es requerido")]
        [MaxLength(100, ErrorMessage = "Maximo 100 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El costo es requerido")]
        public double Costo { get; set; }

        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "El estado es requerido")]
        public bool Estado { get; set; }

        //Agregamos la relacion con la tabla categoria
        [Required(ErrorMessage = "La categoria es requerido")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        //La relacion con la tabla marca
        [Required(ErrorMessage = "La charola es requerida")]
        public int CharolaId { get; set; }
        [ForeignKey("CharolaId")]
        public Charola Charola { get; set; }

        //Hagamos la recursividad del padre 
        public int? PadreId { get; set; }
        public virtual Producto Padre { get; set; }
    }

}
