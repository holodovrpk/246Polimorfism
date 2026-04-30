using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _246Polimorfism
{
    internal class BankCard : PaymentInstrument
    {
        public double Comiss {  get; set; }

        public BankCard(string PaymentInstrumentName, double Balance, double Comiss) 
            : base(PaymentInstrumentName, Balance)
        {
            this.Comiss = Comiss;
        }

        public override string Pay(double amount)
        {
            double sum = amount * (Comiss/100.0 + 1);

            if (Balance >= sum)
            {
                Balance -= sum;
                return $"{PaymentInstrumentName}: Оплата c учетеом комиссии выполнена {sum}";
            }
            return $"{PaymentInstrumentName}: Оплата не прошла!!!";
        }


        public override string ShowInfo()
        {
            return $"{PaymentInstrumentName}: {Balance} руб. (комиссия {Comiss})";
        }
    }
}
