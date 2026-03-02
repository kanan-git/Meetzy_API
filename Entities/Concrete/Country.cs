using System;
using System.Text;
using System.Collections.Generic;

using Entities.Common;

namespace Entities.Concrete;

public class Country:BaseEntity
{
    // main
    public string Name {get; set;} // Azerbaijan, Turkey, United States of America ...
    public string IsoCode {get; set;} // AZ, TR, US ...

    // relation (one Country ← many City)
    public List<City>? Cities {get; set;} = null!;
}
