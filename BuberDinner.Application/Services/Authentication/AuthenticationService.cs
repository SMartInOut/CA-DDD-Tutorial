using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator _jwtTokenGenrator;
	
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenrator)
    {
        _jwtTokenGenrator = jwtTokenGenrator;
    }
	
    public AuthenticationResult Login(string email, string password)
	{
		return new AuthenticationResult(
			Guid.NewGuid(),
			"firstName",
			"lastName",
			email,
			"token");
	}
	
	public AuthenticationResult Register(string firstName, string lastName, string email, string password)
	{
		// Check if user already exists
		// Create user (generate unique ID)
		// Create JWT token
		var userId = Guid.NewGuid();
		var token = _jwtTokenGenrator.GenerateToken(userId, firstName, lastName);
		
		return new AuthenticationResult(
			Guid.NewGuid(),
			firstName,
			lastName,
			email,
			token);
	}
}