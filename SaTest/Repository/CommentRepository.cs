using SaTest.Context;
using SaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Repository
{
    public class CommentRepository
    {
        // select command
        public IEnumerable<Comment> GetAllComments()
        {
            return new CommentContext().GetAllComments().OrderBy(x => x.C_Id);
        }
        public IEnumerable<Comment> GetCommentInfoById(int C_Id)
        {
            return new CommentContext().GetSingle(C_Id);
        }

        // insert command
        public HttpResponseMessage AddNewCommentInfo(Comment comment)
        {
            return new CommentContext().AddNewComment(comment);
        }

        // delete command
        public HttpResponseMessage DeleteCommentById(int C_Id)
        {
            return new CommentContext().DeleteCommentById(C_Id);
        }
    }
}