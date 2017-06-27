using SaTest.Context;
using SaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Repository
{
    public class PostRepository
    {
        //select command
        public IEnumerable<Post> GetAllPostsInfo()
        {
            return new PostContext().GetAllPosts().OrderBy(x => x.P_Id);
        }
        public IEnumerable<Post>GetPostInfoById(int P_Id)
        {
            return new PostContext().GetSingle(P_Id);
        }

        //insert command
        public  HttpResponseMessage AddNewPostInfo(Post post)
        {
            return new PostContext().AddNewPostInfo(post);
        }

        //delete command
        public HttpResponseMessage DeletePostById(int P_Id)
        {
            return new PostContext().DeletePostById(P_Id);
        }
    }
}