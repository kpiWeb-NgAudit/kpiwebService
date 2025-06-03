using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class rdllist
{
    public int rdllist_id_pk { get; set; }

    public string rdllist_name { get; set; } = null!;

    public string theme_id_pk { get; set; } = null!;

    public string rdltype_id_pk { get; set; } = null!;

    public string rdllist_description { get; set; } = null!;

    public string rdllist_code { get; set; } = null!;

    public string cube_id_pk { get; set; } = null!;

    public byte[] rdllist_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual rdltype rdltype_id_pkNavigation { get; set; } = null!;

    public virtual theme theme_id_pkNavigation { get; set; } = null!;
}
