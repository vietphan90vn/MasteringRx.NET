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
	public class Market
	{
		private float price;
		public float Price
		{
			get => price;
			set => price = value;
		}

		public event EventHandler<float> PriceChange;

		public void ChangePrice(float price)
		{
			Price = price;
			PriceChange?.Invoke(this, Price);
		}
	}

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

        public static void Main_CTO(string[] args)
		{
			// Start a method paraller with main thread
			var start = Observable.Start(() => DoSomeStuff("."));

			// Start same method in main thread
			DoSomeStuff("_");

			start.Inspect("start");

			ReadKey();

			// Convert from event partern

			var market = new Market();

			var priceChange = Observable.FromEventPattern<float>(
				h => market.PriceChange += h,
				h => market.PriceChange -= h
			);

			priceChange.Subscribe(x =>
			{
				WriteLine($"Price change {x.EventArgs}");
			});

			market.ChangePrice(1);
			market.ChangePrice(2);
			market.ChangePrice(3);

			// convert from Task
			var t = Task.Factory.StartNew(() => "New task");
			var source = t.ToObservable();
			source.Inspect("Task");

			// convert from IEnumerable
			var numbers = new List<int>(){1, 3, 5, 7};
			var numberOrb = numbers.ToObservable();
			numberOrb.Inspect("numbers");
		}
    }
}
