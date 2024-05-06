using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
       public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select I.ImagenUrl as Url ,I.IdArticulo as Imagen, A.Nombre as ARTICULOS from IMAGENES I inner join ARTICULOS A ON I.IdArticulo = A.Id");
                datos.ejecutarLectura();

                

                while (datos.Lector.Read())
                {
                    Imagen imagen = new Imagen();
                    imagen.Url = (string)datos.Lector["Url"];
                    imagen.Id = (int)datos.Lector["Imagen"];
                    imagen.NombreArticulo = (string)datos.Lector["ARTICULOS"];
                    
                    lista.Add(imagen);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                datos.cerrarConexion();
            }

        }
        public string searchId(string codArt)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string Id;
                datos.setearConsulta("SELECT A.Id FROM ARTICULOS AS A WHERE A.Codigo = '" + codArt + "'");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Id = datos.Lector["Id"].ToString();
                }
                else
                {
                    Id = "0";
                }
                return Id;  
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { datos.cerrarConexion();}

        }
        public void agregar(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @Imagen)");
                datos.setearParametros("@idArticulo", imagen.Id);
                datos.setearParametros("@Imagen", imagen.Url);
                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally 
            { 
                datos.cerrarConexion(); 
            }
        }
    }
}
