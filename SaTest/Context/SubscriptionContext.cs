using MySql.Data.MySqlClient;
using SaTest.Models;
using SaTest.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Context
{
    public class SubscriptionContext
    {
        public IEnumerable<Subscription> GetAllSubscriptions()
        {
            List<Subscription> list = new List<Subscription>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("subscription");
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Mid = (int)reader["MId"];
                        int Sid = (int)reader["SId"];

                        var item = new Subscription { MId = Mid, SId = Sid };
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public IEnumerable<Subscription> GetSingle(int MId)
        {
            List<Subscription> list = new List<Subscription>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("subscription",MId);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Mid = (int)reader["MId"];
                        int Sid = (int)reader["SId"];

                        var item = new Subscription { MId = Mid, SId = Sid };
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public HttpResponseMessage AddNewSubscription(Subscription sub)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setInsertCommand("subscription",sub);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage DeleteSubscriptionById(int MId)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setDeleteCommand("subscription", MId);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}