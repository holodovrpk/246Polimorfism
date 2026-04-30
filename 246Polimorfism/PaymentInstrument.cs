using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _246Polimorfism
{
    internal abstract class PaymentInstrument
    {
        public string PaymentInstrumentName { get; set; }
        public double Balance { get; set; }

        public PaymentInstrument(string PaymentInstrumentName, double Balance) 
        { 
            this.PaymentInstrumentName = PaymentInstrumentName;
            this.Balance = Balance;
        }

        public abstract string Pay(double amount);

        public virtual string ShowInfo()
        {
            return $"{PaymentInstrumentName}: {Balance} руб.";
        }
    }
}
