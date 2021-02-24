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
using System.Data;



namespace lab2_zar
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            kostil();            
        }

        private void kostil()
        {
            db con = new db("127.0.0.1", "root", "", "a1caida");

            remove_id.ItemsSource = con.getTableInfo("SELECT  uwu.id,  `surname` FROM `uwu` join `owo` on `id_fio` = owo.id").AsDataView();
            add_id.ItemsSource = con.getTableInfo("SELECT id,  surname FROM owo").AsDataView();
        }
        private void Register(object sender, RoutedEventArgs e)
        {

            db con = new db("127.0.0.1", "root", "", "a1caida");
            //kostil();
            string surname = sur.Text;
            string name = Name.Text;
            string otches = otch.Text;

            if (con.insert(surname, name, otches) == -1)
            {
                MessageBox.Show("error");
                kostil();
            }
            else
            {
                MessageBox.Show("ok");
                kostil();
            }
        }

        private void vivodrab(object sender, RoutedEventArgs e)
        {
            db Kurisu = new db("127.0.0.1", "root", "", "a1caida");
            // kostil();
            int id = Convert.ToInt32(add_id.SelectedValue);
            var Maki = Kurisu.kek(id);
            view.Text = "";
            foreach (var data in Maki)
            {
                view.Text += (data.id + " | " + data.familia.PadRight(15) + " | " + data.imya.PadRight(10) + " | " + data.otchestvo.PadRight(10) + " | " + data.rabota.PadRight(10) + " | " + data.zarplata.PadRight(10) + "\n");
            }
            var Rikka = Kurisu.Kurisutina();
            view3.Text = "";
            foreach (var data in Rikka)
            {
                view3.Text += (data.id + " | " + data.familia.PadRight(15) + " | " + data.imya.PadRight(10) + " | " + data.otchestvo.PadRight(10) + " | " + data.rabota.PadRight(10) + " | " + data.zarplata.PadRight(10) + "\n");
            }
            kostil();
        }

        private void vivodfio(object sender, RoutedEventArgs e)
        {
            db Kurisu = new db("127.0.0.1", "root", "", "a1caida");
            //kostil();
           
            var Maki = Kurisu.lol();
            view1.Text = "";
            foreach (var data in Maki)
            {
                view1.Text += (data.id + " | " + data.familia.PadRight(15) + " | " + data.imya.PadRight(10) + " | " + data.otchestvo.PadRight(10) + "\n");
            }
            kostil();
        }

        private void Naznach(object sender, RoutedEventArgs e)
        {
            db con = new db("127.0.0.1", "root", "", "a1caida");
            //kostil();
            int id_fio = Convert.ToInt32(add_id.SelectedValue);
            string workk = work.Text;
            int sala = Convert.ToInt32(salary.Text);

            if (con.insert(id_fio, workk, sala) == -1)
            {
                MessageBox.Show("error");
                kostil();
            }
            else
            {
                MessageBox.Show("ok");
                kostil();
            }

        }
        private void delete(object sender, RoutedEventArgs e)
        {
            db con = new db("127.0.0.1", "root", "", "a1caida");
            //kostil();
            int id = Convert.ToInt32(remove_id.SelectedValue);
           
            if (con.delete(id) == -1)
            {
                MessageBox.Show("error");
                kostil();
            }
            else
            {
                MessageBox.Show("ok");
                kostil();
            }

        }
    }
}
