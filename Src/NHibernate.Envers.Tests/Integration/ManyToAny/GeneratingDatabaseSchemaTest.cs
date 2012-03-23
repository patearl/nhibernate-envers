﻿using System.Collections.Generic;
using Iesi.Collections.Generic;
using NHibernate.Envers.Tests.Entities.ManyToAny;
using NUnit.Framework;

namespace NHibernate.Envers.Tests.Integration.ManyToAny
{
    [TestFixture, Ignore("failing test for NHE-61")]
    public class GeneratingDatabaseSchemaTest : TestBase
    {
        protected override IEnumerable<string> Mappings
        {
            get
            {
                return new[]
                           {
                               "Entities.ManyToAny.CreditCardPayment.hbm.xml",
                               "Entities.ManyToAny.Order.hbm.xml",
                               "Entities.ManyToAny.Purchase.hbm.xml",
                               "Entities.ManyToAny.WirePayment.hbm.xml"
                           };
            }
        }
        protected override void Initialize()
        {
        }

        [Test]
        public void CanCreateManyToAnyAudit()
        {
            var purchase = new Purchase
                                    {
                                        Payments = new HashedSet<IPayment>
                                                       {
                                                           new CreditCardPayment{Amount = 500,CardNumber = "12345678",IsSuccessful = true},
                                                           new WirePayment{Amount = 200,CardNumber = "87654321",IsSuccessful = false}
                                                       }
                                    };
            using (var tx = Session.BeginTransaction())
            {
                Session.Save(purchase);
                tx.Commit();
            }
        }
    }
}