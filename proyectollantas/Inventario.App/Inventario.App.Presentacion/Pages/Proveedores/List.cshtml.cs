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
                new Proveedor{pro_id=1, pro_nit="102030", pro_nombre="Jhon Jairo Orozco", pro_direccion="CLL 1", pro_telefono="cel1", pro_email="01@xx", pro_vigente=true},
                new Proveedor{pro_id=2, pro_nit="304050", pro_nombre="Luz Dary Martinez", pro_direccion="CLL 2", pro_telefono="cel2", pro_email="02@xx", pro_vigente=true},
                new Proveedor{pro_id=3, pro_nit="607080", pro_nombre="Mateo Orozco", pro_direccion="CLL 3", pro_telefono="cel3", pro_email="03@xx", pro_vigente=true},
                new Proveedor{pro_id=4, pro_nit="901020", pro_nombre="Mario Enrique Montoya", pro_direccion="CLL 4", pro_telefono="cel4", pro_email="04@xx", pro_vigente=true}
            };
        }
    }
}

