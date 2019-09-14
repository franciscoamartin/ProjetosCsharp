using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conta.Entities;

namespace Conta
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account ( 8020, "Francisco", 100.00 );
            BusinessAccount bacc = new BusinessAccount(1022, "Maria", 200.00, 300.00);


            //UPCASTING

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 400, 500.00);
            Account acc3 = new BusinessAccount(200, "Joao",500, 600);


            //DOWNCASTING

            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.00);

            //BusinessAccount acc5 = (BusinessAccount)acc3;
            if(acc3 is BusinessAccount)
            {
                // BusinessAccount acc5 = (BusinessAccount)acc3;
                BusinessAccount acc5 = acc3 as BusinessAccount;
                acc5.Loan(600);
                Console.WriteLine("Loan!");
            }

            if(acc3 is SavingsAccount)
            {
                // SavingsAccount acc5 = (SavingsAccount)acc3;
                SavingsAccount acc5 = acc3 as SavingsAccount;
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }
    }
}
