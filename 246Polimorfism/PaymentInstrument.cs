using System; // Подключение базового пространства имен с основными типами
using System.Collections.Generic; // Подключение коллекций (в данном файле не используется)
using System.Linq; // Подключение LINQ-запросов (не используется здесь)
using System.Text; // Работа со строками (не используется)
using System.Threading.Tasks; // Для асинхронности (не используется)

namespace _246Polimorfism // Пространство имен проекта (связанное с темой полиморфизма)
{
    // Абстрактный класс — нельзя создать объект напрямую, только наследоваться
    internal abstract class PaymentInstrument
    {
        // Название платежного инструмента (например: карта, кошелек и т.д.)
        public string PaymentInstrumentName { get; set; }

        // Баланс на инструменте
        public double Balance { get; set; }

        // Конструктор для инициализации названия и баланса
        public PaymentInstrument(string PaymentInstrumentName, double Balance)
        {
            this.PaymentInstrumentName = PaymentInstrumentName; // Присваиваем имя
            this.Balance = Balance; // Присваиваем баланс
        }

        // Абстрактный метод оплаты — должен быть реализован в дочерних классах
        public abstract string Pay(double amount);

        // Виртуальный метод — можно переопределить в наследниках
        public virtual string ShowInfo()
        {
            // Возвращает строку с информацией о названии и балансе
            return $"{PaymentInstrumentName}: {Balance} руб.";
        }
    }
}