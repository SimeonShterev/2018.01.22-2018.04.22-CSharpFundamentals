using System;

class Program
{
    static void Main(string[] args)
    {
        Student student = ParseStudent();
        Worker worker = ParseWorker();
        Console.WriteLine(student);
        Console.WriteLine(worker);
    }

    private static Worker ParseWorker()
    {
        try
        {
            string[] workerInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = workerInput[0];
            string lastName = workerInput[1];
            decimal salary = decimal.Parse(workerInput[2]);
            decimal workingHoursPerDay = decimal.Parse(workerInput[3]);
            Worker worker = new Worker(firstName, lastName, salary, workingHoursPerDay);
            return worker;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        throw new NotImplementedException();
    }

    private static Student ParseStudent()
    {
        try
        {
            string[] studentInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string firstName = studentInput[0];
            string lastName = studentInput[1];
            string facNum = studentInput[2];
            Student student = new Student(firstName, lastName, facNum);
            return student;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            Environment.Exit(0);
        }
        throw new NotImplementedException();
    }
}