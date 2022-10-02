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
    //[Authorize]
    public class ListModel : PageModel
    {
        private readonly IRepositorios _appContext;
        public IEnumerable<Proveedor> proveedores {get; set;}         

        public ListModel()
        {
            this._appContext = new Repositorios(new Inventario.App.Persistencia.AppContext());
        }
       
        public void OnGet()
        {
            proveedores = _appContext.GetAllProveedores();
        }
        
    }
}


