using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment01
{
    class MembershipApplication
    {
        static void Main()
        {
            // User name
            string user = "isuru";
            var members = new List<Membership>();

            Console.WriteLine("Welcome to the Membership Management Platform");

            Console.Write("User: " + user);
            user = Console.ReadLine();

            

            // Menu
            while (true)
            {
                Console.WriteLine("Please check the option below: ");
                Console.WriteLine("1 - Create new membership");
                Console.WriteLine("2 - Show summary information");
                Console.WriteLine("3 -Quit");

                Console.Write("Choose your option:");
                int option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    // Get customer name
                    var member = new Membership();
                    Console.Write("Enter customer name:");
                    member.customerName = Console.ReadLine();

                    while (true)
                    {
                        // Get number of months
                        Console.Write("Enter number of months (1-60):");
                        member.months = int.Parse(Console.ReadLine());

                        if (member.months >= 1 && member.months <= 60)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Number of months must be between 1 and 60.");
                        }
                    }

                    // Get special offer
                    Console.Write("Does customer receive special offer (y/n)?");
                    member.specialOffer = Console.ReadLine().ToLower() == "y";
                   
                    // Calculate rate
                    if (member.months <= 5)
                    {
                        member.rate = 30.0;
                    }
                    else if (member.months <= 11)
                    {
                        member.rate = 27.5;
                    }
                    else
                    {
                        member.rate = 25.0;
                    }

                    // Apply special offer
                    if (member.specialOffer)
                    {
                        member.rate = member.rate * 0.85;
                    }

                    // Add new membership to the list
                    member.total = member.months * member.rate;

                    members.Add(member);
                    Console.WriteLine($" {member.customerName}membership has been created");
                    Console.WriteLine($"Membership fee is {member.total}.");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("");
                }
                // Display membership information
                else if (option == 2)

                {
                    if (members.Count == 0)
                    {
                        Console.WriteLine("There is no membership to display");
                    }
                    else
                    {
                        //geting the maximum and minimum values
                        Membership maxmember = members[0];
                        Membership minmember = members[0];

                        Console.WriteLine("Summary of memberships:");
                        Console.WriteLine("-------------------------------------------------");
                        Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10}", "CustomerName", "Months", "CustomerOffer", "TotalCost");
                        Console.WriteLine("-------------------------------------------------");

                        foreach(Membership m in members)
                        {
                            Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10}", m.customerName, m.months, m.specialOffer ? "Y" : "N", m.total);

                            maxmember = maxmember.total < m.total ? m : maxmember;
                            minmember = minmember.total > m.total ? m : minmember;

                        }

                        if (members.Count > 1)
                        {
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine();
                            Console.WriteLine("The customer spends the most is {0} at {1}", maxmember.customerName, maxmember.total);
                            Console.WriteLine("The customer spends the least is {0} at {1}", minmember.customerName, minmember.total);
                            Console.WriteLine("-------------------------------------------------");
                        }

                    }
                }

                //exit the program
                else if (option == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid option.");
                }
            }
        }
    }
}
