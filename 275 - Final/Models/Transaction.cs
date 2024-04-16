using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _275___Final.Models
{
    public class Transaction
    {
        public enum TransactionType
        {
            Buy,
            Sell,
            Gift
        }

        public int ID { get; set; }
        public string UsersAddress { get; set; }
        public string TargetAddress { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public double AmountOfTokens { get; set; }
        public string Currency { get; set; }
        public double Value { get; set; } 
        public int UserID { get; set; }
        public double GainLoss { get; set; }
    }
}
