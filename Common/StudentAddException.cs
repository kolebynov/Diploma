using System;

public class StudentAddException : ApplicationException
{
    public StudentDataContainer.CheckDataResult Result { get; }

    public StudentAddException(StudentDataContainer.CheckDataResult result, 
        string message) : base(message)
    {
        Result = result;
    }
    public StudentAddException(string message) : this(null, message)
    { }
    public StudentAddException(StudentDataContainer.CheckDataResult result)
    { }
    public StudentAddException()
    { }
}
