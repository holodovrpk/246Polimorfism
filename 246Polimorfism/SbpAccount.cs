using System; // Базовые типы и классы
using System.Collections.Generic; // Коллекции (не используется)
using System.Linq; // LINQ (не используется)
using System.Text; // Работа со строками (не используется)
using System.Threading.Tasks; // Асинхронность (не используется)

namespace _246Polimorfism // Пространство имен проекта
{
    // Класс SbpAccount наследуется от PaymentInstrument
    internal class SbpAccount : PaymentInstrument
    {
        // Лимит на одну операцию (например, через СБП)
        public double Limit { get; set; }

        // Конструктор: принимает имя, баланс и лимит
        public SbpAccount(string PaymentInstrumentName, double Balance, double Limit)
            : base(PaymentInstrumentName, Balance) // Вызов конструктора базового класса
        {
            this.Limit = Limit; // Установка лимита
        }

        // Переопределение метода оплаты
        public override string Pay(double amount)
        {
            // Проверка:
            // 1. Хватает ли денег
            // 2. Не превышает ли сумма лимит
            if (Balance >= amount && amount <= Limit)
            {
                Balance -= amount; // Списание средств

                // Сообщение об успешной оплате
                return $"{PaymentInstrumentName}: Оплата выполнена {amount}";
            }

            // Если одно из условий не выполнено
            return $"{PaymentInstrumentName}: Оплата не прошла!!!";
        }
    }
}