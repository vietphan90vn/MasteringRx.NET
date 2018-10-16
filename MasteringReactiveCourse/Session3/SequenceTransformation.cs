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
    public class SequenceTransformation
    {
        public static void Main(string[] args)
		{
			var subj = new Subject<object>();

			var subOfTypeFloat = subj.OfType<float>();
			subOfTypeFloat.Inspect("OfType<float>");

			var subCastFloat = subj.Cast<float>();
			subCastFloat.Inspect("Cast<float>");

			subj.OnNext(1f, 2, 3);

			Console.ReadLine();

			var seq = Observable.Interval(TimeSpan.FromSeconds(1f));
			seq.Inspect("Seq");

			var timeStamp = seq.Timestamp();
			timeStamp.Inspect("TimeStamp");

			var timeInterval = seq.TimeInterval();
			timeInterval.Inspect("TimeInterval");

			Console.ReadLine();

			// Get debug info
			var seq2 = Observable.Range(0, 4);
			var seq2Materialize = seq2.Materialize();

			seq2Materialize.Inspect("Materialize");

			Console.ReadLine();
		}
    }
}
