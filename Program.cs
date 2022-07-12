

class MultithreadingConsoleApp
{

    private static void Method()
    {
        Thread.Sleep(new Random().Next(1000, 5000));
        Console.WriteLine($"Работает поток №{Task.CurrentId}");
    }

    private static void Method(object o)
    {
        var id = (string)o;
        Thread.Sleep(new Random().Next(1000, 5000));
        Console.WriteLine($"Работает поток: {id}");
    }

    private static void Main()
    {

        Console.WriteLine("Main thread active");

        var task1 = new Task(Method);
        var task2 = new Task(Method);
        var task3 = new Task(Method);
        var task4 = new Task(Method);
        var task5 = new Task(Method);
        var task6 = new Task(Method);

        task1.Start();
        task2.Start();
        task3.Start();
        task4.Start();
        task5.Start();
        task6.Start();

        var task7 = new TaskFactory().StartNew(Method);
        var task8 = new TaskFactory().StartNew(Method);

        var task12 = Task.Run(() => Method("task12"));
        var task34 = Task.Run(() => Method("task34"));


        Task.WaitAll(task1, task2, task3, task4, task5, task6, task7, task12, task34);

        Console.WriteLine("Main thread deactive");
    }
}