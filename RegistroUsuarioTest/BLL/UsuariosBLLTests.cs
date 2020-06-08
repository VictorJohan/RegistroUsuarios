using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroUsuario.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroUsuario.Entidades;

namespace RegistroUsuario.BLL.Tests
{
    [TestClass()]
    public class UsuariosBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Usuarios usuario = new Usuarios();

            usuario.IdUsuario = "1";
            usuario.Nombre = "johan";
            usuario.Clave = "123";

            Assert.IsTrue(UsuariosBLL.Guardar(usuario));
        }

        [TestMethod()]
        public void ExisteTest()
        {
            Assert.IsTrue(UsuariosBLL.Existe("1"));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.IsTrue(UsuariosBLL.Buscar("1") != null);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.IsTrue(UsuariosBLL.Eliminar("1"));
        }
    }
}