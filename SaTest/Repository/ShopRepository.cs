using SaTest.Context;
using SaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Repository
{
    public class ShopRepository
    {
        //select command
        public IEnumerable<Shop> GetAllShopInfo()
        {
            return new ShopContext().Get().OrderBy(x => x.S_Id);
        }
        public IEnumerable<Shop> GetShopInfoById(int S_Id)
        {
            return new ShopContext().GetSingle(S_Id);
        }

        //insert command
        public HttpResponseMessage AddNewShopInfo(Shop shop)
        {
            return new ShopContext().AddNewShopInfo(shop);
        }

        //update command
        public HttpResponseMessage ChangeShopStatusById(int S_Id,string newStatus)
        {
            return new ShopContext().ChangeShopStatus(S_Id, newStatus);
        }
        public HttpResponseMessage ChangeShopEvaluationById(int S_Id,int newEvaluation)
        {
            return new ShopContext().ChangeShopEvaluation(S_Id, newEvaluation);
        }
    }
}