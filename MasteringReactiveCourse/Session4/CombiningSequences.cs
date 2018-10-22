using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Timers;
using System.Threading.Tasks;
using System.Reactive.Threading.Tasks;

namespace MasteringReactiveCourse.Session4
{
    public class CombiningSequences
    {
		public static void Main_CS(string[] args)
		{
			// Combine latest
			var mechanical = new BehaviorSubject<bool>(true);
			var electrical = new BehaviorSubject<bool>(true);
			var electronic = new BehaviorSubject<bool>(true);

			mechanical.Inspect("mechanical");
			electrical.Inspect("electrical");
			electronic.Inspect("electronic");

			Observable.CombineLatest(mechanical, electrical, electronic)
				.Select(values => values.All(x => x))
				.Inspect("Is the system ok?");

			mechanical.OnNext(false);

			Console.ReadLine();

			// Zip
			var digits = Observable.Range(0, 10);
			var letters = Observable.Range(0, 10)
				.Select(x => (char)('A' + x));

			var zip = letters.Zip(digits, (letter, digit) => $"{letter}{digit}");
			zip.Inspect("zip");

			Console.ReadLine();

			// And combine with Observable.When
			var passwords = "!@#$%^&*()_+".ToCharArray().ToObservable();
			var and = Observable.When(passwords.And(letters).And(digits)
				.Then((digit, letter, symbol) => $"{digit}{letter}{symbol}")
			);

			and.Inspect("and");
			Console.ReadLine();

			// Concat, Repeat, Start With
			var s1 = Observable.Range(1, 3);
			var s2 = Observable.Range(4, 3);

			s1.Concat(s2).Repeat(2).StartWith(-1, 0).Inspect("Concat + repeat + StartWith (-1, 0)");

			Console.ReadLine();

			// Amb: emit all of the items from only first Observable
			// discard others
			var seq1 = new Subject<int>();
			var seq2 = new Subject<int>();
			var seq3 = new Subject<int>();

			var amb = seq1.Amb(seq2).Amb(seq3);
			amb.Inspect("amb");

			seq3.OnNext(0);  // result 0 7 8 9

			seq1.OnNext(1, 2, 3);
			seq2.OnNext(4, 5, 6);
			seq3.OnNext(7, 8, 9);

			// Merge
			var foo = new Subject<long>();
			var bar = new Subject<long>();
			var baz = Observable.Interval(TimeSpan.FromSeconds(0.5)).Take(5);

			foo.Merge(bar).Merge(baz).Inspect("Merge");

			foo.OnNext(100);
			Thread.Sleep(1000);
			bar.OnNext(10);
			Thread.Sleep(1000);
			foo.OnNext(1000);
			Thread.Sleep(1000);
		}
    }
}
