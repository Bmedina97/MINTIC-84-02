using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Inventario.App.Dominio.Entidades;
using Inventario.App.Persistencia.AppRepositorios;

namespace Inventario.App.Persistencia.AppRepositorios

{
    public interface IRepositorios
    {
        //contratos o firmas para los metodos Proveedor        
        Proveedor AddProveedor(Proveedor proveedor);
        IEnumerable<Proveedor> GetAllProveedores();         
        Proveedor GetProveedor(int? idProveedor);
        Proveedor UpdateProveedor(Proveedor proveedor);
        void DeleteProveedor(int idProveedor); 

    } //Fin IRepositorios
}
