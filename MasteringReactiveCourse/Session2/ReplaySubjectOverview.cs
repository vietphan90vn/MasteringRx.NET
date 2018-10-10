using System;
using System.Reactive;
using System.Reactive.Subjects;
using System.Threading;

namespace MasteringReactiveCourse.Session2
{
    /// <summary>
    /// ReplaySubject emits to any observer all of the items that were emitted by the source Observable(s),
    /// regardless of when the observer subscribes.
    /// </summary>
    public class ReplaySubjectOverview
    {
        public static void Main(string[] args)
        {
            var time = TimeSpan.FromMilliseconds(500f);
            var marketTimespan = new ReplaySubject<float>(time);
            marketTimespan.OnNext(123);
            Thread.Sleep(200);
            marketTimespan.OnNext(234);
            Thread.Sleep(200);
            marketTimespan.OnNext(456);
            Thread.Sleep(200);
            marketTimespan.Inspect("marketTimespan");

            var bufferSize = 3;
            var marketbuffer = new ReplaySubject<float>(bufferSize);
            marketbuffer.OnNext(1, 3, 4, 4, 5, 6, 7);
            marketbuffer.Inspect("market buffer");
        }
    }
}
