using System; // Базовые типы и классы
using System.Collections.Generic; // Коллекции (не используется)
using System.Linq; // LINQ (не используется)
using System.Text; // Работа со строками (не используется)
using System.Threading.Tasks; // Асинхронность (не используется)

namespace _246Polimorfism // Пространство имен проекта
{
    // Класс электронного кошелька, наследуется от PaymentInstrument
    internal class EWallet : PaymentInstrument
    {
        // Комиссия за операцию (в процентах)
        public double Comiss { get; set; }

        // Минимальный остаток, который должен остаться после оплаты
        public double Minimum { get; set; }

        // Конструктор: имя, баланс, комиссия и минимальный остаток
        public EWallet(string PaymentInstrumentName, double Balance, double Comiss, double Minimum)
            : base(PaymentInstrumentName, Balance) // Вызов конструктора базового класса
        {
            this.Comiss = Comiss; // Установка комиссии
            this.Minimum = Minimum; // Установка минимального остатка
        }

        // Переопределение метода оплаты
        public override string Pay(double amount)
        {
            // Рассчитываем сумму с учетом комиссии
            double sum = amount * (Comiss / 100.0 + 1);

            // Проверка:
            // хватает ли средств с учетом комиссии
            // и остается ли минимальный баланс после списания
            if (Balance >= sum + Minimum)
            {
                Balance -= sum; // Списание средств

                // Сообщение об успешной оплате
                return $"{PaymentInstrumentName}: Оплата c учетом комиссии выполнена {sum}";
            }

            // Если условия не выполнены
            return $"{PaymentInstrumentName}: Оплата не прошла!!!";
        }
    }
}