namespace EjemploOpenApi1904v4.Generic.Domain.Model.Entities;

public class Developer
{
    
    /// <summary>
    /// Gets the unique identifier for the developer.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets the developer's first name, trimmed of whitespace.
    /// </summary>
    public string FirstName { get; }

    /// <summary>
    /// Gets the developer's last name, trimmed of whitespace.
    /// </summary>
    public string LastName { get; }

    /// <summary>
    /// Initializes a new instance of the Developer class with trimmed names.
    /// </summary>
    /// <param name="firstName">The developer's first name, may be null or contain whitespace.</param>
    /// <param name="lastName">The developer's last name, may be null or contain whitespace.</param>
    public Developer(string firstName, string lastName)
    {
        FirstName = string.IsNullOrWhiteSpace(firstName) ? "" : firstName.Trim();
        LastName = string.IsNullOrWhiteSpace(lastName) ? "" : lastName.Trim();
    }

    /// <summary>
    /// Returns the full name by concatenating first and last names with a space.
    /// </summary>
    /// <returns>The full name as a trimmed string.</returns>
    public string GetFullName() => $"{FirstName} {LastName}".Trim();

    /// <summary>
    /// Checks if either the first name or last name is empty after trimming.
    /// </summary>
    /// <returns>True if any name is empty, false otherwise.</returns>
    public bool IsAnyNameEmpty() => string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName);

}