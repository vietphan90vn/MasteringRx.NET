using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MasteringReactiveCourse.Session3
{
    public class ObservableSequenceGenerators
    {
        public static void Main_OSG(string[] args)
		{
			var tenToTwenty = Observable.Range(10, 11);
			tenToTwenty.Inspect("Range");

			var generated = Observable.Generate(
				1,
				value => value < 100,
				value => value * value + 1,
				value => $"[{value}]"
			);
			generated.Inspect("Generated");

			// // Interval examples
			// var interval = Observable.Interval(TimeSpan.FromMilliseconds(500));
			// using (interval.Inspect("interval"))
			// {
			// 	Console.ReadLine();
			// }

			// Procedure the observable by time
			var timer = Observable.Timer(
				TimeSpan.FromSeconds(2),
				TimeSpan.Zero
			);
			timer.Inspect("timer");
			Console.ReadLine();
		}
    }
}
