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
using MySql.Data.MySqlClient;
using System.Data.Common;


namespace lab2_zar
{
     
    public partial class MainWindow : Window
    {
        //struct str
        //{
        //    public string id;
        //    public string familia;
        //    public string imya;
        //    public string otchestvo;
        //    public string rabota;
        //    public string zarplata;
        //}

        //MySqlConnection uwu;

        //List<str> kek()
        //{
        //    MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
        //    stringBuilder.Server = "localhost";
        //    stringBuilder.UserID = "root";
        //    stringBuilder.Database = "a1caida";
        //    stringBuilder.SslMode = MySqlSslMode.None;
        //    uwu = new MySqlConnection(stringBuilder.ConnectionString);

        //    MySqlCommand command = uwu.CreateCommand();
        //    command.CommandText = "SELECT uwu.id,`surname`, `name`, `otch`,`work`,`salary` FROM a1caida.uwu JOIN  a1caida.owo ON uwu.id_fio = owo.id";

        //    List<str> bd = new List<str>();

        //    try
        //    {
        //        uwu.Open();
        //        using (DbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                str databd = new str
        //                {
        //                    id = reader.GetString(0),
        //                    familia = reader.GetString(1),
        //                    imya = reader.GetString(2),
        //                    otchestvo = reader.GetString(3),
        //                    rabota = reader.GetString(4),
        //                    zarplata = reader.GetString(5),
        //                };
        //                bd.Add(databd);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return bd;

        //}
        //List<str> lol()
        //{
        //    MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();
        //    stringBuilder.Server = "localhost";
        //    stringBuilder.UserID = "root";
        //    stringBuilder.Database = "a1caida";
        //    stringBuilder.SslMode = MySqlSslMode.None;
        //    uwu = new MySqlConnection(stringBuilder.ConnectionString);

        //    MySqlCommand command = uwu.CreateCommand();
        //    command.CommandText = "SELECT `id`,`surname`, `name`, `otch` FROM a1caida.owo";

        //    List<str> bd = new List<str>();

        //    try
        //    {
        //        uwu.Open();
        //        using (DbDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                str databd = new str
        //                {
        //                    id = reader.GetString(0),
        //                    familia = reader.GetString(1),
        //                    imya = reader.GetString(2),
        //                    otchestvo = reader.GetString(3),        
        //                };
        //                bd.Add(databd);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    return bd;

        //}
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            db con = new db("127.0.0.1", "root", "", "a1caida");

            string surname = sur.Text;
            string name = Name.Text;
            string otches = otch.Text;

            if (con.insert(surname, name, otches) == -1)
            {
                MessageBox.Show("error");
            }
            else
            {
                MessageBox.Show("ok");
            }
        }

        private void vivodrab(object sender, RoutedEventArgs e)
        {
            db Kurisu = new db("127.0.0.1", "root", "", "a1caida");
            var Maki = Kurisu.kek();
            view.Text = "";
            foreach (var data in Maki)
            {
                view.Text += (data.id + " | " + data.familia.PadRight(15) + " | " + data.imya.PadRight(10) + " | " + data.otchestvo.PadRight(10) + " | " + data.rabota.PadRight(10) + " | " + data.zarplata.PadRight(10) + "\n");
            }
        }

        private void vivodfio(object sender, RoutedEventArgs e)
        {
            db Kurisu = new db("127.0.0.1", "root", "", "a1caida");
            var Maki = Kurisu.lol();
            view1.Text = "";
            foreach (var data in Maki)
            {
                view1.Text += (data.id + " | " + data.familia.PadRight(15) + " | " + data.imya.PadRight(10) + " | " + data.otchestvo.PadRight(10) + "\n");
            }
        }

        private void Naznach(object sender, RoutedEventArgs e)
        {
            db con = new db("127.0.0.1", "root", "", "a1caida");

            int id_fio = Convert.ToInt32(fio.Text);
            string workk = work.Text;
            int sala = Convert.ToInt32(salary.Text);

            if (con.insert(id_fio, workk, sala) == -1)
            {
                MessageBox.Show("error");
            }
            else
            {
                MessageBox.Show("ok");
            }

        }
        private void delete(object sender, RoutedEventArgs e)
        {
            db con = new db("127.0.0.1", "root", "", "a1caida");

            int id = Convert.ToInt32(fio_id.Text);
           
            if (con.delete(id) == -1)
            {
                MessageBox.Show("error");
            }
            else
            {
                MessageBox.Show("ok");
            }

        }
    }
}