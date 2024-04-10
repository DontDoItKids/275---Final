using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _275___Final.Models
{
    [PrimaryKey("Address")]
    public class CryptoAddress
    {
        public string Address { get; set; }
        public int CurrencyID { get; set; }
        public int UserID { get; set; }
        public DateTime AddDate { get; set; }
    }
}
