using KN_Web.BaseDatos;
using KN_Web.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace KN_Web.Models
{
    public class UsuarioModel
    {
        public bool RegistrarUsuario(Usuario user)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.RegistrarUsuario(user.Identificacion, user.Nombre, user.Correo, user.Contrasenna);
            } 

            return (rowsAffected > 0 ? true : false);
        }

        public IniciarSesion_Result IniciarSesion(Usuario user)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.IniciarSesion(user.Correo, user.Contrasenna).FirstOrDefault();
            }
        }

        public List<tUsuario> ConsultarUsuarios()
        {
            using (var context = new MARTES_BDEntities1())
            {
                int ConsecutivoSesion = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());

                return (from x in context.tUsuario
                        where x.Consecutivo != ConsecutivoSesion
                        select x).ToList();
            }
        }

        public tUsuario ConsultarUsuarioConsecutivo(int Consecutivo)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return (from x in context.tUsuario
                        where x.Consecutivo == Consecutivo
                        select x).FirstOrDefault();
            }
        }

        public ValidarUsuarioIdentificacion_Result ConsultarUsuarioIdentificacion(string Identificacion)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.ValidarUsuarioIdentificacion(Identificacion).FirstOrDefault();
            }
        }

        public bool CambiarEstadoUsuario(Usuario user)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.CambiarEstadoUsuario(user.Consecutivo);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool ActualizarUsuario(Usuario user)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.ActualizarUsuario(user.Identificacion, user.Nombre, user.Correo, user.IdRol, user.Consecutivo);
            }

            return (rowsAffected > 0 ? true : false);
        }

        public bool CambiarContrasennaUsuario(int Consecutivo, string contrasennaTemporal, bool EsClaveTemporal, DateTime ClaveVencimiento)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                var datos = (from x in context.tUsuario
                             where x.Consecutivo == Consecutivo
                             select x).FirstOrDefault();

                datos.Contrasenna = contrasennaTemporal;
                datos.EsClaveTemporal = EsClaveTemporal;
                datos.ClaveVencimiento = ClaveVencimiento;
                rowsAffected = context.SaveChanges();
            }

            return (rowsAffected > 0 ? true : false);
        }

        public Usuario ConsultarUsuarioPorID(int consecutivo)
        {
            using (var contexto = new MARTES_BDEntities1())
            {
                var tUsuario = contexto.tUsuario.FirstOrDefault(u => u.Consecutivo == consecutivo && u.Estado == true);

                if (tUsuario != null)
                {
                    return new Usuario
                    {
                        Consecutivo = tUsuario.Consecutivo,
                        Identificacion = tUsuario.Identificacion,
                        Nombre = tUsuario.Nombre,
                        Correo = tUsuario.Correo,
                        Estado = tUsuario.Estado,
                        IdRol = tUsuario.IdRol,
                    };
                }

                return null;
            }
        }

        public bool EliminarUsuario(int consecutivo)
        {
            var rowsAffected = 0;
            using (var context = new MARTES_BDEntities1())
            {
                var usuario = (from x in context.tUsuario
                               where x.Consecutivo == consecutivo
                               select x).FirstOrDefault();

                if (usuario != null && usuario.IdRol != 2)
                {
                    context.tUsuario.Remove(usuario);
                    rowsAffected = context.SaveChanges();
                }
            }
            return (rowsAffected > 0);
        }

        public bool EliminarUsuarioCliente(int consecutivo)
        {
            try
            {
                using (var db = new MARTES_BDEntities1())
                {
                    var usuario = db.tUsuario.Find(consecutivo);
                    if (usuario != null)
                    {
                        db.tUsuario.Remove(usuario);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public List<tMaestro> ObtenerPedidosPorUsuario(int idUsuario)
        {
            using (var context = new MARTES_BDEntities1())
            {
                return context.tMaestro
                    .Where(m => m.Consecutivo == idUsuario)
                    .ToList();
            }
        }
    }
}
