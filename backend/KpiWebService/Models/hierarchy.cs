using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class hierarchy
{
    public int hier_id_pk { get; set; }

    public string hier_cubename { get; set; } = null!;

    public string hier_visiblecube { get; set; } = null!;

    public string hier_rdlshowfilter { get; set; } = null!;

    public int dim_id_pk { get; set; }

    public int hier_workorder { get; set; }

    public string? hier_comments { get; set; }

    public byte[] hier_timestamp { get; set; } = null!;

    public virtual dimension dim_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<hier_dimcol> hier_dimcols { get; set; } = new List<hier_dimcol>();
}
