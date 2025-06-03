using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class calctype_factcol
{
    public int factcol_id_pk { get; set; }

    public string calctype_type { get; set; } = null!;

    public string calcfactcol_cubesuffix { get; set; } = null!;

    public string calcfactcol_pressuffix { get; set; } = null!;

    public string calcfactcol_visible { get; set; } = null!;

    public string? calcfactcol_typeforformat { get; set; }

    public string? calcfactcol_showtotalinrdl { get; set; }

    public string? calcfactcol_mdxformula { get; set; }

    public string? calcfactcol_comments { get; set; }

    public string? calcfactcol_displayfolder { get; set; }

    public byte[] calcfactcol_timestamp { get; set; } = null!;

    public virtual calctype calctype_typeNavigation { get; set; } = null!;

    public virtual factcolumn factcol_id_pkNavigation { get; set; } = null!;
}
