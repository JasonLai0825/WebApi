using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SaTest.Models;
using SaTest.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Context
{
    public class MemberContext
    {
        public IEnumerable<Member> Get()
        {
            List<Member> list = new List<Member>();

            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("member");

                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = (int)reader["M_Id"];
                        string account = (string)reader["Account"];
                        string password = (string)reader["passWd"];
                        string name = (string)reader["M_Name"];
                        string birthday = (string)reader["Birthday"];
                        string mail = (string)reader["E_mail"];
                        string phone = (string)reader["M_Phone"];

                        var item = new Member {M_Id = id,Account = account, passWd = password, M_Name = name, Birthday = birthday, E_mail = mail, M_Phone = phone };
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

        public IEnumerable<Member> GetSingle(int M_Id)
        {
            List<Member> list = new List<Member>();

            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("member",M_Id);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int id = (int)reader["M_Id"];
                        string account = (string)reader["Account"];
                        string password = (string)reader["passWd"];
                        string name = (string)reader["M_Name"];
                        string birthday = (string)reader["Birthday"];
                        string mail = (string)reader["E_mail"];
                        string phone = (string)reader["M_Phone"];

                        var item = new Member { M_Id = id, Account = account, passWd = password, M_Name = name, Birthday = birthday, E_mail = mail, M_Phone = phone };
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

        public HttpResponseMessage AddMember(Member member)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setInsertCommand("member",member);

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

        public HttpResponseMessage ChangeMemberPassword(int id,string newPasswd)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setUpdateCommand("member", id, newPasswd);

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

        public HttpResponseMessage DeleteMember(int M_Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setDeleteCommand("member", M_Id);

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