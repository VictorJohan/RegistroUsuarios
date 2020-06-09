using RegistroUsuario.BLL;
using RegistroUsuario.DAL;
using RegistroUsuario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegistroUsuario
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Usuarios Usuario = new Usuarios();
        public MainWindow()
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

            Usuario.Clave = clavePasswordBox.Text;

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

        }

        public bool Validar()
        {

            if (!Regex.IsMatch(nombreTextBox.Text, @"^[A-Za-z]+$"))
            {
                MessageBox.Show("Asegurese de haber ingresado un nombre valido.", "Nombre no valido.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }

            return true;
        }
    }
}
