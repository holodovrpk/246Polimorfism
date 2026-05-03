using System; // Базовые типы и классы
using System.Collections.Generic; // Коллекции (не используется)
using System.Linq; // LINQ (не используется)
using System.Text; // Работа со строками (не используется)
using System.Threading.Tasks; // Асинхронность (не используется)

namespace _246Polimorfism // Пространство имен проекта
{
    // Класс BankCard наследуется от абстрактного класса PaymentInstrument
    internal class BankCard : PaymentInstrument
    {
        // Комиссия за оплату (в процентах)
        public double Comiss { get; set; }

        // Конструктор с параметрами: имя, баланс и комиссия
        public BankCard(string PaymentInstrumentName, double Balance, double Comiss)
            : base(PaymentInstrumentName, Balance) // Вызов конструктора базового класса
        {
            this.Comiss = Comiss; // Установка комиссии
        }

        // Переопределение абстрактного метода Pay
        public override string Pay(double amount)
        {
            // Рассчитываем сумму с учетом комиссии
            double sum = amount * (Comiss / 100.0 + 1);

            // Проверка: хватает ли средств
            if (Balance >= sum)
            {
                Balance -= sum; // Списываем деньги с баланса

                // Возвращаем сообщение об успешной оплате
                return $"{PaymentInstrumentName}: Оплата c учетом комиссии выполнена {sum}";
            }

            // Если средств недостаточно
            return $"{PaymentInstrumentName}: Оплата не прошла!!!";
        }

        // Переопределение метода вывода информации
        public override string ShowInfo()
        {
            // Добавляем информацию о комиссии
            return $"{PaymentInstrumentName}: {Balance} руб. (комиссия {Comiss})";
        }
    }
}