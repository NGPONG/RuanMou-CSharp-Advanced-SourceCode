using System;

namespace OOP.DesignerPattern.ProxyPattern
{
    public class Program
    {
        public static void Show()
        {
            {
                Console.WriteLine("**************");
                ISubject subject = new RealSubject();
                subject.DoSomething();
                subject.GetSomething();
            }
            {
                Console.WriteLine("**************");
                ISubject subject = new ProxySubject();
                subject.DoSomething();
                subject.GetSomething();
            }
        }
    }
}
