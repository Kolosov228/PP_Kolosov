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

namespace chablon
{
    /// <summary>
    /// Логика взаимодействия для InfBruh2.xaml
    /// </summary>
    public partial class InfBruh2 : Page
    {
        public InfBruh2()
        {
            InitializeComponent();
            DGridClients.ItemsSource = AdmSorskEntities.GetContext().Employees.ToList();
            DGridClients.ItemsSource = AdmSorskEntities.GetContext().Departament.ToList();




        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddPage addPage = new AddPage((sender as Button).DataContext as Employees);
            addPage.Show();


        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            AddPage addPage = new AddPage(null);
            addPage.ShowDialog();
            DGridClients.ItemsSource = AdmSorskEntities.GetContext().Employees.ToList();

        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = DGridClients.SelectedItems.Cast<Employees>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AdmSorskEntities.GetContext().Employees.RemoveRange(clientForRemoving);
                    AdmSorskEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridClients.ItemsSource = AdmSorskEntities.GetContext().Employees.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {

                AdmSorskEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridClients.ItemsSource = AdmSorskEntities.GetContext().Employees.ToList();


            }

        }

        private void CmbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }



        private void TxtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        public void Filter()
        {
            List<Departament> clients = AdmSorskEntities.GetContext().Departament.ToList();
            clients = clients.Where(z => z.Name.ToLower().Contains(TxtLastName.Text.ToLower())).ToList();
            DGridClients.ItemsSource = clients;
        }


        private void TxtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}
