using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class factdbextractsV2
{
    public int fact_id_pk { get; set; }

    public int factdbextrv2_proddatasourceid { get; set; }

    public string factdbextrv2_comments { get; set; } = null!;

    public string factdbextrv2_dbselectsqlclause { get; set; } = null!;

    public DateTime factdbextrv2_dateinsert { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public byte[] factdbextrv2_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;
}
