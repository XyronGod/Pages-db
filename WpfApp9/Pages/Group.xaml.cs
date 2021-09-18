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

namespace WpfApp9.Pages
{
    /// <summary>
    /// Логика взаимодействия для Group.xaml
    /// </summary>
    public partial class Group : Page
    {
        public Group()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string groupNumber = textboxgroup.Text;
            if (groupNumber.Length == 0)
            {
                MessageBox.Show("Необходимо ввести номер группы");
                return;
            }
            db.base08Entities connection = new db.base08Entities();
            int d = int.Parse(groupNumber);
            db.группа isExist = connection.группа
            .Where(global => global.id_group == d)
                .FirstOrDefault();
            if (isExist != null)
            {
                MessageBox.Show("Группы с таким номером уже существуют");
            }
            db.группа group = new db.группа();
            group.id_group = d;
            connection.группа.Add(group);
            int result = connection.SaveChanges();
            if (result == 1)
            {
                textboxgroup.Text = "";
                MessageBox.Show("Группа успешно добавлена");
            }
        }

        private void LoadGroupList()
        {
            db.base08Entities connection = new db.base08Entities();

            var grouplist = connection.группа.ToList();
        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void textboxgroup_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
