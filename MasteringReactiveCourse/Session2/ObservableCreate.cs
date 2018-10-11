using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MasteringReactiveCourse.Session2
{
    public class ObservableCreate
    {
		// Use Observable.Created instead of Subject
		private static IObservable<string> Blocking()
		{
			var subject = new ReplaySubject<string>();
			subject.OnNext("Foo", "Bar");
			subject.OnCompleted();
			Thread.Sleep(2000);

			return subject;
		}

        public static void Main(string[] args)
		{
			Blocking().Inspect("Blocking");

			Observable.Create<string>(observer =>
			{
				observer.OnNext("Foo", "Bar");
				observer.OnCompleted();
				Thread.Sleep(2000);
				return Disposable.Empty;

			}).Inspect("Blocking 2");

			var meaningOfLife = Observable.Return(43);

			// Fully create observable
			var timerObs = Observable.Create<string>(o =>
			{
				var timer = new Timer(1000);
				timer.Elapsed += (sender, e) => o.OnNext($"tick {e.SignalTime}");
				timer.Elapsed += TimerOnElapsed;
				timer.Start();

				return () =>
				{
					timer.Elapsed -= TimerOnElapsed;
					timer.Dispose();
				};
			});

			var sub = timerObs.Inspect("Timer");
			Console.ReadLine();

			sub.Dispose();
			Console.WriteLine();
		}

		private static void TimerOnElapsed(object sender, ElapsedEventArgs arg)
		{
			Console.WriteLine($"tock {arg.SignalTime}");
		}
    }
}
