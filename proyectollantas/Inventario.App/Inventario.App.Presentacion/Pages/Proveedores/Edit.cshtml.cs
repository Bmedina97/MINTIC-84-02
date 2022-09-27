using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyectos.App.Dominio.Entidades;

namespace Proyectos.App.Presentacion.Proveedores

{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Proveedor proveedor { get; set; }
        public async Task OnGet(int pro_id)
        {
            //aqui traer x debcontext de la base de datos
            Proveedor proveedor = new Proveedor();
        }

        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid) {
                //buscar por el id y cargar los datos
                proveedor.pro_id = 2;
                proveedor.pro_nit = "traidos";
                proveedor.pro_nombre = "nombre temporal para traer";
                proveedor.pro_direccion = "direccion temporal para traer";
                proveedor.pro_telefono = "telefono temporal para traer";
                proveedor.pro_email = "emailtemporal@gmail.com";
                proveedor.pro_vigente = true;
                //guardar los cambios x dbcontext
                return RedirectToPage("List");
            }
            return RedirectToPage();
        }
    }
}
