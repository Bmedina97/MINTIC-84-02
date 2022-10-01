using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyectos.App.Dominio.Entidades;

namespace Proyectos.App.Presentacion.Pages.Proveedores

{
    public class ListModel : PageModel
    {   
        public IEnumerable<Proveedor> proveedores { get; set; }
        public ListModel(){
            cargarTemporales();
        }

        public async Task OnGet()
        {
            cargarTemporales();
            //proveedores = await _contexto.Proveedor.ToListAsync();            
        }

        public void cargarTemporales(){
            proveedores = new List<Proveedor>()
            {
                new Proveedor{id=1, nit="102030", nombre="Jhon Jairo Orozco", direccion="CLL 1", telefono="cel1", email="01@xx", vigente=true},
                new Proveedor{id=2, nit="304050", nombre="Luz Dary Martinez", direccion="CLL 2", telefono="cel2", email="02@xx", vigente=true},
                new Proveedor{id=3, nit="607080", nombre="Mateo Orozco", direccion="CLL 3", telefono="cel3", email="03@xx", vigente=true},
                new Proveedor{id=4, nit="901020", nombre="Mario Enrique Montoya", direccion="CLL 4", telefono="cel4", email="04@xx", vigente=true}
            };
        }
    }
}

