using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace KpiWebService.Models;

public partial class customer
{
    [Key] // Indique que c'est la clé primaire
    [Column("cube_id_pk")]
    [StringLength(15)] // Longueur DB
    public string cube_id_pk { get; set; } = null!;

    [Column("cube_number")]
    public int cube_number { get; set; }

    [Required]
    [Column("cube_name")]
    [StringLength(50)]
    public string cube_name { get; set; } = null!;
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
    [Required]
    [Column("cust_cubetype")]
    [StringLength(9)] // CTFIN2012 ou CTYFI3467 ont 9 caractères
    [RegularExpression("^(CTFIN2012|CTYFI3467|CTYPEFIN|CTYPECOM|CTYAMLK)$", ErrorMessage = "Valeur invalide pour cust_cubetype.")]
    public string cust_cubetype { get; set; } = null!;
    //
    [Column("cust_ostype")]
    [StringLength(8)] // OTHER a 5 caractères, la colonne est NVARCHAR(8)
    [RegularExpression("^(OTHER|UNIX|WIN)$", ErrorMessage = "Valeur invalide pour cust_ostype.")]
    public string? cust_ostype { get; set; } // Nullable
    //
    [Column("cust_dbtype")]
    [StringLength(8)] // SqlServ a 7 caractères
    [RegularExpression("^(SqlServ|Oracle|ODBC)$", ErrorMessage = "Valeur invalide pour cust_dbtype.")]
    public string? cust_dbtype { get; set; } // Nullable
    //
    [Required]
    [Column("cust_erptype")]
    [StringLength(12)] // DEMOADO, SAGE500, KPITEST, DEMOSTD, DEMOFIN sont les plus longs
    [RegularExpression("^(GERS|ADOV6|SAGE500|DEMOADO|ADO140|ADO130|KPITEST|DEMOSTD|DEMOFIN|OTHER)$", ErrorMessage = "Valeur invalide pour cust_erptype.")]
    public string cust_erptype { get; set; } = null!;
    //
    [Required]
    [Column("cust_connect_str")]
    [StringLength(100)]
    public string cust_connect_str { get; set; } = null!;
    //
    [Column("cube_lastupdate")]
    public DateTime cube_lastupdate { get; set; }
    //
    [Column("cube_lastprocess")]
    public DateTime cube_lastprocess { get; set; }
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
    [Required]
    [Column("cust_refreshfrq")]
    [StringLength(10)] // RSATMON ou RFRISAT ont 7 caractères
    [RegularExpression("^(RSAT|RSATMON|RFRISAT|RFRI|RTHU|RWED|RTUE|RMON|RALL|RNEVER)$", ErrorMessage = "Valeur invalide pour cust_refreshfrq.")]
    public string cust_refreshfrq { get; set; } = null!;
    //
    //
    [Required]
    [Column("cust_refreshfrqmonth")]
    [StringLength(10)] // RM2805 a 6 caractères
    [RegularExpression("^(RM2805|RM28|RM7|RM6|RM5|RM4|RM3|RM2|RM1|RNEVER)$", ErrorMessage = "Valeur invalide pour cust_refreshfrqmonth.")]
    public string cust_refreshfrqmonth { get; set; } = null!;
    //
    [Column("cust_charseparator")]
    [StringLength(255)]
    public string? cust_charseparator { get; set; }
    //
     [Column("cust_limitrdlfilter")]
     public int cust_limitrdlfilter { get; set; }
    //
    [Required]
    [Column("cust_rdlinterwidlen")]
    [StringLength(7)] // RIWL_NO ou RIWL_A4 ont 7 caractères
    [RegularExpression("^(RIWL_NO|RIWL_A4)$", ErrorMessage = "Valeur invalide pour cust_rdlinterwidlen.")]
    public string cust_rdlinterwidlen { get; set; } = null!;
    //
    [Required]
    [Column("cube_identity")]
    [StringLength(35)]
    public string cube_identity { get; set; } = null!;
    //
    [Required]
    [Column("cust_language")]
    [StringLength(3)]
    [RegularExpression("^(ENG|FRA)$", ErrorMessage = "Valeur invalide pour cust_language.")]
    public string cust_language { get; set; } = null!;
    //
     [Column("cube_nbproddatasources")]
     public int cube_nbproddatasources { get; set; }
    //
    [Column("cube_proddatasource_prefix")]
    [StringLength(3)]
    public string? cube_proddatasource_prefix { get; set; }
    //
     [Column("cust_beginmonthfiscal")]
     public int cust_beginmonthfiscal { get; set; }
    //
    [Required]
    [Column("cust_rdlcurrencyformat")]
    [StringLength(5)] // RCFC2 ou RCFC0 ont 5 caractères
    [RegularExpression("^(RCFC2|RCFC0)$", ErrorMessage = "Valeur invalide pour cust_rdlcurrencyformat.")]
    public string cust_rdlcurrencyformat { get; set; } = null!;
    //
    [Required]
    [Column("cube_dailytasktrigger")]
    [StringLength(6)]
    [RegularExpression("^(DTT0|DTT1|DTT2|DTT3|DTT22|DTTOND)$", ErrorMessage = "Valeur invalide pour cube_dailytasktrigger.")]
    public string cube_dailytasktrigger { get; set; } = null!;
    //
    [Required]
    [Column("cube_localcubgenerate")]
    [StringLength(5)] // LCGN/LCGY ont 4 chars, la colonne est NVARCHAR(5)
    [RegularExpression("^(LCGN|LCGY)$", ErrorMessage = "Valeur invalide pour cube_localcubgenerate.")]
    public string cube_localcubgenerate { get; set; } = null!;
    //
    [Column("cube_optimratio")]
    [StringLength(255)] 
    public string? cube_optimratio { get; set; }
    //
     [Column("cube_nbdimtimevcol")]
     public int cube_nbdimtimevcol { get; set; }
    //
     [Column("cube_nbdimgeovcol")]
     public int cube_nbdimgeovcol { get; set; }
    //
    [Column("cust_internalnotes", TypeName = "text")]
    public string? cust_internalnotes { get; set; }
    //
    [Column("cust_externalnotes", TypeName = "text")]
    public string? cust_externalnotes { get; set; }
    //
    [Column("cust_contact1")]
    [StringLength(100)]
    public string? cust_contact1 { get; set; }
    //
    [Column("cust_contact2")]
    [StringLength(100)]
    public string? cust_contact2 { get; set; }
    //
    [Column("cust_contact3")]
    [StringLength(100)]
    public string? cust_contact3 { get; set; }
    //
    [Required]
    [Column("cust_showfiscmeasureandset")]
    [StringLength(5)] // SFMSN ou SFMSY ont 5 caractères
    [RegularExpression("^(SFMSN|SFMSY)$", ErrorMessage = "Valeur invalide pour cust_showfiscmeasureandset.")]
    public string cust_showfiscmeasureandset { get; set; } = null!;
    //
    [Required]
    [Column("cust_showpctdifferencebase100")]
    [StringLength(5)] // SPDBN ou SPDBY ont 5 caractères
    [RegularExpression("^(SPDBN|SPDBY)$", ErrorMessage = "Valeur invalide pour cust_showpctdifferencebase100.")]
    public string cust_showpctdifferencebase100 { get; set; } = null!;
    //
    [Required]
    [Column("cube_dimtimepkmanager")]
    [StringLength(6)]
    [RegularExpression("^(DTPKV3|DTPKV2|DTPKV1)$", ErrorMessage = "Valeur invalide pour cube_dimtimepkmanager.")]
    public string cube_dimtimepkmanager { get; set; } = null!;
    //
    [Required]
    [Column("cube_globalperspective")]
    [StringLength(6)]
    [RegularExpression("^(GPHID|GPSHOW|GPPART)$", ErrorMessage = "Valeur invalide pour cube_globalperspective.")]
    public string cube_globalperspective { get; set; } = null!;
    //
    [Column("cube_scope_mdxinstruction", TypeName = "ntext")]
    public string? cube_scope_mdxinstruction { get; set; }
    //
     [Column("cube_drillthroughnbrows")]
     public int cube_drillthroughnbrows { get; set; }
    //
    [Column("cube_factcoldefaultmeasure")]
    [StringLength(255)]
    public string? cube_factcoldefaultmeasure { get; set; }
    //
    [Required]
    [Column("cube_distinctcountpartition")]
    [StringLength(6)] // DCPYES a 6 caractères, la colonne DB est NVARCHAR(6)
    [RegularExpression("^(DCPNO|DCPYES)$", ErrorMessage = "Valeur invalide pour cube_distinctcountpartition.")]
    public string cube_distinctcountpartition { get; set; } = null!;
    //
    [Required]
    [Column("cube_typenormalreplica")]
    [StringLength(15)] // REPLICASLAVE (12), REPLICAMASTER (13)
    [RegularExpression("^(REPLICASLAVE|REPLICAMASTER|NORMAL)$", ErrorMessage = "Valeur invalide pour cube_typenormalreplica.")]
    public string cube_typenormalreplica { get; set; } = null!;
    //
    [Column("cube_paramwhenreplica")]
    [StringLength(15)]
    public string? cube_paramwhenreplica { get; set; }
    //
    [Column("cube_comments", TypeName = "text")]
    public string? cube_comments { get; set; }
    //
    [Required]
    [Column("cust_timestamp", TypeName = "timestamp")] // EF Core comprend 'timestamp' comme rowversion pour SQL Server
    [Timestamp] // DataAnnotation pour rowversion
    public byte[] cust_timestamp { get; set; } = null!;
    //
     public virtual ICollection<cube_user> cube_users { get; set; } = new List<cube_user>();
    
     public virtual ICollection<cubeset> cubesets { get; set; } = new List<cubeset>();
    
     public virtual ICollection<dimdbextractsV2> dimdbextractsV2s { get; set; } = new List<dimdbextractsV2>();
    
     public virtual ICollection<dimension> dimensions { get; set; } = new List<dimension>();
    
     public virtual ICollection<exploitInstruction> exploitInstructions { get; set; } = new List<exploitInstruction>();
    
     public virtual ICollection<factdbextractsV2> factdbextractsV2s { get; set; } = new List<factdbextractsV2>();
    
     public virtual ICollection<fact> facts { get; set; } = new List<fact>();
    
     public virtual ICollection<perspective> perspectives { get; set; } = new List<perspective>();
    
     public virtual ICollection<rdllist> rdllists { get; set; } = new List<rdllist>();
    
     public virtual ICollection<role> roles { get; set; } = new List<role>();
    
     public virtual ICollection<source> sources { get; set; } = new List<source>();
    
}
