using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Account
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public Customer Customer { get; set; }
    }
}
