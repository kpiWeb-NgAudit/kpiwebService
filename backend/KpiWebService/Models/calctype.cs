using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class calctype
{
    public string calctype_type { get; set; } = null!;

    public string calctype_comments { get; set; } = null!;

    public byte[] calctype_timestamp { get; set; } = null!;

    public virtual ICollection<calctype_factcol> calctype_factcols { get; set; } = new List<calctype_factcol>();
}
