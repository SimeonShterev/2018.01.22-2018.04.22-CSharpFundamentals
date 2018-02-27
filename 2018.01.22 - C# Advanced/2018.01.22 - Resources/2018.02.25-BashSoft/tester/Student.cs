using System.Collections.Generic;

public class Student
{
    private string name;
    private List<Grade> grades = new List<Grade>();
   
    public Student(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public IReadOnlyCollection<Grade> Grades
    {
        get
        {
            return new List<Grade>(this.grades);
        }
    }

    public void AddGrade(Grade grade)
    {
        this.grades.Add(grade);
    }
}