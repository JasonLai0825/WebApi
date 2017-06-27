using SaTest.Context;
using SaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SaTest.Repository
{
    public class SubscriptionRepository
    {
        // select command
        public IEnumerable<Subscription> GetAllSubscription()
        {
            return new SubscriptionContext().GetAllSubscriptions().OrderBy(x => x.MId);
        }

        public IEnumerable<Subscription> GetSubscriptionById(int MId)
        {
            return new SubscriptionContext().GetSingle(MId);
        }

        // insert command
        public HttpResponseMessage AddNewSubscription(Subscription sub)
        {
            return new SubscriptionContext().AddNewSubscription(sub);
        }

        // delete command
        public HttpResponseMessage DeleteSubscriptionById(int MId)
        {
            return new SubscriptionContext().DeleteSubscriptionById(MId);
        }
    }
}