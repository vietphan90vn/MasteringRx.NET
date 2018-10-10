using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace MasteringReactiveCourse
{
    public static class ExtensionMethods
    {
        public static IDisposable Inspect<T>(this IObservable<T> self, string name)
        {
            return self.Subscribe(
                f => Console.WriteLine($"{name} has generate {f}"),
                ex => Console.WriteLine($"{name} has generate exception {ex}"),
                () => Console.WriteLine($"{name} has completed")
            );
        }

        public static IDisposable SubsribeTo<T>(this IObserver<T> observer, IObservable<T> observable)
        {
            return observable.Subscribe(observer);
        }

        public static void OnNext<T>(this IObserver<T> observer,params T[] fs)
        {
            foreach (var f in fs)
            {
                observer.OnNext(f);
            }
        }
    }
}
