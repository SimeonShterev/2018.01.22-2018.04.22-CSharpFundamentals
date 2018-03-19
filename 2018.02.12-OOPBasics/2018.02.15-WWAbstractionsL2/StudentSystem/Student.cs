using System;
using System.Collections.Generic;

public class Student
{
	private string name;
	private int age;
	private double grade;

	public Student(string name, int age, double grade)
	{
		this.Name = name;
		this.Age = age;
		this.grade = grade;
	}

	public double Grade
	{
		get { return grade; }
		set { grade = value; }
	}

	public int Age
	{
		get { return age; }
		set { age = value; }
	}

	public string Name
	{
		get { return name; }
		set { name = value; }
	}

	public override string ToString()
	{
		return $"{this.name} is {this.age} years old. {GenerateComment(this.grade)}";
	}

	private static string GenerateComment(double grade)
	{
		if (grade >= 5.00)
		{
		return "Excellent student.";
		}
		else if (grade < 5.00 && grade >= 3.50)
		{
			return "Average student.";
		}
		else
		{
			return "Very nice person.";
		}
	}
}