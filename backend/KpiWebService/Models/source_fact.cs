using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class source_fact
{
    public int source_id_pk { get; set; }

    public int fact_id_pk { get; set; }

    public int source_fact_nbdaysload { get; set; }

    public string? source_fact_autodoc { get; set; }

    public byte[] source_fact_timestamp { get; set; } = null!;

    public virtual fact fact_id_pkNavigation { get; set; } = null!;

    public virtual source source_id_pkNavigation { get; set; } = null!;
}
