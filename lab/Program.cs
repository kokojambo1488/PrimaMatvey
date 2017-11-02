using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab {
    class Program {
        static void Main(string[] args) {
            Console.Write("Количество клиентов: ");
            int n = Convert.ToInt32(Console.ReadLine());

            if (n <= 0) {
                Console.WriteLine("Неверное количество");
                return;
            }

            
            Random rand = new Random();
            Client[] clients = new Client[n];

            //Генерация чтобы не вводить кучу данных
            for (int i = 0; i < clients.Length; ++i) {
                clients[i] = new Client();
                
                clients[i].Name = "Имя" + i;
                clients[i].Surname = "Фамилия" + i;
                clients[i].City = "Город" + i;
                clients[i].Phone = "Телефон" + i;

                clients[i].Accounts = new Account[rand.Next(1, 10)];

                //Также заполняем рандомно
                for (int j = 0; j < clients[i].Accounts.Length; ++j) {
                    clients[i].Accounts[j] = new Account();
                    Account account = clients[i].Accounts[j];

                    account.Balance = rand.Next(-500, 2000);
                    account.Bank = "Банк" + i;

                    //30% шанс
                    account.IsBlocked = rand.Next(1, 10) <= 3;
                }
            }

            Console.WriteLine("Клиенты:");

            foreach (Client client in clients) {
                Console.WriteLine(client.ToString() + "\n");
            }

            Console.WriteLine("\n\nКлиенты после сортировки счетов:");

            foreach (Client client in clients) {
                Array.Sort(client.Accounts);
                Console.WriteLine(client.ToString() + "\n");
            }

            Console.WriteLine("\n\nСумма счетов клиентов:");

            foreach (Client client in clients) {
                Console.WriteLine("{0} {1}: Сумма отрицательных - {2}, положительных - {3}, всех - {4}",
                    client.Name, client.Surname, client.SumNeg(), client.SumPos(), client.Sum());
            }

            int randomClient = rand.Next(clients.Length);
            int randomAccount = rand.Next(clients[randomClient].Accounts.Length);
            Account search = clients[randomClient].Accounts[randomAccount];

            Console.WriteLine("\n\nВозьмем случайно клиента номер {0} и найдем у него счет с балансом {1}", randomClient, search.Balance);

            int winner = Array.BinarySearch(clients[randomClient].Accounts, search);

            Console.WriteLine("Этот счет: {0}", winner);

            Console.ReadLine();
        }
    }
}
