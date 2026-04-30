using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _246Polimorfism
{
    internal class EWallet : PaymentInstrument
    {
        public double Comiss { get; set; }
        public double Minimum { get; set; }

        public EWallet(string PaymentInstrumentName, double Balance, double Comiss, double Minimum)
            : base(PaymentInstrumentName, Balance)
        {
            this.Comiss = Comiss;
            this.Minimum = Minimum;
        }

        public override string Pay(double amount)
        {
            double sum = amount * (Comiss / 100.0 + 1);

            if (Balance >= sum + Minimum)
            {
                Balance -= sum;
                return $"{PaymentInstrumentName}: Оплата c учетеом комиссии выполнена {sum}";
            }
            return $"{PaymentInstrumentName}: Оплата не прошла!!!";
        }
    }
}
