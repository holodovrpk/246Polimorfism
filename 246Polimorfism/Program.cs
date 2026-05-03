using System.Data; // Подключение пространства имен Data (в этом коде не используется)

namespace _246Polimorfism // Пространство имен проекта
{
    internal class Program // Главный класс программы
    {
        static void Main(string[] args) // Точка входа в программу
        {
            // Список платежных инструментов разных типов
            List<PaymentInstrument> payments = new List<PaymentInstrument>();

            int n = 0; // Переменная для выбора пункта меню

            // Переменные для ввода данных
            string name;
            double ballance, comiss, limit, minimum;

            while (true) // Бесконечный цикл меню
            {
                Console.Clear(); // Очистка консоли

                // Вывод пунктов меню
                Console.WriteLine("1. Добавить карту");
                Console.WriteLine("2. Добавить СБП");
                Console.WriteLine("3. Добавить Е-кошелек");
                Console.WriteLine("4. Вывести все инструменты");
                Console.WriteLine("5. Выполнить оплату");
                Console.WriteLine("6. Вывести только банковский карты");
                Console.WriteLine("0. Выход");
                Console.WriteLine("-----------------------------------");

                Console.Write("Сделайте выбор: ");
                n = Convert.ToInt32(Console.ReadLine()); // Считываем выбор пользователя

                switch (n) // Обработка выбранного пункта меню
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("---- Добавление карты ----");

                            Console.Write("  Название карты: ");
                            name = Console.ReadLine(); // Ввод названия карты

                            Console.Write("  Балланс: ");
                            ballance = Convert.ToDouble(Console.ReadLine()); // Ввод баланса

                            Console.Write("  Комиссия: ");
                            comiss = Convert.ToDouble(Console.ReadLine()); // Ввод комиссии

                            // Создаем объект BankCard и добавляем его в общий список
                            payments.Add(new BankCard(name, ballance, comiss));

                            Console.ReadKey(); // Ожидание нажатия клавиши
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("---- Добавление СБП ----");

                            Console.Write("  Название счета: ");
                            name = Console.ReadLine(); // Ввод названия счета

                            Console.Write("  Балланс: ");
                            ballance = Convert.ToDouble(Console.ReadLine()); // Ввод баланса

                            Console.Write("  Лимит: ");
                            limit = Convert.ToDouble(Console.ReadLine()); // Ввод лимита

                            // Создаем объект SbpAccount и добавляем его в список
                            payments.Add(new SbpAccount(name, ballance, limit));

                            Console.ReadKey();
                            break;
                        }

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("---- Добавление Е-кошелька ----");

                            Console.Write("  Название кошелька: ");
                            name = Console.ReadLine(); // Ввод названия кошелька

                            Console.Write("  Балланс: ");
                            ballance = Convert.ToDouble(Console.ReadLine()); // Ввод баланса

                            Console.Write("  Комиссия: ");
                            comiss = Convert.ToDouble(Console.ReadLine()); // Ввод комиссии

                            Console.Write("  Минимум остаток: ");
                            minimum = Convert.ToDouble(Console.ReadLine()); // Ввод минимального остатка

                            // Создаем объект EWallet и добавляем его в список
                            payments.Add(new EWallet(name, ballance, comiss, minimum));

                            Console.ReadKey();
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("---- Мои деньги ----");

                            // Полиморфизм: у каждого объекта вызывается свой ShowInfo()
                            foreach (PaymentInstrument p in payments)
                            {
                                Console.WriteLine(p.ShowInfo());
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine("---- Оплата ----");

                            Console.Write("Введите сумму оплаты: ");
                            double amount = Convert.ToDouble(Console.ReadLine()); // Сумма оплаты

                            // Полиморфизм: у каждого инструмента вызывается свой Pay()
                            foreach (PaymentInstrument p in payments)
                            {
                                Console.WriteLine(p.Pay(amount));
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("---- Только банковские карты ----");

                            // Выводим только те объекты, которые являются BankCard
                            foreach (PaymentInstrument p in payments)
                            {
                                if (p is BankCard)
                                {
                                    Console.WriteLine(p.ShowInfo());
                                }
                            }

                            Console.ReadKey();
                            break;
                        }

                    case 0:
                        {
                            break; // Выход из switch, но не из while
                        }
                }
            }
        }
    }
}