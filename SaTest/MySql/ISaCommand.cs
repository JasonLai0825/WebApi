using SaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaTest.MySql
{
    public interface ISaCommand
    {
        //select command
        string setSelectCommand(string table);
        string setSelectCommand(string table, int id);

        //insert command
        string setInsertCommand(string table, Member member);
        string setInsertCommand(string table, Post post);
        string setInsertCommand(string table, Comment comment);
        string setInsertCommand(string table, Subscription sub);

        //update command
        string setUpdateCommand(string table,int id,string passWd);
        string setUpdateCommand(string table,int id,string attribute,string newContent);
        string setUpdateCommand(string table,int id,int newEvaluation);

        //delete command
        string setDeleteCommand(string table, int id);
    }
}