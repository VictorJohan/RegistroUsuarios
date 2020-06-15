using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroUsuario.Entidades;
using RegistroUsuario.BLL;
using System.Text.RegularExpressions;

namespace RegistroUsuario.UI
{
    /// <summary>
    /// Interaction logic for rRegistroUsuarios.xaml
    /// </summary>
    public partial class rRegistroUsuarios : Window
    {
        private Usuarios Usuario = new Usuarios();
        public rRegistroUsuarios()
        {
            InitializeComponent();
            this.DataContext = Usuario;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuario = UsuariosBLL.Buscar(idUsuarioTextBox.Text);

            if (Usuario != null)
            {
                this.Usuario = usuario;
            }
            else
            {
                this.Usuario = new Usuarios();
            }

            this.DataContext = this.Usuario;

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
            {
                return;
            }

            if (UsuariosBLL.Guardar(Usuario))
            {
                MessageBox.Show("Guardar.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(idUsuarioTextBox.Text))
            {
                MessageBox.Show("Eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Es posible que este registro no exista.", "Error.", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            Limpiar();
        }

        public void Limpiar()
        {
            this.Usuario = new Usuarios();
            this.DataContext = this.Usuario;
            ConfirmarClavePasswordBox.Password = "";

        }

        public bool Validar()
        {

            if(ClavePasswordBox.Password != ConfirmarClavePasswordBox.Password)
            {
                MessageBox.Show("Asegurese de que ambas claves sean iguales", "Las claves no coinciden.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!Regex.IsMatch(nombreTextBox.Text, @"^[A-Za-z- ]+$"))
            {
                MessageBox.Show("Asegurese de haber ingresado un nombre valido.", "Nombre no valido.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }

            return true;
        }
    }
}
