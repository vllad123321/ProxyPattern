

namespace ProxyPattern.RealSubjects
{
    public class RealSubject : ProxyPattern.Interfaces.ISubject
    {
        public string Request(string request)
        {
            Console.WriteLine($"RealSubject: Processing request \"{request}\"...");
            return $"Response from RealSubject for \"{request}\"";
        }
    }
}
