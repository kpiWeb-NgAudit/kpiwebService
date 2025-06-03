using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class persp_dimnat
{
    public int persp_id_pk { get; set; }

    public int dim_id_pk { get; set; }

    public byte[] persp_dimnat_timestamp { get; set; } = null!;

    public virtual dimension dim_id_pkNavigation { get; set; } = null!;

    public virtual perspective persp_id_pkNavigation { get; set; } = null!;
}
