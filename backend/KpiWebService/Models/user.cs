using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class user
{
    public string user_id_pk { get; set; } = null!;

    public string user_firstname { get; set; } = null!;

    public string user_lastname { get; set; } = null!;

    public string user_email { get; set; } = null!;

    public string user_type { get; set; } = null!;

    public string user_rbuilder { get; set; } = null!;

    public string user_rptadmin { get; set; } = null!;

    public string? user_password { get; set; }

    public string user_targetsite { get; set; } = null!;

    public string user_datamartaccess { get; set; } = null!;

    public byte[] user_timestamp { get; set; } = null!;

    public virtual ICollection<cube_user> cube_users { get; set; } = new List<cube_user>();
}
