using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyectos.App.Dominio.Entidades;

namespace Proyectos.App.Presentacion.Proveedores

{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Proveedor proveedor { get; set; }

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


        /*public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                //buscar por el id y cargar los datos
                id = 2;
                nit = "traidos";
                nombre = "nombre temporal para traer";
                direccion = "direccion temporal para traer";
                telefono = "telefono temporal para traer";
                email = "emailtemporal@gmail.com";
                vigente = true;
                //guardar los cambios x dbcontext
                return RedirectToPage("List");
            }
            return RedirectToPage();
        }*/
    }
}