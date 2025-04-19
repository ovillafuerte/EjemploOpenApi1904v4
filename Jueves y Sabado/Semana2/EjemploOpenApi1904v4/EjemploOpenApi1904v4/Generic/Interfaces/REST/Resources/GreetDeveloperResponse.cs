namespace EjemploOpenApi1904v4.Generic.Interfaces.REST.Resources;
public record GreetDeveloperResponse(Guid? Id, string? FullName, string Message)
{
    /// <summary>
    /// Constructs a response with only a message, used for anonymous greetings.
    /// </summary>
    /// <param name="message">The greeting message, typically for anonymous cases.</param>
    public GreetDeveloperResponse(string message) : this(null, null, message) { }
}