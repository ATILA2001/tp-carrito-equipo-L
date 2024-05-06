using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Imagen
    {
        public int Id { get; set; }

        public string NombreArticulo { get; set; }

        public string Url { get; set; }
        public Imagen() { }
        public Imagen(int Id, string Url, string nombreArticulo)
        {
            this.Id = Id;
            this.Url = Url;
            NombreArticulo = nombreArticulo;    
        }
        public override string ToString()
        {
            return Url;
        }

    }
}
