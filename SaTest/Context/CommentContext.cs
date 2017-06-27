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
    public class CommentContext
    {
        public IEnumerable<Comment> GetAllComments()
        {
            List<Comment> list = new List<Comment>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("comment");
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Cid = (int)reader["C_Id"];
                        int Sid = (int)reader["SId"];
                        string publisher = (string)reader["C_Publisher"];
                        string time = (string)reader["C_PostTime"];
                        string content = (string)reader["C_Content"];
                        string title = (string)reader["C_Title"];
                        int evaluation = (int)reader["C_EvaLevel"];

                        var item = new Comment { C_Id = Cid, SId = Sid, C_Publisher = publisher, C_PostTime = time, C_Content = content, C_Title = title, C_EvaLevel = evaluation };
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

        public IEnumerable<Comment> GetSingle(int C_Id)
        {
            List<Comment> list = new List<Comment>();
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setSelectCommand("comment",C_Id);
                conn.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Cid = (int)reader["C_Id"];
                        int Sid = (int)reader["SId"];
                        string publisher = (string)reader["C_Publisher"];
                        string time = (string)reader["C_PostTime"];
                        string content = (string)reader["C_Content"];
                        string title = (string)reader["C_Title"];
                        int evaluation = (int)reader["C_EvaLevel"];

                        var item = new Comment { C_Id = Cid, SId = Sid, C_Publisher = publisher, C_PostTime = time, C_Content = content, C_Title = title, C_EvaLevel = evaluation };
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

        public HttpResponseMessage AddNewComment(Comment comment)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setInsertCommand("comment",comment);
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

        public HttpResponseMessage DeleteCommentById(int C_Id)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(new SaConnection().connStr);
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = new SaCommand().setDeleteCommand("comment", C_Id);
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
    }
}