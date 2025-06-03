using System;
using System.Collections.Generic;
using KpiWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace KpiWebService.Data;

public partial class KPIW_1_5Context : DbContext
{
    public KPIW_1_5Context(DbContextOptions<KPIW_1_5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<OlapQueryLog> OlapQueryLogs { get; set; }

    public virtual DbSet<calctype> calctypes { get; set; }

    public virtual DbSet<calctype_factcol> calctype_factcols { get; set; }

    public virtual DbSet<cube_user> cube_users { get; set; }

    public virtual DbSet<cubeset> cubesets { get; set; }

    public virtual DbSet<customer> customers { get; set; }

    public virtual DbSet<dimcolumn> dimcolumns { get; set; }

    public virtual DbSet<dimdbextractsV2> dimdbextractsV2s { get; set; }

    public virtual DbSet<dimension> dimensions { get; set; }

    public virtual DbSet<exploitInstruction> exploitInstructions { get; set; }

    public virtual DbSet<fact> facts { get; set; }

    public virtual DbSet<factcolumn> factcolumns { get; set; }

    public virtual DbSet<factdbextractsV2> factdbextractsV2s { get; set; }

    public virtual DbSet<hier_dimcol> hier_dimcols { get; set; }

    public virtual DbSet<hierarchy> hierarchies { get; set; }

    public virtual DbSet<persp_dimnat> persp_dimnats { get; set; }

    public virtual DbSet<persp_fact> persp_facts { get; set; }

    public virtual DbSet<persp_outcalculation> persp_outcalculations { get; set; }

    public virtual DbSet<perspective> perspectives { get; set; }

    public virtual DbSet<rdlgroup> rdlgroups { get; set; }

    public virtual DbSet<rdlgroup_factcol> rdlgroup_factcols { get; set; }

    public virtual DbSet<rdllist> rdllists { get; set; }

    public virtual DbSet<rdltype> rdltypes { get; set; }

    public virtual DbSet<role> roles { get; set; }

    public virtual DbSet<role_dimcol> role_dimcols { get; set; }

    public virtual DbSet<source> sources { get; set; }

    public virtual DbSet<source_fact> source_facts { get; set; }

    public virtual DbSet<theme> themes { get; set; }

    public virtual DbSet<user> users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OlapQueryLog>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OlapQueryLog");

            entity.Property(e => e.Dataset).HasMaxLength(4000);
            entity.Property(e => e.MSOLAP_Database).HasMaxLength(255);
            entity.Property(e => e.MSOLAP_ObjectPath).HasMaxLength(4000);
            entity.Property(e => e.MSOLAP_User).HasMaxLength(255);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<calctype>(entity =>
        {
            entity.HasKey(e => e.calctype_type).HasName("calctype_pk_calctype_type");

            entity.Property(e => e.calctype_type).HasMaxLength(25);
            entity.Property(e => e.calctype_comments).HasMaxLength(80);
            entity.Property(e => e.calctype_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<calctype_factcol>(entity =>
        {
            entity.HasKey(e => new { e.factcol_id_pk, e.calctype_type }).HasName("calctypefactcol_pk_calctype_factcol_id_pk");

            entity.ToTable("calctype_factcol");

            entity.Property(e => e.calctype_type).HasMaxLength(25);
            entity.Property(e => e.calcfactcol_comments).HasColumnType("text");
            entity.Property(e => e.calcfactcol_cubesuffix).HasMaxLength(25);
            entity.Property(e => e.calcfactcol_displayfolder).HasMaxLength(100);
            entity.Property(e => e.calcfactcol_mdxformula).HasColumnType("text");
            entity.Property(e => e.calcfactcol_pressuffix).HasMaxLength(25);
            entity.Property(e => e.calcfactcol_showtotalinrdl).HasMaxLength(10);
            entity.Property(e => e.calcfactcol_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.calcfactcol_typeforformat).HasMaxLength(10);
            entity.Property(e => e.calcfactcol_visible).HasMaxLength(7);

            entity.HasOne(d => d.calctype_typeNavigation).WithMany(p => p.calctype_factcols)
                .HasForeignKey(d => d.calctype_type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("calctypefactcol_fk_calctype_type");

            entity.HasOne(d => d.factcol_id_pkNavigation).WithMany(p => p.calctype_factcols)
                .HasForeignKey(d => d.factcol_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("calctypefactcol_fk_factcol_id_pk");
        });

        modelBuilder.Entity<cube_user>(entity =>
        {
            entity.HasKey(e => new { e.cube_id_pk, e.user_id_pk }).HasName("cubeuser_pk_cust_user");

            entity.ToTable("cube_user");

            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.user_id_pk).HasMaxLength(20);
            entity.Property(e => e.cube_user_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.cube_user_whensendstatsifadmin).HasMaxLength(20);

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.cube_users)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cubeuser_fk_cust_id_pk");

            entity.HasOne(d => d.role_id_pkNavigation).WithMany(p => p.cube_users)
                .HasForeignKey(d => d.role_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cubeuser_fk_role_id_pk");

            entity.HasOne(d => d.user_id_pkNavigation).WithMany(p => p.cube_users)
                .HasForeignKey(d => d.user_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cubeuser_fk_user_id_pk");
        });

        modelBuilder.Entity<cubeset>(entity =>
        {
            entity.HasKey(e => e.cubeset_id_pk).HasName("cubeset_pk_theme_id_pk");

            entity.HasIndex(e => new { e.cubeset_cubename, e.cube_id_pk }, "cubeset_uq_cubename").IsUnique();

            entity.HasIndex(e => new { e.cubeset_name, e.cube_id_pk }, "cubeset_uq_name").IsUnique();

            entity.HasIndex(e => new { e.cubeset_presorder, e.cube_id_pk }, "cubeset_uq_presorder").IsUnique();

            entity.Property(e => e.cubeset_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.cubeset_asinstruction).HasColumnType("ntext");
            entity.Property(e => e.cubeset_comments).HasColumnType("text");
            entity.Property(e => e.cubeset_cubename).HasMaxLength(30);
            entity.Property(e => e.cubeset_dynamic).HasMaxLength(6);
            entity.Property(e => e.cubeset_hidden).HasMaxLength(6);
            entity.Property(e => e.cubeset_name).HasMaxLength(50);
            entity.Property(e => e.cubeset_rdlshowfilter).HasMaxLength(5);
            entity.Property(e => e.cubeset_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.cubesets)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("cubeset_fk_cust_id_pk");
        });

        modelBuilder.Entity<customer>(entity =>
        {
            entity.HasKey(e => e.cube_id_pk).HasName("cust_pk_customers");

            entity.HasIndex(e => e.cube_name, "cust_uq_cust_name").IsUnique();

            entity.HasIndex(e => e.cube_number, "cust_uq_cust_number").IsUnique();

            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.cube_comments).HasColumnType("text");
            entity.Property(e => e.cube_dailytasktrigger).HasMaxLength(6);
            entity.Property(e => e.cube_dimtimepkmanager).HasMaxLength(6);
            entity.Property(e => e.cube_distinctcountpartition).HasMaxLength(6);
            entity.Property(e => e.cube_factcoldefaultmeasure)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.cube_ftppasswd).HasMaxLength(12);
            entity.Property(e => e.cube_ftpuser).HasMaxLength(12);
            entity.Property(e => e.cube_globalperspective).HasMaxLength(6);
            entity.Property(e => e.cube_identity).HasMaxLength(35);
            entity.Property(e => e.cube_lastprocess).HasColumnType("datetime");
            entity.Property(e => e.cube_lastupdate).HasColumnType("datetime");
            entity.Property(e => e.cube_localcubgenerate).HasMaxLength(5);
            entity.Property(e => e.cube_name).HasMaxLength(50);
            entity.Property(e => e.cube_optimratio)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.cube_paramwhenreplica).HasMaxLength(15);
            entity.Property(e => e.cube_proddatasource_prefix).HasMaxLength(3);
            entity.Property(e => e.cube_scope_mdxinstruction).HasColumnType("ntext");
            entity.Property(e => e.cube_typenormalreplica).HasMaxLength(15);
            entity.Property(e => e.cust_charseparator)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.cust_connect_str).HasMaxLength(100);
            entity.Property(e => e.cust_contact1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.cust_contact2)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.cust_contact3)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.cust_country).HasMaxLength(30);
            entity.Property(e => e.cust_cubetype).HasMaxLength(9);
            entity.Property(e => e.cust_dbtype).HasMaxLength(8);
            entity.Property(e => e.cust_erptype).HasMaxLength(12);
            entity.Property(e => e.cust_externalnotes).HasColumnType("text");
            entity.Property(e => e.cust_geocode).HasMaxLength(7);
            entity.Property(e => e.cust_internalnotes).HasColumnType("text");
            entity.Property(e => e.cust_language).HasMaxLength(3);
            entity.Property(e => e.cust_ostype).HasMaxLength(8);
            entity.Property(e => e.cust_rdlcurrencyformat).HasMaxLength(5);
            entity.Property(e => e.cust_rdlinterwidlen).HasMaxLength(7);
            entity.Property(e => e.cust_refreshfrq).HasMaxLength(10);
            entity.Property(e => e.cust_refreshfrqmonth).HasMaxLength(10);
            entity.Property(e => e.cust_showfiscmeasureandset).HasMaxLength(5);
            entity.Property(e => e.cust_showpctdifferencebase100).HasMaxLength(5);
            entity.Property(e => e.cust_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.cust_town).HasMaxLength(30);
        });

