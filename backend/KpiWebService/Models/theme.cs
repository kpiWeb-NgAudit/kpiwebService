using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class theme
{
    public string theme_id_pk { get; set; } = null!;

    public string theme_label { get; set; } = null!;

    public byte[] theme_timestamp { get; set; } = null!;

    public virtual ICollection<rdllist> rdllists { get; set; } = new List<rdllist>();
}
