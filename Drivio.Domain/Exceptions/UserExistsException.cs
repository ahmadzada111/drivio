namespace Drivio.Domain.Exceptions;

public class UserExistsException(string message) : Exception(message);