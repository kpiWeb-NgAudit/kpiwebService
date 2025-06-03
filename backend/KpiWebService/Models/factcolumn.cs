using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class factcolumn
{
    public int factcol_id_pk { get; set; }

    public string factcol_cname { get; set; } = null!;

    public string factcol_use { get; set; } = null!;

    public string factcol_type { get; set; } = null!;

    public int? dimcol_id_pk { get; set; }

    public string factcol_shortcubename { get; set; } = null!;

    public string factcol_shortpresname { get; set; } = null!;

    public int factcol_workorder { get; set; }

    public string factcol_cubevisible { get; set; } = null!;

    public string factcol_cubeaggregat { get; set; } = null!;

    public string? factcol_cubeformula { get; set; }

    public string factcol_indexdatamart { get; set; } = null!;

    public string? factcol_comments { get; set; }

    public string? factcol_displayfolder { get; set; }

    public int fact_id_pk { get; set; }

    public byte[] factcol_timestamp { get; set; } = null!;

    public virtual ICollection<calctype_factcol> calctype_factcols { get; set; } = new List<calctype_factcol>();

    public virtual dimcolumn? dimcol_id_pkNavigation { get; set; }

    public virtual fact fact_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<rdlgroup_factcol> rdlgroup_factcols { get; set; } = new List<rdlgroup_factcol>();
}
