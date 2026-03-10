using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Demo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Entityes.DemoEntities Context 
        { get; } = new Entityes.DemoEntities();

        public static Entityes.User CurrentUser = null;
    }
}
