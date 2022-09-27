using System.ComponentModel.DataAnnotations;

namespace Proyectos.App.Dominio.Entidades

{
    public class Proveedor
    {
        //atributos de la clase Proveedor
        [Key]
        [Display(Name = "Id")]
        public int pro_id { get; set; }
        [Required]        
        [Display(Name = "Nit")]
        public string pro_nit{ get; set; }
        [Required]        
        [Display(Name = "Nombre del Proveedor")]
        public string pro_nombre{ get; set; }
        [Required]
        [Display(Name = "Direccion")]
        public string pro_direccion{ get; set; }
        [Required]                   
        [Display(Name = "Telefono")]
        public string pro_telefono{ get; set; }
        [Required]        
        [Display(Name = "Correo electronico")]
        public string pro_email{ get; set; }
        [Required]
        public bool pro_vigente{ get; set; }
    }
}
