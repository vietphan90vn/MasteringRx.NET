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
    public class SequenceAggregation
    {
        public static void Main_SA(string[] args)
		{
			var sub = new Subject<int>();

			sub.Catch((Exception exception) => {
				Console.WriteLine("Exception" + exception.Message);
				return sub;
			})
			.Inspect("sub");

			sub.OnNext(1, 2, 3);
			sub.OnError(new Exception("oops"));
		}
    }
}
