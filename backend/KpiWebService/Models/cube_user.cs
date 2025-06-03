using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class cube_user
{
    public string cube_id_pk { get; set; } = null!;

    public string user_id_pk { get; set; } = null!;

    public int role_id_pk { get; set; }

    public string cube_user_whensendstatsifadmin { get; set; } = null!;

    public byte[] cube_user_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual role role_id_pkNavigation { get; set; } = null!;

    public virtual user user_id_pkNavigation { get; set; } = null!;
}
