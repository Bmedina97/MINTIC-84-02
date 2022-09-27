using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyectos.App.Dominio.Entidades;

namespace Proyectos.App.Presentacion.Proveedores

{
    
    public class CrearModel : PageModel
    {
        [BindProperty]
        public Proveedor proveedor { get; set; }
        public void OnGet()
        {
        
        }

        public async Task<ActionResult> OnPost()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
            proveedor.pro_vigente = true;

            //aqui debcontext y guardar el registro
            return RedirectToPage();
        }
    }
}
