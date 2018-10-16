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
			Observable.Return<int>(2).Inspect("SDSD");
		}
    }
}
