using System;
using System.Collections.Generic;
using System.Text;

public class Worker : Human
{
    private const string WORKING_HOURS_PER_DAY_EXCEPTION = "Expected value mismatch! Argument: workHoursPerDay";
    private const string WEEK_SALARY_EXCEPTION = "Expected value mismatch! Argument: weekSalary";
    private const int WORKING_DAYS_PER_WEEK = 5;

    private decimal weekSalary;
    private decimal hoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay)
        :base(firstName, lastName)
    {
        this.HoursPerDay = hoursPerDay;
        this.WeekSalary = weekSalary;
    }
    public decimal HoursPerDay
    {
        get { return this.hoursPerDay; }
        set
        {
            if(value<1 || value >12)
            {
                throw new ArgumentException(WORKING_HOURS_PER_DAY_EXCEPTION);   
            }
            this.hoursPerDay = value;
        }
    }

    public decimal SalaryPerHour
    {
        get
        {
            return (decimal)weekSalary / hoursPerDay / WORKING_DAYS_PER_WEEK;
        }
    }

    public decimal WeekSalary
    {
        get { return this.weekSalary; }
        set
        {
            if(value<10)
            {
                throw new ArgumentException(WEEK_SALARY_EXCEPTION);
            }
            this.weekSalary = value;
        }
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
            .AppendLine($"Last Name: {this.LastName}")
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.HoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");
        return sb.ToString();
    }
}
