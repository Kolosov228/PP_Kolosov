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

namespace chablon
{
    /// <summary>
    /// Логика взаимодействия для AddPage.xaml
    /// </summary>
    public partial class AddPage : Window
    {
        private Employees _currentclient = new Employees();
        private SumInfo _currentsum = new SumInfo();
        public AddPage(Employees selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentclient = selectedClient;

            DataContext = _currentclient;
            ComboGender.ItemsSource = AdmSorskEntities.GetContext().Departament.ToList();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentclient.Patronymic))
                errors.AppendLine("error");
           

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentclient.ID == 0)
                AdmSorskEntities.GetContext().Employees.Add(_currentclient);

            try
            {
                AdmSorskEntities.GetContext().SaveChanges();
                MessageBox.Show("информация сохранена");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
