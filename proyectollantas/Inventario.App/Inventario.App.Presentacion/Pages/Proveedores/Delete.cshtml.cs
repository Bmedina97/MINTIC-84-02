using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Inventario.App.Dominio.Entidades;
using Inventario.App.Persistencia.AppRepositorios;
using Inventario.App.Persistencia;

namespace Inventario.App.Presentacion.Proveedores
{
    public class DeleteModel : PageModel
    {
       private readonly IRepositorios _appContext;

        [BindProperty]
        public Proveedor proveedor  { get; set; } 

        public DeleteModel()
        {            
            this._appContext = new Repositorios(new Inventario.App.Persistencia.AppContext());
        }
     

        //se ejecuta al presionar Eliminar en la lista
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
        }

        //se ejecuta al presionar Eliminar en el formulario
        public IActionResult OnPost()
        {
            if(proveedor.id > 0)
            {     
               _appContext.DeleteProveedor(proveedor.id);           
            }
            return Redirect("List");
        }
    }
}