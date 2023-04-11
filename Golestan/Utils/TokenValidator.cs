using DataLayer.Enums;
using DataLayer.Models;
using DataLayer.Services;
using Golestan.Business.Exceptions;
using Ninject.Activation;

namespace Golestan.Utils;

public static class TokenValidator
{
    public static Token Validate(string? rawToken, params Role[] roles)
    {
        if(rawToken == null) throw new ArgumentNullException();
        if (!TokenRepository.ExistsById(rawToken)) throw new UnAuthorizedException();
        var token = TokenRepository.GetById(rawToken);
        if (token.IsInvalid()) throw new ExpiredTokenException();
        if(!roles.Contains(token.Role)) throw new UnAuthorizedException();
        return token;
    }
}