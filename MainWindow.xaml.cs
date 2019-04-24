using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using TestPrepare.DBConnection;

namespace TestPrepare
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,Iint
    {
        Database database;
        public MainWindow()
        {
            InitializeComponent();
            database = new Database();
            //var list = database.Animal.Join(database.Animal,anim=>anim.IdAnimal)
            Grid.ItemsSource = database.Animal.ToList();
        }

        public void addAnimal(Animal animal)
        {
            database.Animal.Add(animal);
            database.SaveChanges();
            Grid.ItemsSource = database.Animal.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var AT = database.AnimalType.ToList();
            var Owners = database.Owner.ToList();
            (new AddWindowxaml(this, Owners, AT)).ShowDialog();
        }
    }
}
