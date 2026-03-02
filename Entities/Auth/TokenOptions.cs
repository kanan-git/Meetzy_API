using System;
using System.Text;
using System.Collections.Generic;

namespace Entities.Auth;

public class TokenOptions
{
    // main
    public string Audience {get; set;}
    public string Issuer {get; set;}
    public string SecurityKey {get; set;}
    public int AccessTokenExpiration {get; set;}
    public int RefreshTokenExpiration {get; set;}
}
