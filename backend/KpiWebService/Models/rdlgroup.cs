using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class rdlgroup
{
    public string rdlgroup_id_pk { get; set; } = null!;

    public string rdlgroup_label { get; set; } = null!;

    public byte[] rdlgroup_timestamp { get; set; } = null!;

    public virtual ICollection<rdlgroup_factcol> rdlgroup_factcols { get; set; } = new List<rdlgroup_factcol>();

    public virtual ICollection<rdltype> rdltypes { get; set; } = new List<rdltype>();
}
