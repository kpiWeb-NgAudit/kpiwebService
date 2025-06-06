using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KpiWebService.Models;

public partial class dimcolumn
{
    public int dimcol_id_pk { get; set; }

    public string dimcol_cname { get; set; } = null!;

    public string dimcol_use { get; set; } = null!;

    public string? dimcol_purgewhenvirt { get; set; }

    public string dimcol_type { get; set; } = null!;

    public string dimcol_shortcubename { get; set; } = null!;

    public string dimcol_shortpresname { get; set; } = null!;

    public int dimcol_workorder { get; set; }

    public string dimcol_cubetype { get; set; } = null!;

    public string dimcol_cubeproc { get; set; } = null!;
    public int? dimcol_cubesort { get; set; }

    public string? dimcol_cubeformula { get; set; }

    public string dimcol_cubevisible { get; set; } = null!;

    public string dimcol_rdlshowfilter { get; set; } = null!;

    public string dimcol_constrainttype { get; set; } = null!;

    public string dimcol_drillthrough { get; set; } = null!;

    public int? dimcol_attributerelation { get; set; }

    public int? dimcol_propertyname { get; set; }

    public int? dimcol_propertyvalue { get; set; }

    public string? dimcol_displayfolder { get; set; }

    public string? dimcol_defaultmember { get; set; }

    public string dimcol_indexdatamart { get; set; } = null!;

    public string? dimcol_comments { get; set; }

    public int dim_id_pk { get; set; }

    public byte[] dimcol_timestamp { get; set; } = null!;

    public virtual ICollection<dimcolumn> Inversedimcol_attributerelationNavigation { get; set; } = new List<dimcolumn>();

    public virtual ICollection<dimcolumn> Inversedimcol_cubesortNavigation { get; set; } = new List<dimcolumn>();

    public virtual ICollection<dimcolumn> Inversedimcol_propertynameNavigation { get; set; } = new List<dimcolumn>();

    public virtual ICollection<dimcolumn> Inversedimcol_propertyvalueNavigation { get; set; } = new List<dimcolumn>();

    public virtual dimension dim_id_pkNavigation { get; set; } = null!;

    public virtual dimcolumn? dimcol_attributerelationNavigation { get; set; }

    public virtual dimcolumn? dimcol_cubesortNavigation { get; set; }

    public virtual dimcolumn? dimcol_propertynameNavigation { get; set; }

    public virtual dimcolumn? dimcol_propertyvalueNavigation { get; set; }

    public virtual ICollection<factcolumn> factcolumns { get; set; } = new List<factcolumn>();

    public virtual ICollection<hier_dimcol> hier_dimcols { get; set; } = new List<hier_dimcol>();

    public virtual ICollection<role_dimcol> role_dimcols { get; set; } = new List<role_dimcol>();
}
