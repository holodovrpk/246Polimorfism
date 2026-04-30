using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _246Polimorfism
{
    internal class SbpAccount : PaymentInstrument
    {
        public double Limit { get; set; }

        public SbpAccount(string PaymentInstrumentName, double Balance, double Limit)
            : base(PaymentInstrumentName, Balance)
        {
            this.Limit = Limit;
        }

        public override string Pay(double amount)
        {
            

            if (Balance >= amount && amount <= Limit)
            {
                Balance -= amount;
                return $"{PaymentInstrumentName}: Оплата  выполнена {amount}";
            }
            return $"{PaymentInstrumentName}: Оплата не прошла!!!";
        }
    }
}
