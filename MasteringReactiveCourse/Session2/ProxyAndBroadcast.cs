using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Reactive.Linq;

namespace MasteringReactiveCourse.Session2
{
    public class ProxyAndBroadcast
    {
        public static void Main_ProxyAndBroadcast(string[] args)
        {
            var market = new Subject<float>(); // use it as observable
            var marketConsummer = new Subject<float>(); // use it as observable and obsever

            // show marketConsummer
            marketConsummer.Inspect("marketConsummer"); // maket consummer subscribe Console.WriteLine
            market.Inspect("market"); // maket subscribe Console.WriteLine

            using (marketConsummer.SubsribeTo(market))
            {
                market.OnNext(1, 2, 3);
            }

            Console.WriteLine("================================================================");

            using (marketConsummer.SubsribeTo(market))
            {
                marketConsummer.OnNext(4, 5, 6);
            }

            Console.WriteLine("================================================================");
            // We want market consummer filter only value > 8
            // Create a proxy filter
            // market consummer only
            using (market.Where(x => x > 8).Subscribe(marketConsummer))
            {
                market.OnNext(7, 8, 9, 10);
            }
        }
    }
}
