namespace Core.Utilities.Exceptions.Logic;

public class ResourceNotFoundException:Exception
{
    public ResourceNotFoundException(string message):base(message)
    {}
    public ResourceNotFoundException():base("Not found!")
    {}
}
