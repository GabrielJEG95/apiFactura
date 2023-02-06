using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiFactura.Common.Util;

namespace apiFactura.Services
{
    public interface InumeroLetraService
    {
        string numeroLetra(decimal monto);
    }

    public class numeroLetraService:InumeroLetraService
    {
        private numeroALetras _numLetra;
        public numeroLetraService()
        {
            this._numLetra = new numeroALetras();
        }

        public string numeroLetra(decimal monto)
        {
            string numero = _numLetra.NumeroALetras(monto);
            return numero;
        }
    }
}