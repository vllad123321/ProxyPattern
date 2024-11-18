
using System.Timers;
using ProxyPattern.Interfaces;
using ProxyPattern.RealSubjects;

namespace ProxyPattern.Proxies
{
    public class Proxy : ISubject
    {
        private readonly RealSubject _realSubject;
        private readonly Dictionary<string, string> _cache = new();
        private readonly System.Timers.Timer _cacheExpirationTimer;

        public Proxy()
        {
            _realSubject = new RealSubject();

       
            _cacheExpirationTimer = new System.Timers.Timer(10000);
            _cacheExpirationTimer.Elapsed += ClearCache;
            _cacheExpirationTimer.Start();
        }

        public string Request(string request)
        {
            
            if (!CheckAccess())
            {
                Console.WriteLine("Proxy: Access denied.");
                return "Access denied.";
            }

            // Проверка кэша
            if (_cache.ContainsKey(request))
            {
                Console.WriteLine($"Proxy: Returning cached response for \"{request}\".");
                return _cache[request];
            }

            // Запрос к RealSubject
            Console.WriteLine("Proxy: Forwarding request to RealSubject...");
            string response = _realSubject.Request(request);

            // Сохранение в кэш
            _cache[request] = response;
            return response;
        }

        private bool CheckAccess()
        {
        
            return DateTime.Now.Second % 2 == 0;
        }

        private void ClearCache(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Proxy: Clearing cache...");
            _cache.Clear();
        }
    }
}
