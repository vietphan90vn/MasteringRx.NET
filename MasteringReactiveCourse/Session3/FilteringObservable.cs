using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

using static System.Console;
using System.Threading.Tasks;
using System.Reactive.Threading.Tasks;

namespace MasteringReactiveCourse.Session3
{
    public class FilteringObservable
    {
        public static void Main(string[] args)
		{
			// Start a method paraller with main thread
			var start = Observable.Range(-5, 15);

			var f1 = start.Where(f => f < 0);
			//var f2 = start.SkipLast(2);
			var f3 = start.SkipWhile(f => f > 0);
			// var f4 = start.SkipLast(2);
			// var f5 = start.IgnoreElements();

			f1.Inspect("Where");
			f3.Inspect("Skip While");

			var f4 = f1.SkipUntil(Observable.Range(3, 10));
			f4.Inspect("f4");

			new List<int> {1, 1, 2, 2, 3, 3, 2, 2}
			.ToObservable()
			.DistinctUntilChanged()
			//.IgnoreElements() // later, ignores actual elements, same as Where(_ => false)
			.Subscribe(
				WriteLine,
				() => WriteLine("Completed")
			);
		}
    }
}
