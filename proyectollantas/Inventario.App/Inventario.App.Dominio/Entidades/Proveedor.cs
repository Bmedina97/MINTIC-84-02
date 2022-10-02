using System.ComponentModel.DataAnnotations;

namespace Inventario.App.Dominio.Entidades

{
    public class Proveedor
    {
        //atributos de la clase Proveedor
        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }
        [Required]        
        [Display(Name = "Nit")]
        public string nit{ get; set; }
        [Required]        
        [Display(Name = "Nombre del Proveedor")]
        public string nombre{ get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string direccion{ get; set; }
        [Required]                   
        [Display(Name = "Telefono")]
        public string telefono{ get; set; }
        [Required]        
        [Display(Name = "Correo electronico")]
        public string email{ get; set; }
        [Required]
        [Display(Name = "Vigente")]
        public bool vigente{ get; set; }
    }
}
