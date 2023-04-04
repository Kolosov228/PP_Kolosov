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
    /// Логика взаимодействия для AddPage3.xaml
    /// </summary>
    public partial class AddPage3 : Window
    {
        private SumInfo _currentsum = new SumInfo();
        public AddPage3(SumInfo selectedSum)
        {
            InitializeComponent();

            if (selectedSum != null)
                _currentsum = selectedSum;

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentsum.Description))
                errors.AppendLine("error");


            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentsum.ID == 0)
                AdmSorskEntities.GetContext().SumInfo.Add(_currentsum);

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
