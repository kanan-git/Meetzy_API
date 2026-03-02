using System;
using System.Text;
using System.Collections.Generic;

namespace Core.Utilities.Exceptions.Logic;

public class DatabaseOperationException:Exception
{
    public DatabaseOperationException(string message):base(message)
    {}
    public DatabaseOperationException():base("Logic error!")
    {}
}
