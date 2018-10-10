using System;
using System.Reactive;
using System.Reactive.Subjects;

namespace MasteringReactiveCourse.Session2
{
    public class Unsubcribing
    {
        public static void Main_Unsubcribing(string[] args)
        {
            var sensor = new Subject<float>();

            // sensor.Subscribe return a Dispose
            using (sensor.Subscribe(Console.WriteLine))
            {
                sensor.OnNext(1);
                sensor.OnNext(2);
                sensor.OnNext(3);
            }

            // if not use using, you can call Dispose() directly
            // sensor.Dispose();

            // Not affect because the sensor was dispose in using brake
            sensor.OnNext(4);
        }
    }
}
