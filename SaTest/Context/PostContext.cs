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
    public class PostContext
    {
        public IEnumerable<Post> GetAllPosts()
        {
            List<Post> list = new List<Post>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("post");
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Pid = (int)reader["P_Id"];
                        string content = (string)reader["P_Content"];
                        string time = (string)reader["P_PostTime"];
                        int Sid = (int)reader["SId"];
                        string name = (string)reader["SName"];

                        var item = new Post { P_Id = Pid, P_Content = content, P_PostTime = time, SId = Sid, SName = name };
                        list.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        public IEnumerable<Post>GetSingle(int P_Id)
        {
            List<Post> list = new List<Post>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("post",P_Id);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Pid = (int)reader["P_Id"];
                        string content = (string)reader["P_Content"];
                        string time = (string)reader["P_PostTime"];
                        int Sid = (int)reader["SId"];
                        string name = (string)reader["SName"];

                        var item = new Post { P_Id = Pid, P_Content = content, P_PostTime = time, SId = Sid, SName = name };
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

        public HttpResponseMessage AddNewPostInfo(Post post)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setInsertCommand("post", post);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }

        public HttpResponseMessage DeletePostById(int P_Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setDeleteCommand("post", P_Id);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }
        }
    }
}