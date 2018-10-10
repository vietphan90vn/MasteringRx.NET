using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace MasteringReactiveCourse.Session2
{
    public class SubjectOverview
    {
        public static void Main_Subject(string[] args)
        {
            var market = new Subject<float>();
            market.Subscribe(
                f => Console.WriteLine($"Price changed: {f}"),
                () => Console.WriteLine("Complete")
            );

            market.OnNext(1.2f);
            market.OnCompleted();
        }
    }
}
