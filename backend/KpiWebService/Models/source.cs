using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class source
{
    public int source_id_pk { get; set; }

    public int source_number { get; set; }

    public string? source_comments { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public byte[] source_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<source_fact> source_facts { get; set; } = new List<source_fact>();
}
