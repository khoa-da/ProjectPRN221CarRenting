using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class CrcOffice
{
    public string LocationId { get; set; } = null!;

    public string? Street { get; set; }

    public string? Number { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? DefaultTel { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual OfficeTel? DefaultTelNavigation { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
