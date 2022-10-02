using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

using Inventario.App.Dominio.Entidades;
using Inventario.App.Persistencia.AppRepositorios;
using Inventario.App.Persistencia;

namespace Inventario.App.Presentacion.Proveedores

{

    public class CrearModel : PageModel
    {
        private readonly IRepositorios _appContext;
        [BindProperty]
        public Proveedor proveedor { get; set; }

        public CrearModel(){
            //cargar desde la base de datos tabla proveedor
            this._appContext = new Repositorios(new Inventario.App.Persistencia.AppContext());
            //cargarTemporales();
        }
    

        public IActionResult OnGet(int? proveedorId)
        {
            if (proveedorId.HasValue)
            {
                proveedor = _appContext.GetProveedor(proveedorId.Value);
            }
            else
            {
                proveedor = new Proveedor();
            }
            if (proveedor == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(proveedor.id > 0)
            {
            proveedor = _appContext.UpdateProveedor(proveedor);
            }
            else
            {
                //proveedor.vigente = true;
            _appContext.AddProveedor(proveedor);
            }
            return Redirect("List");
        }
    }
}
