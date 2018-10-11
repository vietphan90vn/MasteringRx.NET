using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MasteringReactiveCourse.Session2
{
    public class ObservableSequenceGenerators
    {
        public static void Main(string[] args)
		{
			var tenToTwenty = Observable.Range(10, 11);
			tenToTwenty.Inspect("Range");

			var generated = Observable.Generate()
		}
    }
}
