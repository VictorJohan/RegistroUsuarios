﻿using RegistroUsuario.BLL;
using RegistroUsuario.DAL;
using RegistroUsuario.Entidades;
using RegistroUsuario.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
        
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void RegistrosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rRegistroUsuarios rRegistroUsuarios = new rRegistroUsuarios();
            rRegistroUsuarios.Show();
        }
    }
}
