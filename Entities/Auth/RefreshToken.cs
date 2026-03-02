using System;
using System.Text;
using System.Collections.Generic;

namespace Entities.Auth;

public class RefreshToken
{
    // main
    public string Token {get; set;}
    public string RevokedByIp {get; set;}
    public string ReplacedByToken {get; set;}
    public DateTime Expiration {get; set;}
    public DateTime RevokedAt {get; set;}

    // relation (one AppUser ← many RefreshToken)
    public string AppUserId {get; set;}
    public AppUser AppUser {get; set;}
}
