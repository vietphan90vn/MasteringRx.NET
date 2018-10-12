using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MasteringReactiveCourse.Session3
{
	public class SimpleFactoryMethods
	{
		public static void Main_SFM(string[] args)
		{
			// Create a simple observable
			var obs = Observable.Return(32);
			obs.Inspect("Obs");

			// Create an Observable that emits no items but terminates normally
			var obs2 = Observable.Empty<float>();
			obs2.Inspect("Obs 2");

			// Create an Observable that emits no items but does not terminate
			var obs3 = Observable.Never(3);
			obs3.Inspect("obs 3");

			// Create an Observable that emits no items and terminates with an error
			var errorObs = Observable.Throw<string>(new Exception("BBBBBB"));
			errorObs.Inspect("errorObs");
		}
	}
}
