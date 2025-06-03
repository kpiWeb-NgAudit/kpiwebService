using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class hier_dimcol
{
    public int hier_id_pk { get; set; }

    public int dimcol_id_pk { get; set; }

    public int hierdim_level { get; set; }

    public string hierdim_rdltypepresnamecol { get; set; } = null!;

    public byte[] hier_dimcol_timestamp { get; set; } = null!;

    public virtual dimcolumn dimcol_id_pkNavigation { get; set; } = null!;

    public virtual hierarchy hier_id_pkNavigation { get; set; } = null!;
}
