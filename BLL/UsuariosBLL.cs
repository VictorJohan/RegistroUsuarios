using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RegistroUsuario.DAL;
using RegistroUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace RegistroUsuario.BLL
{
    class UsuariosBLL
    {
        public static bool Guardar(Usuarios usuario)
        {
            if (!Existe(usuario.IdUsuario))
            {
                return Insertar(usuario);
            }
            else
            {
                return Modificar(usuario);
            }
        }

        public static bool Existe(string id)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                ok = contexto.Usuarios.Any(e => e.IdUsuario == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Usuarios usuario)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Usuarios.Add(usuario);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Usuarios usuario)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ok;
        }

        public static Usuarios Buscar(string id)
        {
            Usuarios usuario;
            Contexto contexto = new Contexto();

            try
            {
                usuario = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return usuario;
        }

        public static bool Eliminar(string id)
        {
            Contexto contexto = new Contexto();
            bool ok = false;

            try
            {
                var usuario = contexto.Usuarios.Find(id);
                if (usuario != null)
                {
                    contexto.Usuarios.Remove(usuario);
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }
    }
}
