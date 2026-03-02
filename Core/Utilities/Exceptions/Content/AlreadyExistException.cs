using System;
using System.Text;
using System.Collections.Generic;

namespace Core.Utilities.Exceptions.Content;

public class AlreadyExistException:Exception
{
    public AlreadyExistException(string message):base(message)
    {}
    public AlreadyExistException():base("Already exist!")
    {}
}
