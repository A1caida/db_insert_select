using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Data;

namespace lab2_zar
{
    class db
    {
        MySqlConnection Connection;

        public db(string server, string user, string pass, string database)
        {
            MySqlConnectionStringBuilder Connect = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = pass,
                Port = 3306,
                Database = database,
                CharacterSet = "utf8"
            };
            Connection = new MySqlConnection(Connect.ConnectionString);
        }
        public long insert(string surname, string namee, string otch)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO owo(surname, name, otch) VALUES(?surname, ?name, ?otch)";
            command.Parameters.Add("?surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("?name", MySqlDbType.VarChar).Value = namee;
            command.Parameters.Add("?otch", MySqlDbType.VarChar).Value = otch;

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }
        public DataTable getTableInfo(string query)
        {
            MySqlCommand queryExecute = new MySqlCommand(query, Connection);
            DataTable ass = new DataTable();
            Connection.Open();
            ass.Load(queryExecute.ExecuteReader());
            Connection.Close();
            return ass;

        }
        public DataTable getTableInfoo(string query)
        {
            MySqlCommand queryExecute = new MySqlCommand(query, Connection);
            DataTable ass = new DataTable();
            Connection.Open();
            ass.Load(queryExecute.ExecuteReader());
            Connection.Close();
            return ass;

        }
        public long insert(int id_fio, string work, int salary)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO uwu(id_fio, work, salary) VALUES(?id_fio, ?work, ?salary)";
            command.Parameters.Add("?id_fio", MySqlDbType.Int32).Value = id_fio;
            command.Parameters.Add("?work", MySqlDbType.VarChar).Value = work;
            command.Parameters.Add("?salary", MySqlDbType.Int32).Value = salary;

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }

        public long delete(int id)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM a1caida.uwu WHERE `id`=(?id)";
            command.Parameters.Add("?id", MySqlDbType.Int32).Value = id;

            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }

        public struct str
        {
            public string id;
            public string familia;
            public string imya;
            public string otchestvo;
            public string rabota;
            public string zarplata;
        }

        public List<str> kek(int id)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT uwu.id,`surname`, `name`, `otch`,`work`,`salary` FROM a1caida.uwu JOIN  a1caida.owo ON uwu.id_fio = owo.id WHERE id_fio = @id ";
            command.Parameters.AddWithValue("@id", id);
            List<str> bd = new List<str>();

            try
            {
                Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        str databd = new str
                        {
                            id = reader.GetString(0),
                            familia = reader.GetString(1),
                            imya = reader.GetString(2),
                            otchestvo = reader.GetString(3),
                            rabota = reader.GetString(4),
                            zarplata = reader.GetString(5),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bd;

        }

        public List<str> Kurisutina()
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT uwu.id,`surname`, `name`, `otch`,`work`,`salary` FROM a1caida.uwu JOIN  a1caida.owo ON uwu.id_fio = owo.id";          
            List<str> bd = new List<str>();

            try
            {
               // Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        str databd = new str
                        {
                            id = reader.GetString(0),
                            familia = reader.GetString(1),
                            imya = reader.GetString(2),
                            otchestvo = reader.GetString(3),
                            rabota = reader.GetString(4),
                            zarplata = reader.GetString(5),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bd;

        }

        public List<str> lol()
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT `id`,`surname`, `name`, `otch` FROM a1caida.owo";
            //command.Parameters.AddWithValue("@id", id);
            List<str> bd = new List<str>();

            try
            {
                Connection.Open();
                using (DbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        str databd = new str
                        {
                            id = reader.GetString(0),
                            familia = reader.GetString(1),
                            imya = reader.GetString(2),
                            otchestvo = reader.GetString(3),
                        };
                        bd.Add(databd);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bd;

        }
    }
}
