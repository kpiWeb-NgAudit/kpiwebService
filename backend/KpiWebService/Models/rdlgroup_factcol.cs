using System;
using System.Collections.Generic;

namespace KpiWebService.Models;

public partial class rdlgroup_factcol
{
    public string rdlgroup_id_pk { get; set; } = null!;

    public int factcol_id_pk { get; set; }

    public string? rdlgroupfactcol_rdlsimple_calctype0 { get; set; }

    public string? rdlgroupfactcol_rdlsimple_calctype1 { get; set; }

    public string? rdlgroupfactcol_rdlsimple_calctype2 { get; set; }

    public string? rdlgroupfactcol_rdlsimple_calctype3 { get; set; }

    public string? rdlgroupfactcol_rdlsimple_calctype4 { get; set; }

    public string? rdlgroupfactcol_rdlcomplex_calctype0 { get; set; }

    public string? rdlgroupfactcol_rdlcomplex_calctype1 { get; set; }

    public string? rdlgroupfactcol_rdlcomplex_calctype2 { get; set; }

    public string? rdlgroupfactcol_rdlcomplex_calctype3 { get; set; }

    public string? rdlgroupfactcol_rdlcomplex_calctype4 { get; set; }

    public byte[] rdlgroup_factcol_timestamp { get; set; } = null!;

    public virtual factcolumn factcol_id_pkNavigation { get; set; } = null!;

    public virtual rdlgroup rdlgroup_id_pkNavigation { get; set; } = null!;
}
