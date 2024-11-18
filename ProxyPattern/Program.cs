using System;
using ProxyPattern.Proxies;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();

            // Выполняем запросы
            Console.WriteLine(proxy.Request("Request1"));
            Console.WriteLine(proxy.Request("Request2"));

            // Повторный запрос для проверки кэша
            Console.WriteLine(proxy.Request("Request1"));

            // Небольшая пауза, чтобы проверить кэш после очистки
            Console.WriteLine("Waiting for cache expiration...");
            System.Threading.Thread.Sleep(11000);

            Console.WriteLine(proxy.Request("Request1"));
            Console.WriteLine(proxy.Request("Request2"));
        }
    }
}
