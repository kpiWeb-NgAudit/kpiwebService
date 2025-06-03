using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class persp_outcalculation
{
    public int persp_id_pk { get; set; }

    public string outcalculation { get; set; } = null!;

    public byte[] persp_outcalculation_timestamp { get; set; } = null!;

    public virtual perspective persp_id_pkNavigation { get; set; } = null!;
}
