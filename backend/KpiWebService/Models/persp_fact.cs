using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class persp_fact
{
    public int persp_id_pk { get; set; }

    public int fact_id_pk { get; set; }

    public byte[] persp_fact_timestamp { get; set; } = null!;

    public virtual fact fact_id_pkNavigation { get; set; } = null!;

    public virtual perspective persp_id_pkNavigation { get; set; } = null!;
}
