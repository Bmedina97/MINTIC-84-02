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
    public class DetailsModel : PageModel
    {
       private readonly IRepositorios _appContext;

        [BindProperty]
        public Proveedor proveedor  { get; set; } 

        public DetailsModel()
        {            
            this._appContext = new Repositorios(new Inventario.App.Persistencia.AppContext());
        }
     

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

        }
    }
}