using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _275___Final.Models
{
    [PrimaryKey("Date")]
    public class ExchangeRate
    {
        public DateTime Date { get; set; }
        public double CADtoUSD { get; set; }
        public double USDtoCAD { get; set; }
    }
}
