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
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Page
    {
        public Students()
        {
            InitializeComponent();
            LoadGroupList();
        }

        private void comboboxgroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LoadGroupList()
        {
            db.base08Entities connection = new db.base08Entities();

            var grouplist = connection.группа.ToList();
            foreach (var group in grouplist)
            {
                comboboxgroup.Items.Add(group.id_group);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string studentFname = textboxFirst.Text;
            string studentid = textboxID.Text;
            string studentSName = textboxSec.Text;
            if (textboxFirst.Text.Length == 0)
            {
                MessageBox.Show("Необходимо ввести имя студента");
                return;
            }
            if (textboxSec.Text.Length == 0)
            {
                MessageBox.Show("Небходимо ввести фамилию");
                return;
            }
            if (textboxSec.Text.Length == 0 && textboxFirst.Text.Length == 0)
            {
                MessageBox.Show("Небходимо ввести имя и фамилию");
                return;
            }
            db.base08Entities connection = new db.base08Entities();
            int d = int.Parse(studentid);
            db.student group = new db.student();

            db.student isExistsID = connection.student.Where(g => g.idstudent == d).FirstOrDefault();
            if (isExistsID != null)
            {
                MessageBox.Show("Студент с таким id уже существует");
            }
            group.idstudent = d;
            group.name_student = studentFname;
            group.second_name = studentSName;
            group.id_group = (int)comboboxgroup.SelectedItem;
            connection.student.Add(group);
            try
            {
                MessageBox.Show("Ошибка");
            }
            catch
            {
                int result = connection.SaveChanges();
                if (result == 1)
                {
                    textboxFirst.Text = "";
                    textboxSec.Text = "";
                    textboxID.Text = "";
                    MessageBox.Show("Группа успешно добавлена");
                }
            }
        }
        }
    }
