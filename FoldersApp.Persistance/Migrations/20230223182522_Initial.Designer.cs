// <auto-generated />
using FoldersApp.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoldersApp.Persistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230223182522_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.DigitalImgFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EvidenceFolderId")
                        .HasColumnType("int");

                    b.Property<int>("GraphicProductFolderId")
                        .HasColumnType("int");

                    b.Property<int>("ResourceFolderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EvidenceFolderId")
                        .IsUnique();

                    b.HasIndex("GraphicProductFolderId");

                    b.HasIndex("ResourceFolderId")
                        .IsUnique();

                    b.ToTable("DigitalImgFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.EvidenceFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EvidenceFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.FinalProductFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FinalProductFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.GraphicProductFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FinalProductFolderId")
                        .HasColumnType("int");

                    b.Property<int>("ProcessFolderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinalProductFolderId")
                        .IsUnique();

                    b.HasIndex("ProcessFolderId")
                        .IsUnique();

                    b.ToTable("GraphicProductFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.PrimarySourceFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrimarySourceFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.ProcessFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProcessFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.ResourceFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimarySourceId")
                        .HasColumnType("int");

                    b.Property<int>("SecondarySourceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrimarySourceId")
                        .IsUnique();

                    b.HasIndex("SecondarySourceId")
                        .IsUnique();

                    b.ToTable("ResourceFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.SecondarySourceFolder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentFolderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SecondarySourceFolders");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.DigitalImgFolder", b =>
                {
                    b.HasOne("FoldersApp.Persistance.Domains.Models.EvidenceFolder", "EvidenceFolder")
                        .WithOne("DigitalImgFolder")
                        .HasForeignKey("FoldersApp.Persistance.Domains.Models.DigitalImgFolder", "EvidenceFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoldersApp.Persistance.Domains.Models.GraphicProductFolder", "GraphicProductFolder")
                        .WithMany()
                        .HasForeignKey("GraphicProductFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoldersApp.Persistance.Domains.Models.ResourceFolder", "ResourceFolder")
                        .WithOne("DigitalImgFolder")
                        .HasForeignKey("FoldersApp.Persistance.Domains.Models.DigitalImgFolder", "ResourceFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EvidenceFolder");

                    b.Navigation("GraphicProductFolder");

                    b.Navigation("ResourceFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.GraphicProductFolder", b =>
                {
                    b.HasOne("FoldersApp.Persistance.Domains.Models.FinalProductFolder", "FinalProductFolder")
                        .WithOne("GraficProductFolder")
                        .HasForeignKey("FoldersApp.Persistance.Domains.Models.GraphicProductFolder", "FinalProductFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoldersApp.Persistance.Domains.Models.ProcessFolder", "ProcessFolder")
                        .WithOne("GraficProductFolder")
                        .HasForeignKey("FoldersApp.Persistance.Domains.Models.GraphicProductFolder", "ProcessFolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinalProductFolder");

                    b.Navigation("ProcessFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.ResourceFolder", b =>
                {
                    b.HasOne("FoldersApp.Persistance.Domains.Models.PrimarySourceFolder", "PrimarySourceFolder")
                        .WithOne("ResourceFolder")
                        .HasForeignKey("FoldersApp.Persistance.Domains.Models.ResourceFolder", "PrimarySourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoldersApp.Persistance.Domains.Models.SecondarySourceFolder", "SecondarySourceFolder")
                        .WithOne("ResourceFolder")
                        .HasForeignKey("FoldersApp.Persistance.Domains.Models.ResourceFolder", "SecondarySourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PrimarySourceFolder");

                    b.Navigation("SecondarySourceFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.EvidenceFolder", b =>
                {
                    b.Navigation("DigitalImgFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.FinalProductFolder", b =>
                {
                    b.Navigation("GraficProductFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.PrimarySourceFolder", b =>
                {
                    b.Navigation("ResourceFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.ProcessFolder", b =>
                {
                    b.Navigation("GraficProductFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.ResourceFolder", b =>
                {
                    b.Navigation("DigitalImgFolder");
                });

            modelBuilder.Entity("FoldersApp.Persistance.Domains.Models.SecondarySourceFolder", b =>
                {
                    b.Navigation("ResourceFolder");
                });
#pragma warning restore 612, 618
        }
    }
}
