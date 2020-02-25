using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApkgEditor.Structure
{
    public partial class Anki2Context : DbContext
    {
        public Anki2Context()
        {
        }

        public Anki2Context(DbContextOptions<Anki2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Col> Col { get; set; }
        public virtual DbSet<Grave> Graves { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Revlog> Revlog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=collection.anki2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("cards");

                entity.HasIndex(e => e.Nid)
                    .HasName("ix_cards_nid");

                entity.HasIndex(e => e.Usn)
                    .HasName("ix_cards_usn");

                entity.HasIndex(e => new { e.Did, e.Queue, e.Due })
                    .HasName("ix_cards_sched");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.Did).HasColumnName("did");

                entity.Property(e => e.Due).HasColumnName("due");

                entity.Property(e => e.Factor).HasColumnName("factor");

                entity.Property(e => e.Flags).HasColumnName("flags");

                entity.Property(e => e.Ivl).HasColumnName("ivl");

                entity.Property(e => e.Lapses).HasColumnName("lapses");

                entity.Property(e => e.Left).HasColumnName("left");

                entity.Property(e => e.Mod).HasColumnName("mod");

                entity.Property(e => e.Nid).HasColumnName("nid");

                entity.Property(e => e.Odid).HasColumnName("odid");

                entity.Property(e => e.Odue).HasColumnName("odue");

                entity.Property(e => e.Ord).HasColumnName("ord");

                entity.Property(e => e.Queue).HasColumnName("queue");

                entity.Property(e => e.Reps).HasColumnName("reps");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Usn).HasColumnName("usn");
            });
            modelBuilder.Entity<Col>(entity =>
            {
                entity.UsePropertyAccessMode(PropertyAccessMode.PreferProperty);
                entity.Ignore(col => col.Decks);
                entity.Ignore(col => col.Model);

                entity.ToTable("col");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Conf)
                    .IsRequired()
                    .HasColumnName("conf");

                entity.Property(e => e.Crt).HasColumnName("crt");

                entity.Property(e => e.Dconf)
                    .IsRequired()
                    .HasColumnName("dconf");

                entity.Property(e => e.JDecks)
                    .IsRequired()
                    .HasColumnName("decks");

                entity.Property(e => e.Dty).HasColumnName("dty");

                entity.Property(e => e.Ls).HasColumnName("ls");

                entity.Property(e => e.Mod).HasColumnName("mod");

                entity.Property(e => e.JModels)
                    .IsRequired()
                    .HasColumnName("models");

                entity.Property(e => e.Scm).HasColumnName("scm");

                entity.Property(e => e.Tags)
                    .IsRequired()
                    .HasColumnName("tags");

                entity.Property(e => e.Usn).HasColumnName("usn");

                entity.Property(e => e.Ver).HasColumnName("ver");
            });

            modelBuilder.Entity<Grave>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("graves");

                entity.Property(e => e.Oid).HasColumnName("oid");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Usn).HasColumnName("usn");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("notes");

                entity.HasIndex(e => e.Csum)
                    .HasName("ix_notes_csum");

                entity.HasIndex(e => e.Usn)
                    .HasName("ix_notes_usn");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Csum).HasColumnName("csum");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data");

                entity.Property(e => e.Flags).HasColumnName("flags");

                entity.Property(e => e.Flds)
                    .IsRequired()
                    .HasColumnName("flds");

                entity.Property(e => e.Guid)
                    .IsRequired()
                    .HasColumnName("guid");

                entity.Property(e => e.Mid).HasColumnName("mid");

                entity.Property(e => e.Mod).HasColumnName("mod");

                entity.Property(e => e.Sfld).HasColumnName("sfld");

                entity.Property(e => e.Tags)
                    .IsRequired()
                    .HasColumnName("tags");

                entity.Property(e => e.Usn).HasColumnName("usn");
            });

            modelBuilder.Entity<Revlog>(entity =>
            {
                entity.ToTable("revlog");

                entity.HasIndex(e => e.Cid)
                    .HasName("ix_revlog_cid");

                entity.HasIndex(e => e.Usn)
                    .HasName("ix_revlog_usn");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cid).HasColumnName("cid");

                entity.Property(e => e.Ease).HasColumnName("ease");

                entity.Property(e => e.Factor).HasColumnName("factor");

                entity.Property(e => e.Ivl).HasColumnName("ivl");

                entity.Property(e => e.LastIvl).HasColumnName("lastIvl");

                entity.Property(e => e.Time).HasColumnName("time");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Usn).HasColumnName("usn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

