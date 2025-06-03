using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class role
{
    public int role_id_pk { get; set; }

    public string role_name { get; set; } = null!;

    public string role_description { get; set; } = null!;

    public bool? role_cubewriteallow { get; set; }

    public bool? role_measures_allowset { get; set; }

    public string? role_custom_role_name { get; set; }

    public string? role_measures_mdxinstruction { get; set; }

    public string cube_id_pk { get; set; } = null!;

    public string? role_comments { get; set; }

    public byte[] role_timestamp { get; set; } = null!;

    public virtual customer cube_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<cube_user> cube_users { get; set; } = new List<cube_user>();

    public virtual ICollection<role_dimcol> role_dimcols { get; set; } = new List<role_dimcol>();
}
