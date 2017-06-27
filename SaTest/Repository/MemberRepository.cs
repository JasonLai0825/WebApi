using MySql.Data.MySqlClient;
using SaTest.Context;
using SaTest.Models;
using SaTest.MySql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Repository
{
    public class MemberRepository
    {
        public IEnumerable<Member> GetAllMemberInfo()
        {
            return new MemberContext().Get().OrderBy(x => x.M_Id);
        }
        public IEnumerable<Member> GetMemberInfoById(int M_Id)
        {
            return new MemberContext().GetSingle(M_Id);
        }
        public HttpResponseMessage AddNewMemberInfo(Member member)
        {
            return new MemberContext().AddMember(member);
        }
        public HttpResponseMessage ChangePasswordByMId(int M_Id,string newPasswd)
        {
            return new MemberContext().ChangeMemberPassword(M_Id, newPasswd);
        }
        public HttpResponseMessage DeleteMemberInfoById(int M_Id)
        {
            return new MemberContext().DeleteMember(M_Id);
        }
    }
}