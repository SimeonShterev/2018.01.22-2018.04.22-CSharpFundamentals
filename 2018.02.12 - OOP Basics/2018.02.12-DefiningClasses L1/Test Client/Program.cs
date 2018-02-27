using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> data = new Dictionary<int, BankAccount>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] commandArgs = command.Split();
            string commandType = commandArgs[0];
            int id = int.Parse(commandArgs[1]);
            switch (commandType)
            {
                case "Create":
                    if (!data.ContainsKey(id))
                    {
                        var account = new BankAccount();
                        account.Id = id;
                        data.Add(id, account);
                    }
                    else
                    {
                        Console.WriteLine("Account already exists");
                    }
                    break;
                case "Deposit":
                    if (CheckAccountExistance(id, data))
                    {
                        int amount = int.Parse(commandArgs[2]);
                        data[id].Deposit(amount);
                    }
                    break;
                case "Withdraw":
                    if (CheckAccountExistance(id, data))
                    {
                        int amount = int.Parse(commandArgs[2]);
                        if (data[id].Balance < amount)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            data[id].Withdraw(amount);
                        }
                    }
                    break;
                case "Print":
                    if(CheckAccountExistance(id, data))
                    {
                        Console.WriteLine(data[id]);
                    }
                    break;
            }
        }
    }
    static bool CheckAccountExistance(int id, Dictionary<int, BankAccount> data)
    {
        if (data.ContainsKey(id))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}

