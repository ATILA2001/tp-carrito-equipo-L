using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dominio
{
        public class Articulo
    {
        private int id;
        private string codArticulo;
        private string nombre;
        private string descripcion;
        private Imagen imagen;
        private decimal precio;


        public int Id { get; set; }


        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public Imagen Imagen {  get; set; }
        public decimal Precio { get; set; }
        public Articulo() { }
        public Articulo(int Id, string CodigoArticulo, string Nombre, string Descripcion, Marca Marca, Categoria Categoria, Imagen Imagen, float Precio)
        {
            this.Id = Id;
            this.CodigoArticulo = CodigoArticulo;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Marca = Marca;
            this.Categoria = Categoria;
            this.Precio = (decimal)Precio;
            //this.Imagenes = new List<Imagen>();
            this.Imagenes.Add(Imagen);
        }

        public Articulo(int Id, string v, string text1, string text2, Marca marca, Categoria categoria, Imagen imagen, decimal value)
        {
            this.Id = Id;
            this.codArticulo = v;
            this.nombre = text1;
            this.descripcion = text2;
            Marca = marca;
            Categoria = categoria;
            this.imagen = imagen;
            this.precio = value;
        }
        public override string ToString()
        {
            return "Codigo: " + codArticulo + " Nombre: " + nombre + " Descripcion: " + descripcion + " Marca: " + Marca.ToString() + " Categoria :" + Categoria.ToString() + " Precio: " + precio;
        }

    }
}
