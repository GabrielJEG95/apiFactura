using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;

namespace apiFactura.Repository
{
    public class UsuarioSucursalRepository
    {
        private readonly ExactusContext _context;
        public UsuarioSucursalRepository(ExactusContext context)
        {
            this._context = context;
        }

        public List<string> obtenerUsuarioSucursal(string usuario)
        {
            var usuarioSucursal = _context.UsuarioSucursal.
            Where(w => w.IdUsuario.ToUpper() == usuario.ToUpper())
            .Select(s =>
                s.CodSucursal
            )
            .ToList();

            if(usuarioSucursal == null)
                return null;
            return usuarioSucursal;
        }
    }
}