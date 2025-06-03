using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class cubeset
{
    public int cubeset_id_pk { get; set; }

    public string cubeset_name { get; set; } = null!;

    public string cubeset_cubename { get; set; } = null!;

    public string cubeset_asinstruction { get; set; } = null!;

    public string cubeset_hidden { get; set; } = null!;

    public string cubeset_dynamic { get; set; } = null!;

    public string cubeset_rdlshowfilter { get; set; } = null!;

    public int cubeset_presorder { get; set; }

    public string? cubeset_comments { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public byte[] cubeset_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;
}
