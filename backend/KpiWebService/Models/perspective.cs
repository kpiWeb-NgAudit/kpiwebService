using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class perspective
{
    public int persp_id_pk { get; set; }

    public string persp_name { get; set; } = null!;

    public string? persp_comments { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public byte[] persp_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<persp_dimnat> persp_dimnats { get; set; } = new List<persp_dimnat>();

    public virtual ICollection<persp_fact> persp_facts { get; set; } = new List<persp_fact>();

    public virtual ICollection<persp_outcalculation> persp_outcalculations { get; set; } = new List<persp_outcalculation>();
}