        modelBuilder.Entity<dimcolumn>(entity =>
        {
            entity.HasKey(e => e.dimcol_id_pk).HasName("dimcol_pk_dimcol_id_pk");

            entity.HasIndex(e => new { e.dimcol_cname, e.dim_id_pk }, "dimcol_uq_dimcol_cname").IsUnique();

            entity.HasIndex(e => new { e.dimcol_shortcubename, e.dim_id_pk }, "dimcol_uq_dimcol_shortcubename").IsUnique();

            entity.HasIndex(e => new { e.dimcol_workorder, e.dim_id_pk }, "dimcol_uq_dimcol_workorder").IsUnique();

            entity.Property(e => e.dimcol_id_pk).ValueGeneratedNever();
            entity.Property(e => e.dimcol_cname).HasMaxLength(100);
            entity.Property(e => e.dimcol_comments).HasColumnType("text");
            entity.Property(e => e.dimcol_constrainttype).HasMaxLength(10);
            entity.Property(e => e.dimcol_cubeformula).HasMaxLength(4000);
            entity.Property(e => e.dimcol_cubeproc).HasMaxLength(10);
            entity.Property(e => e.dimcol_cubetype).HasMaxLength(20);
            entity.Property(e => e.dimcol_cubevisible).HasMaxLength(10);
            entity.Property(e => e.dimcol_defaultmember).HasMaxLength(100);
            entity.Property(e => e.dimcol_displayfolder).HasMaxLength(50);
            entity.Property(e => e.dimcol_drillthrough).HasMaxLength(10);
            entity.Property(e => e.dimcol_indexdatamart).HasMaxLength(5);
            entity.Property(e => e.dimcol_purgewhenvirt).HasMaxLength(5);
            entity.Property(e => e.dimcol_rdlshowfilter).HasMaxLength(5);
            entity.Property(e => e.dimcol_shortcubename).HasMaxLength(30);
            entity.Property(e => e.dimcol_shortpresname).HasMaxLength(30);
            entity.Property(e => e.dimcol_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.dimcol_type).HasMaxLength(10);
            entity.Property(e => e.dimcol_use).HasMaxLength(4);

            entity.HasOne(d => d.dim_id_pkNavigation).WithMany(p => p.dimcolumns)
                .HasForeignKey(d => d.dim_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dimcol_fk_dim_id_pk");

            entity.HasOne(d => d.dimcol_attributerelationNavigation).WithMany(p => p.Inversedimcol_attributerelationNavigation)
                .HasForeignKey(d => d.dimcol_attributerelation)
                .HasConstraintName("dimcol_fk_dimcol_attributerelation");

            entity.HasOne(d => d.dimcol_cubesortNavigation).WithMany(p => p.Inversedimcol_cubesortNavigation)
                .HasForeignKey(d => d.dimcol_cubesort)
                .HasConstraintName("dimcol_fk_dimcol_cubesort");

            entity.HasOne(d => d.dimcol_propertynameNavigation).WithMany(p => p.Inversedimcol_propertynameNavigation)
                .HasForeignKey(d => d.dimcol_propertyname)
                .HasConstraintName("dimcol_fk_dimcol_propertyname");

            entity.HasOne(d => d.dimcol_propertyvalueNavigation).WithMany(p => p.Inversedimcol_propertyvalueNavigation)
                .HasForeignKey(d => d.dimcol_propertyvalue)
                .HasConstraintName("dimcol_fk_dimcol_propertyvalue");
        });

        modelBuilder.Entity<dimdbextractsV2>(entity =>
        {
            entity.HasKey(e => new { e.dim_id_pk, e.dimdbextrv2_proddatasourceid, e.dimdbextrv2_dateinsert }).HasName("dimdbextrv2_id_pk");

            entity.ToTable("dimdbextractsV2");

            entity.Property(e => e.dimdbextrv2_dateinsert).HasColumnType("datetime");
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.dimdbextrv2_comments).HasMaxLength(200);
            entity.Property(e => e.dimdbextrv2_dbselectsqlclause).HasColumnType("ntext");
            entity.Property(e => e.dimdbextrv2_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.dimdbextractsV2s)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dimdbextrv2_fk_cust_id_pk");
        });

