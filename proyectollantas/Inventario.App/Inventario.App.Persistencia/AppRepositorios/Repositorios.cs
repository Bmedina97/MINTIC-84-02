using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Inventario.App.Dominio.Entidades;

namespace Inventario.App.Persistencia.AppRepositorios

{
    public class Repositorios : IRepositorios
    {
        private readonly AppContext _appContext;
        public IEnumerable<Proveedor> proveedores {get; set;} 
        
        public Repositorios(AppContext appContext)
        {
            _appContext = appContext;
        }
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
         //SIGUIENTE DIAPOSITIVA

        Proveedor IRepositorios.AddProveedor(Proveedor proveedor)
        {
        try
         {
            var ProveedorAdicionado = _appContext.proveedor.Add( proveedor );  //INSERT en la BD
            _appContext.SaveChanges();                  
            return ProveedorAdicionado.Entity;
          }catch
            {
                throw;
            }
        }

        IEnumerable<Proveedor> IRepositorios.GetAllProveedores()
        {
            return _appContext.proveedor;
        }

       Proveedor IRepositorios.GetProveedor(int? idProveedor)
       {
            return _appContext.proveedor.FirstOrDefault(p => p.id == idProveedor);
       }

       Proveedor IRepositorios.UpdateProveedor(Proveedor proveedor)
        {
            var ProveedorEncontrado = _appContext.proveedor.FirstOrDefault(p => p.id == proveedor.id);
            if (ProveedorEncontrado != null)
            {
                ProveedorEncontrado.nit = proveedor.nit;
                ProveedorEncontrado.nombre = proveedor.nombre;
                ProveedorEncontrado.direccion = proveedor.direccion;
                ProveedorEncontrado.telefono = proveedor.telefono;
		        ProveedorEncontrado.email = proveedor.email;
                ProveedorEncontrado.vigente = proveedor.vigente;
                _appContext.SaveChanges();
            }
            return ProveedorEncontrado;
        }

        void IRepositorios.DeleteProveedor(int idProveedor)
        {
            var ProveedorEncontrado = _appContext.proveedor.FirstOrDefault(p => p.id == idProveedor);
            if (ProveedorEncontrado == null)
                return;
            _appContext.proveedor.Remove(ProveedorEncontrado);
            _appContext.SaveChanges();
        }

    }
}

