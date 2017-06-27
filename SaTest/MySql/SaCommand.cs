using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SaTest.Models;

namespace SaTest.MySql
{
    public class SaCommand : ISaCommand
    {
        // select command
        public string setSelectCommand(string table)
        {
            return "SELECT * FROM `" + table + "`";
        }
        public string setSelectCommand(string table,int id)
        {
            if (table == "member")
                return "SELECT * FROM `" + table + "` WHERE `M_Id` = " + id;
            else if (table == "shop")
                return "SELECT * FROM `" + table + "` WHERE `S_Id` = " + id;
            else if(table == "post")
                return "SELECT * FROM `" + table + "` WHERE `P_Id` = " + id;
            else if(table == "comment")
                return "SELECT * FROM `" + table + "` WHERE `C_Id` = " + id;
            else
                return "SELECT * FROM `" + table + "` WHERE `MId` = " + id;
        }

        // insert command
        public string setInsertCommand(string table, Post post)
        {
            return "INSERT INTO `" + table + "`(`P_Id`, `P_Content`, `P_PostTime`, `SId`, `SName`) VALUES ('" + post.P_Id + "','" + post.P_Content + "','" + post.P_PostTime + "','" + post.SId + "','" + post.SName + "')";
        }

        public string setInsertCommand(string table, Comment comment)
        {
            return "INSERT INTO `" + table + "`(`C_Id`, `SId`, `C_Publisher`, `C_PostTime`, `C_Content`, `C_Title`, `C_EvaLevel`) VALUES ('" + comment.C_Id + "','" + comment.SId + "','" + comment.C_Publisher + "','" + comment.C_PostTime + "','" + comment.C_Content + "','" + comment.C_Title + "','" + comment.C_EvaLevel + "')";
        }

        public string setInsertCommand(string table, Subscription sub)
        {
            return "INSERT INTO `" + table + "`(`MId`, `SId`) VALUES ('" + sub.MId + "','" + sub.SId + "')";
        }

        public string setInsertCommand(string table, Member member)
        {
            return "INSERT INTO `" + table + "`(`M_Id`, `Account`, `passWd`, `M_Name`, `Birthday`, `E_mail`, `M_Phone`) VALUES ('" + member.M_Id + "','" + member.Account + "','" + member.passWd + "','" + member.M_Name + "','" + member.Birthday + "','" + member.E_mail + "','" + member.M_Phone + "')";
        }

        public string setInsertCommand(string table, Shop shop)
        {
            return "INSERT INTO `" + table + "`(`S_Id`, `S_Name`, `S_Phone`, `S_Address`, `S_LatLng`, `S_OpenTime`, `S_Type`, `S_Evaluation`, `S_Status`, `S_Menu`, `S_Photo`) VALUES ('" + shop.S_Id + "','" + shop.S_Name + "','" + shop.S_Phone + "','" + shop.S_Address + "','" + shop.S_LatLng + "','" + shop.S_OpenTime + "','" + shop.S_Type + "','" + shop.S_Evaluation + "','" + shop.S_Status + "','" + shop.S_Menu + "','" + shop.S_Photo + "')";
        }
        // update command
        public string setUpdateCommand(string table,int id,string passWd)
        {
            return "UPDATE `" + table + "` SET passWd='" + passWd + "' WHERE M_Id=" + id + "";
        }

        public string setUpdateCommand(string table,int id,string attribute,string newContent)
        {
                return "UPDATE `" + table + "` SET S_Status='" + newContent + "'WHERE S_Id='" + id + "'";
        }
        public string setUpdateCommand(string table,int id,int newEvaluation)
        {
            return "UPDATE `" + table + "` SET S_Evaluation='" + newEvaluation + "'WHERE S_Id='" + id + "'";
        }

        // delete command
        public string setDeleteCommand(string table,int id)
        {
            if(table == "member")
                return "DELETE FROM `" + table + "` WHERE M_Id='" + id + "'";
            else if(table == "post")
                return "DELETE FROM `" + table + "` WHERE P_Id='" + id + "'";
            else if(table == "comment")
                return "DELETE FROM `" + table + "` WHERE C_Id='" + id + "'";
            else
                return "DELETE FROM `" + table + "` WHERE MId='" + id + "'";
        }
    }
}