using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class EmptyResultException : ApplicationException
{
    public EmptyResultException() : base()
    { }
    public EmptyResultException(string message) : base(message)
    { }
}
