using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KpiWebService.Models;
using KpiWebService.Models.Enums;

namespace KpiWebService.Models;

public partial class customer
{
    [Key] // Indique que c'est la clé primaire
    [Column("cube_id_pk")]
    [StringLength(15)] // Longueur DB
    public string cube_id_pk { get; set; } = null!;

    [Column("cube_number")]
    public int cube_number { get; set; }

    // [Required]
    // [Column("cube_name")]
    // [StringLength(50)]
    // public string cube_name { get; set; } = null!;
    //
    [Required]
    [Column("cust_geocode")]
    [StringLength(7)]
    public string cust_geocode { get; set; } = null!;
    //
    [Required]
    [Column("cust_town")]
    [StringLength(30)]
    public string cust_town { get; set; } = null!;
    //
    [Required]
    [Column("cust_country")]
    [StringLength(30)] 
    public string cust_country { get; set; } = null!;
    //
    // [Required] // Équivalent de NOT NULL pour la validation
    // [Column("cust_cubetype")]
    // [StringLength(9)] // Correspond à la longueur max de la DB
    // public CustCubetype cust_cubetype { get; set; }
    //
    // [Column("cust_ostype")]
    // [StringLength(8)]
    // public string? cust_ostype { get; set; }
    //
    // [Column("cust_dbtype")]
    // [StringLength(8)]
    // public string? cust_dbtype { get; set; }
    //
    [Required]
    [Column("cust_erptype")]
    [StringLength(12)]
    public string cust_erptype { get; set; } = null!;
    //
    [Required]
    [Column("cust_connect_str")]
    [StringLength(100)]
    public string cust_connect_str { get; set; } = null!;
    //
    // [Column("cube_lastupdate")]
    // public DateTime cube_lastupdate { get; set; }
    //
    // [Column("cube_lastprocess")]
    // public DateTime cube_lastprocess { get; set; }
    //
    [Required]
    [Column("cube_ftpuser")]
    [StringLength(12)]
    public string cube_ftpuser { get; set; } = null!;
    //
    [Required]
    [Column("cube_ftppasswd")]
    [StringLength(12)]
    public string cube_ftppasswd { get; set; } = null!;
    //
    // [Required]
    // [Column("cust_refreshfrq")]
    // public CustRefreshFrq  cust_refreshfrq { get; set; }
    //
    //
    // [Required]
    // [Column("cust_refreshfrqmonth")]
    // [StringLength(10)] // Doit accommoder RM2805
    // public CustRefreshFrqMonth cust_refreshfrqmonth { get; set; }
    //
    // [Column("cust_charseparator")]
    // [StringLength(255)]
    // public string? cust_charseparator { get; set; }
    //
     [Column("cust_limitrdlfilter")]
     public int cust_limitrdlfilter { get; set; }
    //
    [Required]
    [Column("cust_rdlinterwidlen")]
    [StringLength(7)]
    public string cust_rdlinterwidlen { get; set; } = null!;
    //
    [Required]
    [Column("cube_identity")]
    [StringLength(35)]
    public string cube_identity { get; set; } = null!;
    //
    // [Required]
    // [Column("cust_language")]
    // public CustLanguage  cust_language { get; set; }
    //
     [Column("cube_nbproddatasources")]
     public int cube_nbproddatasources { get; set; }
    //
    // [Column("cube_proddatasource_prefix")]
    // [StringLength(3)]
    // public string? cube_proddatasource_prefix { get; set; }
    //
     [Column("cust_beginmonthfiscal")]
     public int cust_beginmonthfiscal { get; set; }
    //
    [Required]
    [Column("cust_rdlcurrencyformat")]
    [StringLength(5)]
    public string cust_rdlcurrencyformat { get; set; } = null!;
    //
    // [Required]
    // [Column("cube_dailytasktrigger")]
    // public CubeDailyTaskTrigger  cube_dailytasktrigger { get; set; }
    //
    // [Required]
    // [Column("cube_localcubgenerate")]
    // public CubeLocalCubGenerate  cube_localcubgenerate { get; set; }
    //
    // [Column("cube_optimratio")]
    // [StringLength(255)] 
    // public string? cube_optimratio { get; set; }
    //
     [Column("cube_nbdimtimevcol")]
     public int cube_nbdimtimevcol { get; set; }
    //
     [Column("cube_nbdimgeovcol")]
     public int cube_nbdimgeovcol { get; set; }
    //
    // [Column("cust_internalnotes", TypeName = "text")]
    // public string? cust_internalnotes { get; set; }
    //
    // [Column("cust_externalnotes", TypeName = "text")]
    // public string? cust_externalnotes { get; set; }
    //
    // [Column("cust_contact1")]
    // [StringLength(100)]
    // public string? cust_contact1 { get; set; }
    //
    // [Column("cust_contact2")]
    // [StringLength(100)]
    // public string? cust_contact2 { get; set; }
    //
    // [Column("cust_contact3")]
    // [StringLength(100)]
    // public string? cust_contact3 { get; set; }
    //
    [Required]
    [Column("cust_showfiscmeasureandset")]
    [StringLength(5)]
    public string cust_showfiscmeasureandset { get; set; } = null!;
    //
    [Required]
    [Column("cust_showpctdifferencebase100")]
    [StringLength(5)]
    public string cust_showpctdifferencebase100 { get; set; } = null!;
    //
    [Required]
    [Column("cube_dimtimepkmanager")]
    [StringLength(6)]
    public string cube_dimtimepkmanager { get; set; } = null!;
    //
    // [Required]
    // [Column("cube_globalperspective")]
    // public CubeGlobalPerspective  cube_globalperspective { get; set; }
    //
    // [Column("cube_scope_mdxinstruction", TypeName = "ntext")]
    // public string? cube_scope_mdxinstruction { get; set; }
    //
     [Column("cube_drillthroughnbrows")]
     public int cube_drillthroughnbrows { get; set; }
    //
    // [Column("cube_factcoldefaultmeasure")]
    // [StringLength(255)]
    // public string? cube_factcoldefaultmeasure { get; set; }
    //
    // [Required]
    // [Column("cube_distinctcountpartition")]
    // public CubeDistinctCountPartition  cube_distinctcountpartition { get; set; }
    //
    // [Required]
    // [Column("cube_typenormalreplica")]
    // public CubeTypeNormalReplica  cube_typenormalreplica { get; set; }
    //
    // [Column("cube_paramwhenreplica")]
    // [StringLength(15)]
    // public string? cube_paramwhenreplica { get; set; }
    //
    // [Column("cube_comments", TypeName = "text")]
    // public string? cube_comments { get; set; }
    //
    // [Required]
    // [Column("cust_timestamp", TypeName = "timestamp")] // EF Core comprend 'timestamp' comme rowversion pour SQL Server
    // [Timestamp] // DataAnnotation pour rowversion
    // public byte[] cust_timestamp { get; set; } = null!;
    //
    // public virtual ICollection<cube_user> cube_users { get; set; } = new List<cube_user>();
    //
    // public virtual ICollection<cubeset> cubesets { get; set; } = new List<cubeset>();
    //
    // public virtual ICollection<dimdbextractsV2> dimdbextractsV2s { get; set; } = new List<dimdbextractsV2>();
    //
    // public virtual ICollection<dimension> dimensions { get; set; } = new List<dimension>();
    //
    // public virtual ICollection<exploitInstruction> exploitInstructions { get; set; } = new List<exploitInstruction>();
    //
    // public virtual ICollection<factdbextractsV2> factdbextractsV2s { get; set; } = new List<factdbextractsV2>();
    //
    // public virtual ICollection<fact> facts { get; set; } = new List<fact>();
    //
    // public virtual ICollection<perspective> perspectives { get; set; } = new List<perspective>();
    //
    // public virtual ICollection<rdllist> rdllists { get; set; } = new List<rdllist>();
    //
    // public virtual ICollection<role> roles { get; set; } = new List<role>();
    //
    // public virtual ICollection<source> sources { get; set; } = new List<source>();
    
}