        modelBuilder.Entity<dimension>(entity =>
        {
            entity.HasKey(e => e.dim_id_pk).HasName("dim_pk_dim_id_pk");

            entity.HasIndex(e => new { e.dim_shortcubename, e.cube_id_pk }, "dim_uq_dim_shortcubename").IsUnique();

            entity.HasIndex(e => new { e.dim_tname, e.cube_id_pk }, "dim_uq_dim_tname").IsUnique();

            entity.HasIndex(e => new { e.dim_workorder, e.cube_id_pk }, "dim_uq_dim_workorder").IsUnique();

            entity.Property(e => e.dim_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.dim_comments).HasColumnType("text");
            entity.Property(e => e.dim_countmeasuregroup).HasMaxLength(6);
            entity.Property(e => e.dim_cubetype).HasMaxLength(20);
            entity.Property(e => e.dim_dbfetch).HasMaxLength(5);
            entity.Property(e => e.dim_deleteorphean).HasMaxLength(6);
            entity.Property(e => e.dim_dimexistquotes).HasMaxLength(6);
            entity.Property(e => e.dim_dimversion).HasMaxLength(6);
            entity.Property(e => e.dim_lastupdate).HasColumnType("datetime");
            entity.Property(e => e.dim_proccube).HasMaxLength(6);
            entity.Property(e => e.dim_shortcubename).HasMaxLength(20);
            entity.Property(e => e.dim_shortpresname).HasMaxLength(30);
            entity.Property(e => e.dim_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.dim_tname).HasMaxLength(20);
            entity.Property(e => e.dim_visible).HasMaxLength(6);

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.dimensions)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dim_fk_cust_id_pk");
        });

        modelBuilder.Entity<exploitInstruction>(entity =>
        {
            entity.HasKey(e => e.expIns_id_pk).HasName("expIns_id_pk");

            entity.HasIndex(e => new { e.expIns_speplace, e.expIns_antepostspe, e.expIns_sortorder, e.cube_id_pk }, "expIns_uq_place_antepostspe_sort").IsUnique();

            entity.Property(e => e.expIns_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.expIns_antepostspe).HasMaxLength(8);
            entity.Property(e => e.expIns_comments).HasColumnType("text");
            entity.Property(e => e.expIns_copyto).HasMaxLength(360);
            entity.Property(e => e.expIns_objectmessage).HasMaxLength(80);
            entity.Property(e => e.expIns_sendto).HasMaxLength(120);
            entity.Property(e => e.expIns_speplace).HasMaxLength(10);
            entity.Property(e => e.expIns_sqlinstruction).HasColumnType("ntext");
            entity.Property(e => e.expIns_textmessage).HasColumnType("text");
            entity.Property(e => e.expIns_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.expIns_type).HasMaxLength(8);

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.exploitInstructions)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expIns_fk_cube_id_pk");
        });

        modelBuilder.Entity<fact>(entity =>
        {
            entity.HasKey(e => e.fact_id_pk).HasName("fact_pk_fact_id_pk");

            entity.HasIndex(e => new { e.fact_shortcubename, e.cube_id_pk }, "fact_uq_fact_shortcubename").IsUnique();

            entity.HasIndex(e => new { e.fact_tname, e.cube_id_pk }, "fact_uq_fact_tname").IsUnique();

            entity.HasIndex(e => new { e.fact_workorder, e.cube_id_pk }, "fact_uq_fact_workorder").IsUnique();

            entity.Property(e => e.fact_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.fact_comments).HasColumnType("text");
            entity.Property(e => e.fact_factdatafilename).HasMaxLength(50);
            entity.Property(e => e.fact_factdatafiletype).HasMaxLength(10);
            entity.Property(e => e.fact_lastupdate).HasColumnType("datetime");
            entity.Property(e => e.fact_partitiontype).HasMaxLength(7);
            entity.Property(e => e.fact_proccube).HasMaxLength(6);
            entity.Property(e => e.fact_shortcubename).HasMaxLength(20);
            entity.Property(e => e.fact_shortpresname).HasMaxLength(30);
            entity.Property(e => e.fact_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.fact_tname).HasMaxLength(20);
            entity.Property(e => e.fact_type).HasMaxLength(8);
            entity.Property(e => e.fact_zonespe).HasMaxLength(6);

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.facts)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fact_fk_cust_id_pk");
        });

        modelBuilder.Entity<factcolumn>(entity =>
        {
            entity.HasKey(e => e.factcol_id_pk).HasName("factcol_pk_factcol_id_pk");

            entity.HasIndex(e => new { e.factcol_cname, e.fact_id_pk }, "factcol_uq_factcol_cname").IsUnique();

            entity.HasIndex(e => new { e.factcol_shortcubename, e.fact_id_pk }, "factcol_uq_factcol_shortcubename").IsUnique();

            entity.HasIndex(e => new { e.factcol_workorder, e.fact_id_pk }, "factcol_uq_factcol_workorder").IsUnique();

            entity.Property(e => e.factcol_id_pk).ValueGeneratedNever();
            entity.Property(e => e.factcol_cname).HasMaxLength(100);
            entity.Property(e => e.factcol_comments).HasColumnType("text");
            entity.Property(e => e.factcol_cubeaggregat).HasMaxLength(6);
            entity.Property(e => e.factcol_cubeformula).HasMaxLength(4000);
            entity.Property(e => e.factcol_cubevisible).HasMaxLength(10);
            entity.Property(e => e.factcol_displayfolder).HasMaxLength(100);
            entity.Property(e => e.factcol_indexdatamart).HasMaxLength(5);
            entity.Property(e => e.factcol_shortcubename).HasMaxLength(30);
            entity.Property(e => e.factcol_shortpresname).HasMaxLength(30);
            entity.Property(e => e.factcol_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.factcol_type).HasMaxLength(10);
            entity.Property(e => e.factcol_use).HasMaxLength(3);

            entity.HasOne(d => d.dimcol_id_pkNavigation).WithMany(p => p.factcolumns)
                .HasForeignKey(d => d.dimcol_id_pk)
                .HasConstraintName("factcol_fk_dimcol_id_pk");

            entity.HasOne(d => d.fact_id_pkNavigation).WithMany(p => p.factcolumns)
                .HasForeignKey(d => d.fact_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factcol_fk_fact_id_pk");
        });

        modelBuilder.Entity<factdbextractsV2>(entity =>
        {
            entity.HasKey(e => new { e.fact_id_pk, e.factdbextrv2_proddatasourceid, e.factdbextrv2_dateinsert }).HasName("factdbextrv2_id_pk");

            entity.ToTable("factdbextractsV2");

            entity.Property(e => e.factdbextrv2_dateinsert).HasColumnType("datetime");
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.factdbextrv2_comments).HasMaxLength(200);
            entity.Property(e => e.factdbextrv2_dbselectsqlclause).HasColumnType("ntext");
            entity.Property(e => e.factdbextrv2_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.factdbextractsV2s)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factdbextrv2_fk_cust_id_pk");
        });

        modelBuilder.Entity<hier_dimcol>(entity =>
        {
            entity.HasKey(e => new { e.hier_id_pk, e.dimcol_id_pk }).HasName("hierdimcol_pk");

            entity.ToTable("hier_dimcol");

            entity.HasIndex(e => new { e.hier_id_pk, e.dimcol_id_pk, e.hierdim_level }, "hierdimcol_uq_level").IsUnique();

            entity.Property(e => e.hier_dimcol_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.hierdim_rdltypepresnamecol).HasMaxLength(10);

            entity.HasOne(d => d.dimcol_id_pkNavigation).WithMany(p => p.hier_dimcols)
                .HasForeignKey(d => d.dimcol_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hierdimcol_fk_dimcol_id_pk");

            entity.HasOne(d => d.hier_id_pkNavigation).WithMany(p => p.hier_dimcols)
                .HasForeignKey(d => d.hier_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hierdimcol_fk_hier_id_pk");
        });

        modelBuilder.Entity<hierarchy>(entity =>
        {
            entity.HasKey(e => e.hier_id_pk).HasName("hier_pk_hier_id_pk");

            entity.HasIndex(e => new { e.hier_cubename, e.dim_id_pk }, "hier_uq_hier_cubename").IsUnique();

            entity.Property(e => e.hier_id_pk).ValueGeneratedNever();
            entity.Property(e => e.hier_comments).HasColumnType("text");
            entity.Property(e => e.hier_cubename).HasMaxLength(20);
            entity.Property(e => e.hier_rdlshowfilter).HasMaxLength(5);
            entity.Property(e => e.hier_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.hier_visiblecube).HasMaxLength(5);

            entity.HasOne(d => d.dim_id_pkNavigation).WithMany(p => p.hierarchies)
                .HasForeignKey(d => d.dim_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("hier_fk_dim_id_pk");
        });

        modelBuilder.Entity<persp_dimnat>(entity =>
        {
            entity.HasKey(e => new { e.persp_id_pk, e.dim_id_pk }).HasName("perspdimnat_pk_persp_dimnat");

            entity.ToTable("persp_dimnat");

            entity.Property(e => e.persp_dimnat_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.dim_id_pkNavigation).WithMany(p => p.persp_dimnats)
                .HasForeignKey(d => d.dim_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("perspdimnat_fk_fact_id_pk");

            entity.HasOne(d => d.persp_id_pkNavigation).WithMany(p => p.persp_dimnats)
                .HasForeignKey(d => d.persp_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("perspdimnat_fk_persp_id_pk");
        });

        modelBuilder.Entity<persp_fact>(entity =>
        {
            entity.HasKey(e => new { e.persp_id_pk, e.fact_id_pk }).HasName("perspfact_pk_cube_user");

            entity.ToTable("persp_fact");

            entity.Property(e => e.persp_fact_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.fact_id_pkNavigation).WithMany(p => p.persp_facts)
                .HasForeignKey(d => d.fact_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("perspfact_fk_fact_id_pk");

            entity.HasOne(d => d.persp_id_pkNavigation).WithMany(p => p.persp_facts)
                .HasForeignKey(d => d.persp_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("perspfact_fk_persp_id_pk");
        });

        modelBuilder.Entity<persp_outcalculation>(entity =>
        {
            entity.HasKey(e => new { e.persp_id_pk, e.outcalculation }).HasName("perspc_pk_persp_outcalc");

            entity.Property(e => e.outcalculation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.persp_outcalculation_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.persp_id_pkNavigation).WithMany(p => p.persp_outcalculations)
                .HasForeignKey(d => d.persp_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("perspoutcalc_fk_persp_id_pk");
        });

        modelBuilder.Entity<perspective>(entity =>
        {
            entity.HasKey(e => e.persp_id_pk).HasName("persp_pk_id_pk");

            entity.HasIndex(e => new { e.persp_name, e.cube_id_pk }, "persp_uq_perspname").IsUnique();

            entity.Property(e => e.persp_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.persp_comments).HasColumnType("text");
            entity.Property(e => e.persp_name).HasMaxLength(50);
            entity.Property(e => e.persp_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.perspectives)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persp_fk_cube_id_pk");
        });

        modelBuilder.Entity<rdlgroup>(entity =>
        {
            entity.HasKey(e => e.rdlgroup_id_pk).HasName("rdlgroup_pk_rdlgroup_id_pk");

            entity.Property(e => e.rdlgroup_id_pk).HasMaxLength(10);
            entity.Property(e => e.rdlgroup_label).HasMaxLength(20);
            entity.Property(e => e.rdlgroup_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<rdlgroup_factcol>(entity =>
        {
            entity.HasKey(e => new { e.rdlgroup_id_pk, e.factcol_id_pk }).HasName("rdlgroupfactcol_pk_rdlgroup_factcol");

            entity.ToTable("rdlgroup_factcol");

            entity.Property(e => e.rdlgroup_id_pk).HasMaxLength(10);
            entity.Property(e => e.rdlgroup_factcol_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.rdlgroupfactcol_rdlcomplex_calctype0).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlcomplex_calctype1).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlcomplex_calctype2).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlcomplex_calctype3).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlcomplex_calctype4).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlsimple_calctype0).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlsimple_calctype1).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlsimple_calctype2).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlsimple_calctype3).HasMaxLength(20);
            entity.Property(e => e.rdlgroupfactcol_rdlsimple_calctype4).HasMaxLength(20);

            entity.HasOne(d => d.factcol_id_pkNavigation).WithMany(p => p.rdlgroup_factcols)
                .HasForeignKey(d => d.factcol_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rdlgroupfactcol_fk_factcol_id_pk");

            entity.HasOne(d => d.rdlgroup_id_pkNavigation).WithMany(p => p.rdlgroup_factcols)
                .HasForeignKey(d => d.rdlgroup_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rdlgroupfactcol_fk_rdlgroup_id_pk");
        });

        modelBuilder.Entity<rdllist>(entity =>
        {
            entity.HasKey(e => e.rdllist_id_pk).HasName("rdllist_pk_rdllist_id_pk");

            entity.HasIndex(e => new { e.rdllist_name, e.cube_id_pk }, "rdllist_uq_rdllist_name").IsUnique();

            entity.Property(e => e.rdllist_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.rdllist_code).HasColumnType("text");
            entity.Property(e => e.rdllist_description).HasMaxLength(200);
            entity.Property(e => e.rdllist_name).HasMaxLength(200);
            entity.Property(e => e.rdllist_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.rdltype_id_pk).HasMaxLength(10);
            entity.Property(e => e.theme_id_pk).HasMaxLength(5);

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.rdllists)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rdllist_fk_cust_id_pk");

            entity.HasOne(d => d.rdltype_id_pkNavigation).WithMany(p => p.rdllists)
                .HasForeignKey(d => d.rdltype_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rdllist_fk_rdltype_id_pk");

            entity.HasOne(d => d.theme_id_pkNavigation).WithMany(p => p.rdllists)
                .HasForeignKey(d => d.theme_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rdllist_fk_theme_id_pk");
        });

        modelBuilder.Entity<rdltype>(entity =>
        {
            entity.HasKey(e => e.rdltype_id_pk).HasName("rdltype_pk_rdltype_id_pk");

            entity.Property(e => e.rdltype_id_pk).HasMaxLength(10);
            entity.Property(e => e.rdlgroup_id_pk).HasMaxLength(10);
            entity.Property(e => e.rdltype_label).HasMaxLength(100);
            entity.Property(e => e.rdltype_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.rdlgroup_id_pkNavigation).WithMany(p => p.rdltypes)
                .HasForeignKey(d => d.rdlgroup_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rdltype_fk_group_id_pk");
        });

        modelBuilder.Entity<role>(entity =>
        {
            entity.HasKey(e => e.role_id_pk).HasName("roles_pk_role_id_pk");

            entity.HasIndex(e => new { e.role_name, e.cube_id_pk }, "roles_uq_role_name").IsUnique();

            entity.Property(e => e.role_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.role_comments).HasColumnType("text");
            entity.Property(e => e.role_custom_role_name).HasMaxLength(50);
            entity.Property(e => e.role_description).HasMaxLength(150);
            entity.Property(e => e.role_measures_mdxinstruction).HasColumnType("ntext");
            entity.Property(e => e.role_name).HasMaxLength(15);
            entity.Property(e => e.role_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.roles)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roles_fk_cube_id_pk");
        });

        modelBuilder.Entity<role_dimcol>(entity =>
        {
            entity.HasKey(e => new { e.role_id_pk, e.dimcol_id_pk }).HasName("roledimcol_pk_roledimcol");

            entity.ToTable("role_dimcol");

            entity.Property(e => e.roledimcol_mdxinstruction).HasColumnType("ntext");
            entity.Property(e => e.roledimcol_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.dimcol_id_pkNavigation).WithMany(p => p.role_dimcols)
                .HasForeignKey(d => d.dimcol_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roledimcol_fk_dimcol_id_pk");

            entity.HasOne(d => d.role_id_pkNavigation).WithMany(p => p.role_dimcols)
                .HasForeignKey(d => d.role_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roledimcol_fk_role_id_pk");
        });

        modelBuilder.Entity<source>(entity =>
        {
            entity.HasKey(e => e.source_id_pk).HasName("sources_pk_id_pk");

            entity.HasIndex(e => new { e.source_number, e.cube_id_pk }, "sources_uq_number").IsUnique();

            entity.Property(e => e.source_id_pk).ValueGeneratedNever();
            entity.Property(e => e.cube_id_pk).HasMaxLength(15);
            entity.Property(e => e.source_comments).HasColumnType("text");
            entity.Property(e => e.source_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.cube_id_pkNavigation).WithMany(p => p.sources)
                .HasForeignKey(d => d.cube_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sources_fk_cube_id_pk");
        });

        modelBuilder.Entity<source_fact>(entity =>
        {
            entity.HasKey(e => new { e.source_id_pk, e.fact_id_pk }).HasName("sourcefact_pk_source_fact");

            entity.ToTable("source_fact");

            entity.Property(e => e.source_fact_autodoc).HasColumnType("text");
            entity.Property(e => e.source_fact_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.fact_id_pkNavigation).WithMany(p => p.source_facts)
                .HasForeignKey(d => d.fact_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sourcefact_fk_fact_id_pk");

            entity.HasOne(d => d.source_id_pkNavigation).WithMany(p => p.source_facts)
                .HasForeignKey(d => d.source_id_pk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sourcefact_fk_source_id_pk");
        });

        modelBuilder.Entity<theme>(entity =>
        {
            entity.HasKey(e => e.theme_id_pk).HasName("theme_pk_theme_id_pk");

            entity.Property(e => e.theme_id_pk).HasMaxLength(5);
            entity.Property(e => e.theme_label).HasMaxLength(100);
            entity.Property(e => e.theme_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<user>(entity =>
        {
            entity.HasKey(e => e.user_id_pk).HasName("users_pk_user_id_pk");

            entity.Property(e => e.user_id_pk).HasMaxLength(20);
            entity.Property(e => e.user_datamartaccess).HasMaxLength(10);
            entity.Property(e => e.user_email).HasMaxLength(100);
            entity.Property(e => e.user_firstname).HasMaxLength(25);
            entity.Property(e => e.user_lastname).HasMaxLength(25);
            entity.Property(e => e.user_password).HasMaxLength(100);
            entity.Property(e => e.user_rbuilder).HasMaxLength(5);
            entity.Property(e => e.user_rptadmin).HasMaxLength(10);
            entity.Property(e => e.user_targetsite).HasMaxLength(100);
            entity.Property(e => e.user_timestamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.user_type).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
