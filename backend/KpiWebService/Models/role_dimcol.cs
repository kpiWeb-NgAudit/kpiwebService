using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class role_dimcol
{
    public int role_id_pk { get; set; }

    public int dimcol_id_pk { get; set; }

    public bool roledimcol_allowset { get; set; }

    public string? roledimcol_mdxinstruction { get; set; }

    public bool roledimcol_visualtotals { get; set; }

    public byte[] roledimcol_timestamp { get; set; } = null!;

    public virtual dimcolumn dimcol_id_pkNavigation { get; set; } = null!;

    public virtual role role_id_pkNavigation { get; set; } = null!;
}
