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
    /// Логика взаимодействия для inf3.xaml
    /// </summary>
    public partial class inf3 : Page
    {
        public inf3()
        {
            InitializeComponent();
            DGridClients.ItemsSource = AdmSorskEntities.GetContext().SumInfo.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddPage3 addPage = new AddPage3((sender as Button).DataContext as SumInfo);
            addPage.Show();


        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            AddPage3 addPage = new AddPage3(null);
            addPage.ShowDialog();
            DGridClients.ItemsSource = AdmSorskEntities.GetContext().SumInfo.ToList();

        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientForRemoving = DGridClients.SelectedItems.Cast<SumInfo>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AdmSorskEntities.GetContext().SumInfo.RemoveRange(clientForRemoving);
                    AdmSorskEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGridClients.ItemsSource = AdmSorskEntities.GetContext().SumInfo.ToList();
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
                DGridClients.ItemsSource = AdmSorskEntities.GetContext().SumInfo.ToList();


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
            List<SumInfo> clients = AdmSorskEntities.GetContext().SumInfo.ToList();
            clients = clients.Where(z => z.ID.ToString().Contains(TxtLastName.Text.ToLower())).ToList();
            DGridClients.ItemsSource = clients;
        }


        private void TxtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}

