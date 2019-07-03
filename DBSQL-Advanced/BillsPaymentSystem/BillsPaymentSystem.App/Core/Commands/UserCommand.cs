using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            int userId = int.Parse(args[0]);

            var user = this.context.Users.FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException("User not found");
            }
            
            sb.AppendLine($"User: {user.FirstName} {user.LastName}");

            var userInfo = context.PaymentMethods.Where(x => x.UserId == userId).ToArray();

            if (userInfo == null)
            {
                throw new ArgumentNullException("User not found");
            }

            foreach (var userBankAccountInfo in userInfo)
            {
                sb.AppendLine($"Bank Accounts:");
                sb.AppendLine($"-- ID: {userBankAccountInfo.BankAccount.BankAccountId}");
                sb.AppendLine($"--- Balance: {userBankAccountInfo.BankAccount.Balance}");
                sb.AppendLine($"--- Bank: {userBankAccountInfo.BankAccount.BankName}");
                sb.AppendLine($"--- SWIFT: {userBankAccountInfo.BankAccount.SWIFT}");
            }

            foreach (var userCreditCardsInfo in userInfo)
            {
                sb.AppendLine($"Credit Cards:");
                sb.AppendLine($"-- ID: {userCreditCardsInfo.CreditCard.CreditCardId}");
                sb.AppendLine($"--- Limit: {userCreditCardsInfo.CreditCard.Limit}");
                sb.AppendLine($"--- Money Owed: {userCreditCardsInfo.CreditCard.MoneyOwed}");
                sb.AppendLine($"--- Limit Left:: {userCreditCardsInfo.CreditCard.LimitLeft}");
                sb.AppendLine($"--- Expiration Date: {userCreditCardsInfo.CreditCard.ExpirationDate}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
