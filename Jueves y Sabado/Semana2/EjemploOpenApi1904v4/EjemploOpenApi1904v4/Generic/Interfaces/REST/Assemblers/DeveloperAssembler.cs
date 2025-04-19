namespace EjemploOpenApi1904v4.Generic.Interfaces.REST.Assemblers;
using Generic.Domain.Model.Entities;
using Generic.Interfaces.REST.Resources;

public class DeveloperAssembler
{
    /// <summary>
    /// Converts a GreetDeveloperRequest into a Developer entity.
    /// Returns null if the request is invalid (null or contains blank names).
    /// </summary>
    /// <param name="request">The request containing the first and last names may be null.</param>
    /// <returns>A Developer entity if the request is valid, null otherwise.</returns>
    public static Developer? ToEntityFromRequest(GreetDeveloperRequest? request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
        {
            return null;
        }
        return new Developer(request.FirstName, request.LastName);
    }
}