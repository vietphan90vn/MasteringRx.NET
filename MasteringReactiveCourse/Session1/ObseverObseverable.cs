using System;
using System.Reactive;

namespace MasteringReactiveCourse.Session1
{
    public class MyObsever : IObserver<float>
    {
        public void OnCompleted()
        {
            Console.WriteLine("On complete");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"On error: {error}");
        }

        public void OnNext(float value)
        {
            Console.WriteLine($"On next: {value}");
        }
    }

    public class MyObseverable : IObservable<float>
    {
        public IDisposable Subscribe(IObserver<float> observer)
        {
            return null;
        }
    }

    public class ObseverObseverable
    {
        public static void Main_ObseverObseverable(string[] args)
        {
            MyObseverable obseverable = new MyObseverable();
            MyObsever obsever = new MyObsever();
            obseverable.Subscribe(obsever);

            obsever.OnNext(2f);
            obsever.OnError(new Exception("obs"));
            obsever.OnCompleted();
        }
    }
}
