using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace sdv_ass1_cinema_testing
{
    internal class CinemaTests
    {
        [TestFixture]
        public class TicketPriceController
        {
            [Test]
            public decimal Adult_Before_5(int pr_quantity, string pr_person, string pr_day, decimal pr_time)
            {
                decimal ticket_price = 15.00M;
                decimal result = -1;

                if (pr_person.ToLower() != "adult" || pr_day.ToLower() == "tuesday" || pr_quantity < 1 || pr_time >= 5)
                {
                    Assert.That(result == 15.00M);
                    return result;
                }
                else
                {
                    Assert.That(result == 15.00M);
                    result = (ticket_price * pr_quantity);
                    return result;
                }
            }

            [Test]
            public decimal Adult_After_5(int pr_quantity, string pr_person, string pr_day, decimal pr_time)
            {
                decimal ticket_price = 18.00M;
                decimal result = -1;

                if (pr_person.ToLower() != "adult" || pr_day.ToLower() == "tuesday" || pr_quantity < 1 || pr_time < 5)
                {
                    Assert.That(result == 18.00M);
                    return result;
                }
                else
                {
                    Assert.That(result == 18.00M);
                    result = (ticket_price * pr_quantity);
                    return result;
                }
            }

            [Test]
            public decimal Adult_Tuesday(int pr_quantity, string pr_person, string pr_day)
            {
                decimal ticket_price = 14.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "adult" && pr_day.ToLower() == "tuesday" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    return result;
                }
                Assert.That(result == 14.00M);
                return result;
            }

            [Test]
            public decimal Child_Under_16(int pr_quantity, string pr_person)
            {
                decimal ticket_price = 13.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "child" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    return result;
                }
                Assert.That(result == 13.00M);
                return result;
            }

            [Test]
            public decimal Senior(int pr_quantity, string pr_person)
            {
                decimal ticket_price = 13.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "senior" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    return result;
                }
                Assert.That(result == 13.00M);
                return result;
            }

            [Test]
            public decimal Student(int pr_quantity, string pr_person)
            {
                decimal ticket_price = 15.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "student" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    return result;
                }
                Assert.That(result == 15.00M);
                return result;
            }

            [Test]
            public decimal Family_Pass(int pr_quantity_ticket, int pr_quantity_adult, int pr_quantity_child)
            {
                decimal ticket_price = 49.00M;
                decimal result = -1;

                if (pr_quantity_ticket >= 1 && pr_quantity_adult == 2 && pr_quantity_child == 2 ||
                    pr_quantity_ticket >= 1 && pr_quantity_adult == 1 && pr_quantity_child == 3)
                {
                    result = (ticket_price * pr_quantity_ticket);
                    return result;
                }
                Assert.That(result == 49.00M);
                return result;
            }

            [Test]
            public decimal Chick_Flick_Thursday(int pr_quantity, string pr_person, string pr_day)
            {
                decimal ticket_price = 21.50M;
                decimal result = -1;

                if (pr_person.ToLower() == "adult" && pr_day.ToLower() == "thursday" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    return result;
                }
                Assert.That(result == 21.50M);
                return result;
            }

            [Test]
            public decimal Kids_Careers(int pr_quantity, string pr_day, bool pr_holiday)
            {
                decimal ticket_price = 15.00M;
                decimal result = -1;

                if (pr_quantity >= 1 && pr_day.ToLower() == "wednesday" && pr_holiday == false)
                {
                    result = (ticket_price * pr_quantity);
                    return result;
                }
                Assert.That(result == 15.00M);
                return result;
            }
        }
    }
}
