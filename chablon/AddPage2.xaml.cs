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
    /// Логика взаимодействия для AddPage2.xaml
    /// </summary>
    public partial class AddPage2 : Window
    {
        private Departament _currentclient = new Departament();
        public AddPage2(Departament selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentclient = selectedClient;

            
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentclient.Name))
                errors.AppendLine("error");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentclient.ID == 0)
                AdmSorskEntities.GetContext().Departament.Add(_currentclient);

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
