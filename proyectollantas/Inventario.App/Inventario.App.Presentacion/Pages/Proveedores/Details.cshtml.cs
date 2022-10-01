using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyectos.App.Dominio.Entidades;
/*using Proyectos.App.Persistencia.AppRepositorios;
using Proyectos.App.Persistencia;*/

namespace Proyectos.App.Presentacion.Pages.Proveedores

{
    public class DetailsModel : PageModel

    {
       //private readonly IRepositorios _appContext;

        [BindProperty]
        public Proveedor proveedor  { get; set; } 
        
        public void OnGet()
            //aqui traer x debcontext de la base de datos
            {
                proveedor = new Proveedor{
                    id = 2,
                    nit = "traidos",
                    nombre = "nombre temporal para traer",
                    direccion = "direccion temporal para traer",
                    telefono = "telefono temporal para traer",
                    email = "emailtemporal@gmail.com",
                    vigente = true
                };
            }

        /*public DetailsModel()
        {            
            this._appContext = new Repositorios(new Proyectos.App.Persistencia.AppContext());

        //se ejecuta al presionar Editar en la lista
        public IActionResult OnGet(int? proveedorId)
        {
            if (proveedorId.HasValue)
            {
                proveedor = _appContext.GetProveedor(proveedorId.Value);
            }
            if (proveedor == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }*/
    }
}