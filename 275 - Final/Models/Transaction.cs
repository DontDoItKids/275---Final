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
        public enum Currency
        {
            CAD,
            USD
        }

        public int ID { get; set; }
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int Amount { get; set; }
        public float Value { get; set; }
        public Currency CurrencyType { get; set; }

    }
}
