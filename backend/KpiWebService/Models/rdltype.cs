using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class rdltype
{
    public string rdltype_id_pk { get; set; } = null!;

    public string rdltype_label { get; set; } = null!;

    public string rdlgroup_id_pk { get; set; } = null!;

    public byte[] rdltype_timestamp { get; set; } = null!;

    public virtual rdlgroup rdlgroup_id_pkNavigation { get; set; } = null!;

    public virtual ICollection<rdllist> rdllists { get; set; } = new List<rdllist>();
}
