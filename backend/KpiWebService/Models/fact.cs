using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class fact
{
    public int fact_id_pk { get; set; }

    public string fact_tname { get; set; } = null!;

    public string fact_type { get; set; } = null!;

    public int? factdbextr_id_pk { get; set; }

    public string fact_proccube { get; set; } = null!;

    public string fact_shortcubename { get; set; } = null!;

    public string fact_shortpresname { get; set; } = null!;

    public int fact_workorder { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public string? fact_factdatafiletype { get; set; }

    public string? fact_factdatafilename { get; set; }

    public bool? fact_factdatafilecheckunicity { get; set; }

    public string fact_zonespe { get; set; } = null!;

    public DateTime fact_lastupdate { get; set; }

    public string? fact_comments { get; set; }

    public string fact_partitiontype { get; set; } = null!;

    public byte[] fact_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<factcolumn> factcolumns { get; set; } = new List<factcolumn>();

    public virtual ICollection<persp_fact> persp_facts { get; set; } = new List<persp_fact>();

    public virtual ICollection<source_fact> source_facts { get; set; } = new List<source_fact>();
}
