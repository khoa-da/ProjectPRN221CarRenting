using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class CarType
{
    public string TypeId { get; set; } = null!;

    public string? TypeLabel { get; set; }

    public string? TypeDescr { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
