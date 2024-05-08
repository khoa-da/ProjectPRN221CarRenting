using System;
using System.Collections.Generic;

namespace BussinessObject.Models;

public partial class OfficeTel
{
    public int DefaultTel { get; set; }

    public int? Tel1 { get; set; }

    public int? Tel2 { get; set; }

    public int? Tel3 { get; set; }

    public virtual ICollection<CrcOffice> CrcOffices { get; set; } = new List<CrcOffice>();
}
