using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class dimension
{
    public int dim_id_pk { get; set; }

    public string dim_tname { get; set; } = null!;

    public string dim_dbfetch { get; set; } = null!;

    public int? dimdbextr_id_pk { get; set; }

    public string dim_proccube { get; set; } = null!;

    public string dim_visible { get; set; } = null!;

    public string dim_shortcubename { get; set; } = null!;

    public string dim_shortpresname { get; set; } = null!;

    public int dim_workorder { get; set; }

    public string dim_cubetype { get; set; } = null!;

    public DateTime dim_lastupdate { get; set; }

    public int dim_nbdayskeep { get; set; }

    public string dim_deleteorphean { get; set; } = null!;

    public int? dim_limitnbrowsprocessed { get; set; }

    public string? dim_comments { get; set; }

    public string dim_countmeasuregroup { get; set; } = null!;

    public int dim_dimcolrefsvirtuals { get; set; }

    public int dim_dimcolrefsvirtuals2 { get; set; }

    public int dim_dimcolrefsvirtuals3 { get; set; }

    public int dim_dimcolrefsvirtuals4 { get; set; }

    public int dim_dimcolrefsvirtuals5 { get; set; }

    public int dim_dimcolrefsvirtuals6 { get; set; }

    public int dim_dimcolrefsvirtuals7 { get; set; }

    public string dim_dimversion { get; set; } = null!;

    public string dim_dimexistquotes { get; set; } = null!;

    public string cube_id_pk { get; set; } = null!;

    public byte[] dim_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<dimcolumn> dimcolumns { get; set; } = new List<dimcolumn>();

    public virtual ICollection<hierarchy> hierarchies { get; set; } = new List<hierarchy>();

    public virtual ICollection<persp_dimnat> persp_dimnats { get; set; } = new List<persp_dimnat>();
}
