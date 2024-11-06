using KrylovaShelter.Model;
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

namespace KrylovaShelter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            JournalLv.ItemsSource = App.context.Journal.ToList();

            ViewAnimalCmb.SelectedValuePath = "Id";
            ViewAnimalCmb.DisplayMemberPath = "Name";
            ViewAnimalCmb.ItemsSource = App.context.ViewAnimal.ToList();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(DateStartDp.Text) || string.IsNullOrEmpty(ViewAnimalCmb.Text) || string.IsNullOrEmpty(NameAnimalTb.Text) || string.IsNullOrEmpty(AgeTb.Text) || string.IsNullOrEmpty(DateEndDp.Text))
            {
                MessageBox.Show("Заполните все данные!");
            }
            else
            {
                Journal journal = new Journal()
                {
                    DateStart = (DateTime)DateStartDp.SelectedDate,
                    ViewAnimal = ViewAnimalCmb.SelectedItem as ViewAnimal,
                    Name = NameAnimalTb.Text,
                    Pasport = Convert.ToBoolean(PasportCb.IsChecked),
                    Age = Convert.ToInt32(AgeTb.Text),
                    Service = ServiceTb.Text,
                    DateEnd = Convert.ToDateTime(DateEndDp.Text)
                };

                App.context.Journal.Add(journal);
                App.context.SaveChanges();
                MessageBox.Show("Добавлено!");

                DateStartDp.Text = "";
                ViewAnimalCmb.Text = "";
                NameAnimalTb.Text = "";
                PasportCb.IsChecked = false;
                AgeTb.Text = "";
                ServiceTb.Text = "";
                DateEndDp.Text = "";
               
                JournalLv.ItemsSource = App.context.Journal.ToList();
            }
        }
    }
}
