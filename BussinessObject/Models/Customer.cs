using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public int? Ssn { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Mobile { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
