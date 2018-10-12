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

namespace MasteringReactiveCourse.Session3
{
    public class ConvertIntoObservable
    {
		public static void DoSomeStuff(string outValue)
		{
			WriteLine("Starting work...");
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(200);
				Write(outValue);
			}
		}

        public static void Main(string[] args)
		{
			// Start a method paraller with main thread
			var start = Observable.Start(() => DoSomeStuff("."));

			// Start same method in main thread
			DoSomeStuff("_");

			start.Inspect("start");

			ReadKey();
		}
    }
}
