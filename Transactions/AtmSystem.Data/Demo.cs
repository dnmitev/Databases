//2.Using transactions write a method which retrieves some money (for example $200) from certain account. 
//The retrieval is successful when the following sequence of sub-operations is completed successfully:
//A query checks if the given CardPIN and CardNumber are valid.
//The amount on the account (CardCash) is evaluated to see whether it is bigger than the requested sum (more than $200).
//The ATM machine pays the required sum (e.g. $200) and stores in the table CardAccounts the new amount (CardCash = CardCash - 200).

//3.Extend the project from the previous exercise and add a new table 
//TransactionsHistory with fields (Id, CardNumber, TransactionDate, Ammount) 
//containing information about all money retrievals on all accounts.
//Modify the program logic so that it saves historical information (logs) 
//in the new table after each successful money withdrawal.

namespace AtmSystem.Data
{
    using AtmSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Demo
    {
        static void Main()
        {
            string cardPin = "1234";
            string cardNumber = "BG2013-123";

            GetMoney(cardNumber, cardPin, 1200.0M);
        }

        private static void GetMoney(string cardNumber, string cardPin, decimal moneyToWithdrar)
        {
            if (IsCardValid(cardNumber, cardPin))
            {
                if (GetCardBalance(cardNumber) >= moneyToWithdrar)
                {
                    WithdrawMoney(cardNumber, cardPin, moneyToWithdrar);
                }
                else
                {
                    throw new InvalidOperationException("Not enough money.");
                }
            }
            else
            {
                throw new SystemException("Invalid card. Operation cancelled.");
            }
        }

        private static decimal? GetCardBalance(string cardNumber)
        {
            using (var dbContext = new AtmSystemEntities())
            {
                var balance = dbContext.CardAccounts
                                       .Where(ca => ca.CardNumber == cardNumber)
                                       .Select(ca => ca.CardCash).FirstOrDefault();

                return balance;
            }
        }

        private static void WithdrawMoney(string cardNumber, string cardPin, decimal moneyToWithdraw)
        {
            using (var dbContext = new AtmSystemEntities())
            {
                var currAccount = dbContext.CardAccounts
                                              .FirstOrDefault(ca => ca.CardNumber == cardNumber && ca.CardPIN == cardPin);

                Console.WriteLine("Before withdraw: {0}",currAccount.CardCash);
                currAccount.CardCash -= moneyToWithdraw;
                Console.WriteLine("After withdraw: {0}", currAccount.CardCash);

                TransactionHistory transactionHistory = new TransactionHistory()
                {
                    CardId = currAccount.Id,
                    Amount = currAccount.CardCash,
                    TransactionDate = DateTime.Now
                };

                dbContext.TransactionHistories.Add(transactionHistory);

                dbContext.SaveChanges();
            }
        }

        private static bool IsCardValid(string cardNumber, string cardPin)
        {
            using (var dbContext = new AtmSystemEntities())
            {
                var isCardValid = dbContext.CardAccounts
                                           .Where(ca => ca.CardNumber == cardNumber && ca.CardPIN == cardPin)
                                           .Any();

                return isCardValid;
            }
        }
    }
}