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
    public class SequenceInspection
    {
        public static void Main_SI(string[] args)
		{
			var subject = new Subject<int>();

			//subject.Materialize().Inspect("materialize for any");
			subject.Any(x => x > 1).Inspect("any");
			subject.OnNext(-1);
			subject.OnNext(2);
			subject.OnCompleted();

			Console.ReadLine();

			var values = new List<int> {1, 2, 3, 4, 5};
			values.ToObservable()
				.All(x => x > 0)
				.Inspect("all");

			Console.ReadLine();

			var subj = new Subject<string>();
			subj.Contains("foo").Inspect("Contains");
			subj.OnNext("foo");

			Console.ReadLine();

			// Get element at
			var numbers = Observable.Range(1, 10);
				numbers.ElementAt(5).
				Inspect("element at");

			// Sequence equal
			var seq1 = new Subject<int>();
			var seq2 = new Subject<int>();

			seq1.Materialize().Inspect("seq1");
			seq2.Materialize().Inspect("seq2");

			var seq = seq1.SequenceEqual(seq2);

			seq.Inspect("sequenceEqual");

			seq1.OnNext(1);
			seq2.OnNext(1);

			seq1.OnCompleted();
			seq2.OnCompleted();
		}
    }
}
