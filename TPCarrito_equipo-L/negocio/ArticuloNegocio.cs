using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, C.Descripcion AS Categoria, C.Id, M.Descripcion AS Marca, M.Id, A.Precio, I.ImagenUrl AS Imagen FROM ARTICULOS A INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN IMAGENES AS I ON A.Id = I.IdArticulo");
                //datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl AS Imagen from ARTICULOS A inner join CATEGORIAS C on A.IdCategoria = c.Id inner join MARCAS M on A.IdMarca = M.Id inner join IMAGENES I on A.Id = I.IdArticulo");
                //datos.setearConsulta("select A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, A.IdMarca, A.IdCategoria, C.Descripcion AS Categoria, A.Precio, I.ImagenUrl AS Imagen from ARTICULOS A inner join CATEGORIAS C on A.IdCategoria = c.Id inner join MARCAS M on A.IdMarca = M.Id inner join IMAGENES I on A.Id = I.IdArticulo");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.Imagenes = new List<Imagen>();
                    Imagen iAux = new Imagen();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["Id"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["Id"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    iAux.Url = (string)datos.Lector["Imagen"];
                    aux.Imagenes.Add(iAux);
                    lista.Add(aux);
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
        public List<Articulo> listarConFiltro (decimal desde, decimal hasta, Marca marca, Categoria categoria)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS MARCAS, C.Descripcion AS CATEGORIAS, A.Precio FROM ARTICULOS AS A " +
                "INNER JOIN MARCAS AS M ON A.IdMarca = M.Id " +
                "INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id " +
                "WHERE A.IdCategoria = " + categoria.Id + " AND A.IdMarca = " + marca.Id + " AND A.Precio BETWEEN " + desde + " AND " + hasta);
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Marca = new Marca();
                    aux.Categoria = new Categoria();
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca.Descripcion = (string)datos.Lector["MARCAS"];
                    aux.Categoria.Descripcion = (string)datos.Lector["CATEGORIAS"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                
                return lista;
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
        public void agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO ARTICULOS(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) VALUES( @codigo,@nombre,@descripcion, @idMarca ,@idCategoria ,@idPrecio) ");
                datos.setearParametros("@codigo", art.CodigoArticulo);
                datos.setearParametros("@nombre", art.Nombre);
                datos.setearParametros("@descripcion", art.Descripcion);
                datos.setearParametros("@idMarca", art.Marca.Id);
                datos.setearParametros("@idCategoria", art.Categoria.Id);
                datos.setearParametros("@idPrecio", art.Precio);
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

        public void MaxId(Articulo art) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT MAX(Id) AS Id FROM ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    art.Id = (int)datos.Lector["Id"];
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }

        public void agregarImagen(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO IMAGENES(IdArticulo, ImagenUrl) VALUES(@IdArticulo, @ImagenUrl)");
                datos.setearParametros("@IdArticulo", art.Id);
                datos.setearParametros("@ImagenUrl", art.Imagen.Url);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion();}
        }

        public void eliminar(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS WHERE Id =@id");
                datos.setearParametros("@id", id);
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
        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio WHERE Id = @Id");
                datos.setearParametros("@Codigo", articulo.CodigoArticulo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@IdMarca", articulo.Marca.Id);
                datos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametros("@Precio", articulo.Precio);
                datos.setearParametros("@Id", articulo.Id);

                datos.ejecutarAccion();
            }
            catch (Exception Ex)
            {

                throw Ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
