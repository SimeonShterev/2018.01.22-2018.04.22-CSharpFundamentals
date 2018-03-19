public class Grade
{
    private string teacher;
    private int value;

    public Grade(string teacher, int mark)
    {
        this.Teacher = teacher;
        this.Value = mark;
    }

    public int Value
    {
        get { return this.value; }
        set { this.value = value; }
    }

    public string Teacher
    {
        get { return this.teacher; }
        set { this.teacher = value; }
    }

}