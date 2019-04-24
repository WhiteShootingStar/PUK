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
using System.Windows.Shapes;
using TestPrepare.DBConnection;

public interface Iint
{
    void addAnimal(Animal animal);
}
namespace TestPrepare
{
    /// <summary>
    /// Логика взаимодействия для AddWindowxaml.xaml
    /// </summary>
    public partial class AddWindowxaml : Window
    {
        Iint wind;
        List<Owner> owners;
        List<AnimalType> animalTypes;
        public AddWindowxaml(Iint window, List<Owner> owners, List<AnimalType> animalTypes)
        {
            InitializeComponent();
            wind = window;
            this.animalTypes = animalTypes;
            this.owners = owners;
            CBOwner.ItemsSource = owners;
            CBType.ItemsSource = animalTypes;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CBType.SelectedItem != null && CBOwner.SelectedItem != null && TB.Text != null)
            {
                Animal animal = new Animal { AnimalType = (AnimalType)CBType.SelectedItem, Name = TB.Text, Owner = (Owner)CBOwner.SelectedItem, IdAnimalType = ((AnimalType)CBType.SelectedItem).IdAnimalType, IdOwner = ((Owner)CBOwner.SelectedItem).IdOwner };
                wind.addAnimal(animal);
                Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
