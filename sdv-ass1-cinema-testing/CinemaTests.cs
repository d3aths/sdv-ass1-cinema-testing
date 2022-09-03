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
            //Time is in 24 hours to account for am/pm
            [TestCase(1, "Adult", "Saturday", 3, 15.00)]
            [TestCase(2, "Adult", "Monday", 12, 30.00)]
            [TestCase(1, "Adult", "Wednesday,", 18, -1)]
            [TestCase(2, "Child", "Sunday", 2, -1)]
            [TestCase(3, "Adult", "Tuesday", 20, -1)]
            [TestCase(0, "Adult", "Friday", 5, -1)]
            [TestCase(6, "Adult", "Thursday", 5, 90.00)]
            [TestCase(28, "Adult", "Friday", 11, 420.00)]
            public void Adult_Before_5(int pr_quantity, string pr_person, string pr_day, decimal pr_time, decimal expected)
            {
                decimal ticket_price = 15.00M;
                decimal result = -1;

                if (pr_person.ToLower() != "adult" || pr_day.ToLower() == "tuesday" || pr_quantity < 1 || pr_time >= 17)
                {
                    Assert.That(result == expected);
                }
                else
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }

            [TestCase(1, "Adult", "Saturday", 3, -1)]
            [TestCase(2, "Adult", "Monday", 12, -1)]
            [TestCase(1, "Adult", "Wednesday,", 18, 18.00)]
            [TestCase(2, "Child", "Sunday", 2, -1)]
            [TestCase(3, "Adult", "Tuesday", 20, -1)]
            [TestCase(0, "Adult", "Friday", 5, -1)]
            [TestCase(6, "Adult", "Thursday", 21, 108.00)]
            [TestCase(28, "Adult", "Friday", 11, -1)]
            public void Adult_After_5(int pr_quantity, string pr_person, string pr_day, decimal pr_time, decimal expected)
            {
                decimal ticket_price = 18.00M;
                decimal result = -1;

                if (pr_person.ToLower() != "adult" || pr_day.ToLower() == "tuesday" || pr_quantity < 1 || pr_time < 17)
                {
                    Assert.That(result == expected);
                }
                else
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }

            [TestCase(1, "Adult", "Tuesday", 14.00)]
            [TestCase(2, "Adult", "Monday", -1)]
            [TestCase(1, "Adult", "Wednesday,", -1)]
            [TestCase(2, "Child", "Sunday", -1)]
            [TestCase(3, "Adult", "Tuesday", 42.00)]
            [TestCase(0, "Adult", "Friday", -1)]
            [TestCase(6, "Adult", "Tuesday", 84.00)]
            [TestCase(28, "Adult", "Friday", -1)] //work party, too bad they didn't get a discount
            public void Adult_Tuesday(int pr_quantity, string pr_person, string pr_day, decimal expected)
            {
                decimal ticket_price = 14.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "adult" && pr_day.ToLower() == "tuesday" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result ==expected);
                }
            }

            [TestCase(2, "Child", 26.00)]
            [TestCase(2, "Adult", -1)]
            [TestCase(1, "Senior", -1)]
            [TestCase(0, "Child", -1)]
            [TestCase(300, "Child", 3900.00)] //the entire school is going for an outing
            public void Child_Under_16(int pr_quantity, string pr_person, decimal expected)
            {
                decimal ticket_price = 13.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "child" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }

            [TestCase(2, "Child", -1)]
            [TestCase(76, "Senior", 988.00)] //the old peoples home are catching a flick
            [TestCase(0, "Senior", -1)]
            [TestCase(1, "Adult", -1)]
            public void Senior(int pr_quantity, string pr_person, decimal expected)
            {
                decimal ticket_price = 13.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "senior" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }

            [TestCase(1, "Child", -1)]
            [TestCase(15, "Student", 225.00)] //the class passed their assignments and Ali is shouting them to the movies
            [TestCase(0, "Student", -1)]
            public void Student(int pr_quantity, string pr_person, decimal expected)
            {
                decimal ticket_price = 15.00M;
                decimal result = -1;

                if (pr_person.ToLower() == "student" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }

            //(2 Adults/2 Children) or (1 Adult/3 Children)
            [TestCase(1, 1, 3, 49.00)]
            [TestCase(1, 2, 2, 49.00)]
            [TestCase(2, 4, 4, 98.00)]
            [TestCase(3, 3, 9, 147.00)]
            [TestCase(1, 3, 2, -1)]
            [TestCase(2, 5, 7, -1)]
            [TestCase(1, 4, 0, -1)]
            public void Family_Pass(int pr_quantity_ticket, int pr_quantity_adult, int pr_quantity_child, decimal expected)
            {
                decimal ticket_price = 49.00M;
                decimal result = -1;

                if (pr_quantity_ticket >= 1 && pr_quantity_adult == 2 && pr_quantity_child == 2 ||
                    pr_quantity_ticket >= 1 && pr_quantity_adult == 1 && pr_quantity_child == 3)
                {
                    result = (ticket_price * pr_quantity_ticket);
                    Assert.That(result == expected);
                }
            }

            [TestCase(1, "Adult", "Thursday", 21.50)]
            [TestCase(2, "Adult", "Monday", -1)]
            [TestCase(1, "Adult", "Wednesday,", -1)]
            [TestCase(2, "Child", "Sunday", -1)]
            [TestCase(0, "Adult", "Thursday", -1)]
            [TestCase(6, "Adult", "Thursday", 129.00)]
            [TestCase(28, "Adult", "Friday", -1)]
            public void Chick_Flick_Thursday(int pr_quantity, string pr_person, string pr_day, decimal expected)
            {
                decimal ticket_price = 21.50M;
                decimal result = -1;

                if (pr_person.ToLower() == "adult" && pr_day.ToLower() == "thursday" && pr_quantity >= 1)
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }

            [TestCase(1, "Wednesday", true, 15.00)]
            [TestCase(2, "Monday", true, -1)]
            [TestCase(3, "Wednesday", true, 45.00)]
            [TestCase(0, "Friday", false, -1)]
            [TestCase(1, "Wednesday", false, -1)]
            public void Kids_Carers(int pr_quantity, string pr_day, bool pr_holiday, decimal expected)
            {
                decimal ticket_price = 15.00M;
                decimal result = -1;

                if (pr_quantity >= 1 && pr_day.ToLower() == "wednesday" && pr_holiday == true)
                {
                    result = (ticket_price * pr_quantity);
                    Assert.That(result == expected);
                }
            }
        }
    }
}
