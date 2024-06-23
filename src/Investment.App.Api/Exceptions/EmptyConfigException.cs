namespace Investment.App.Api.Exceptions;

public class EmptyConfigException : Exception
{
    public EmptyConfigException(string field)
    : base($"The following field is empty: {field}, Please check")
    {
    }

}
