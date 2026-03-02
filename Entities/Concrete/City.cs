using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class City:BaseEntity
{
    // main
    public string Name {get; set;}

    // relation (many City → one Country)
    public Guid CountryId {get; set;}
    public Country Country {get; set;}

    // relation (one City ← many Profile)
    public List<Profile>? Profiles {get; set;} = null!;
}
