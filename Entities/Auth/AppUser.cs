using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;

using Entities.Concrete;

namespace Entities.Auth;

public class AppUser:IdentityUser
{
    // main
    // public DateTime DateOfBirth {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}

    // relation (one AppUser ↔ one Profile)
    public Profile Profile {get; set;}
}
