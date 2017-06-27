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
    public class ShopContext
    {
        public IEnumerable<Shop>Get()
        {
            List<Shop> list = new List<Shop>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("shop");
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["S_Id"];
                        string name = (string)reader["S_Name"];
                        string phone = (string)reader["S_Phone"];
                        string address = (string)reader["S_Address"];
                        string latlng = (string)reader["S_LatLng"];
                        string time = (string)reader["S_OpenTIme"];
                        string type = (string)reader["S_Type"];
                        int evaluation = (int)reader["S_Evaluation"];
                        string status = (string)reader["S_Status"];
                        string menu = (string)reader["S_Menu"];
                        string photo = (string)reader["S_Photo"];

                        var item = new Shop { S_Id = id, S_Name = name, S_Phone = phone, S_Address = address, S_LatLng = latlng, S_OpenTime = time, S_Type = type, S_Evaluation = evaluation, S_Status = status, S_Menu = menu, S_Photo = photo };
                        list.Add(item);
                    }
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public IEnumerable<Shop> GetSingle(int S_Id)
        {
            List<Shop> list = new List<Shop>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("shop",S_Id);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["S_Id"];
                        string name = (string)reader["S_Name"];
                        string phone = (string)reader["S_Phone"];
                        string address = (string)reader["S_Address"];
                        string latlng = (string)reader["S_LatLng"];
                        string time = (string)reader["S_OpenTIme"];
                        string type = (string)reader["S_Type"];
                        int evaluation = (int)reader["S_Evaluation"];
                        string status = (string)reader["S_Status"];
                        string menu = (string)reader["S_Menu"];
                        string photo = (string)reader["S_Photo"];

                        var item = new Shop { S_Id = id, S_Name = name, S_Phone = phone, S_Address = address, S_LatLng = latlng, S_OpenTime = time, S_Type = type, S_Evaluation = evaluation, S_Status = status, S_Menu = menu, S_Photo = photo };
                        list.Add(item);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return list;
        }

        public HttpResponseMessage AddNewShopInfo(Shop shop)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setInsertCommand("shop", shop);

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

        public HttpResponseMessage ChangeShopStatus(int S_Id,string newStatus)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setUpdateCommand("shop",S_Id, "status",newStatus);

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
        public HttpResponseMessage ChangeShopEvaluation(int S_Id,int newEvaluation)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setUpdateCommand("shop",S_Id,newEvaluation);

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