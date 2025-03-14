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

            //var tabla = new tUsuario();
            //tabla.Identificacion = user.Identificacion;
            //tabla.Nombre = user.Nombre;
            //tabla.Correo = user.Correo;
            //tabla.Contrasenna = user.Contrasenna;
            //tabla.Estado = true;
            //tabla.IdRol = 1;

            //using (var context = new MARTES_BDEntities())
            //{
            //    context.tUsuario.Add(tabla);
            //    rowsAffected = context.SaveChanges();
            //}

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.RegistrarUsuario(user.Identificacion, user.Nombre, user.Correo, user.Contrasenna);
            } 

            return (rowsAffected > 0 ? true : false);
        }

        public IniciarSesion_Result IniciarSesion(Usuario user)
        {
            //using (var context = new MARTES_BDEntities())
            //{
            //    rowsCount = (from x in context.tUsuario
            //                     where x.Correo == user.Correo
            //                     && x.Contrasenna == user.Contrasenna
            //                     && x.Estado == true
            //                     select x).ToList().Count();
            //}

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

            //using (var context = new MARTES_BDEntities())
            //{
            //    var datos = (from x in context.tUsuario
            //                 where x.Consecutivo == user.Consecutivo
            //                 select x).FirstOrDefault();

            //    datos.Estado = false;
            //    rowsAffected = context.SaveChanges();
            //}

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

        public bool EliminarUsuario(int consecutivo)
        {
            var rowsAffected = 0;

            using (var context = new MARTES_BDEntities1())
            {
                rowsAffected = context.EliminarUsuarios(consecutivo);
            }

            return (rowsAffected > 0);
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
    }
}