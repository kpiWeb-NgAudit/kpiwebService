using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class dimdbextractsV2
{
    public int dim_id_pk { get; set; }

    public int dimdbextrv2_proddatasourceid { get; set; }

    public string dimdbextrv2_comments { get; set; } = null!;

    public string dimdbextrv2_dbselectsqlclause { get; set; } = null!;

    public DateTime dimdbextrv2_dateinsert { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public byte[] dimdbextrv2_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;
}
