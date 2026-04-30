using System.Data;

namespace _246Polimorfism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PaymentInstrument> payments = new List<PaymentInstrument>();

            int n = 0;

            string name;
            double ballance, comiss, limit, minimum;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить карту");
                Console.WriteLine("2. Добавить СБП");
                Console.WriteLine("3. Добавить Е-кошелек");
                Console.WriteLine("4. Вывести все инструменты");
                Console.WriteLine("5. Выполнить оплату");
                Console.WriteLine("6. Вывести только банковский карты");
                Console.WriteLine("0. Выход");
                Console.WriteLine("-----------------------------------");

                Console.Write("Сделайте выбор: ");
                n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1: {
                            Console.Clear();
                            Console.WriteLine("---- Добавление карты ----");
                            Console.Write("  Название карты: ");
                            name = Console.ReadLine();
                            Console.Write("  Балланс: ");
                            ballance = Convert.ToDouble(Console.ReadLine());
                            Console.Write("  Комиссия: ");
                            comiss = Convert.ToDouble(Console.ReadLine());
                            
                            payments.Add(new BankCard(name, ballance, comiss));

                            Console.ReadKey();
                            break; 
                        }
                    case 2: {
                            Console.Clear();
                            Console.WriteLine("---- Добавление СБП ----");
                            Console.Write("  Название счета: ");
                            name = Console.ReadLine();
                            Console.Write("  Балланс: ");
                            ballance = Convert.ToDouble(Console.ReadLine());
                            Console.Write("  Лимит: ");
                            limit = Convert.ToDouble(Console.ReadLine());

                            payments.Add(new SbpAccount(name, ballance, limit));

                            Console.ReadKey();

                            break; }
                    case 3: {
                            Console.Clear();
                            Console.WriteLine("---- Добавление Е-кошелька ----");
                            Console.Write("  Название кошелька: ");
                            name = Console.ReadLine();
                            Console.Write("  Балланс: ");
                            ballance = Convert.ToDouble(Console.ReadLine());
                            Console.Write("  Комиссия: ");
                            comiss = Convert.ToDouble(Console.ReadLine());

                            Console.Write("  Минимум остаток: ");
                            minimum = Convert.ToDouble(Console.ReadLine());

                            payments.Add(new EWallet(name, ballance, comiss, minimum));

                            Console.ReadKey();


                            break; }
                    case 4: {
                            Console.Clear();
                            Console.WriteLine("---- Мои деньги ----");

                            foreach (PaymentInstrument p in payments)
                            {
                                Console.WriteLine(p.ShowInfo());
                            }

                            Console.ReadKey();
                            break; }
                    case 5: {
                            Console.Clear();
                            Console.WriteLine("---- Оплата ----");

                            Console.Write("Введите сумму оплаты: ");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            foreach (PaymentInstrument p in payments)
                            {
                                Console.WriteLine(p.Pay(amount));
                            }

                            Console.ReadKey();

                            break; }
                    case 6: {

                            Console.Clear();
                            Console.WriteLine("---- Только банковские карты ----");
                            
                            foreach (PaymentInstrument p in payments)
                            {
                                if (p is BankCard)
                                {
                                   Console.WriteLine(p.ShowInfo());
                                }
                            }

                            Console.ReadKey();

                            break; }
                    case 0: { break; }

                }

            }

        }
    }
}
