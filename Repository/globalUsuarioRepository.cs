using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Models;
using static apiFactura.Models.Dto.globalUsuarioDTO;

namespace apiFactura.Repository
{
    public class globalUsuarioRepository
    {
        private readonly ExactusContext _context;
        public globalUsuarioRepository(ExactusContext context)
        {
            this._context=context;
        }
        public bool validaCredenciales(string Usuario, string Passowrd)
        {
            var data =_context.globalusuario
            .Where(a=>a.Usuario==Usuario && a.Password==Passowrd && a.Activo == true)
            .FirstOrDefault();

            if(data == null)
                return false;
            return true;
        }

        public infoUsuario obtenerUsuario(string usuario)
        {
            var data = _context.globalusuario.Where(w => w.Usuario.ToUpper()==usuario.ToUpper())
            .Select(s => new infoUsuario
            {
                Usuario = s.Usuario,
                Descr = s.Descr,
                Email=s.Email
            })
            .FirstOrDefault();

            if(data == null)
                return null!;
            return data;
        }
    }
}