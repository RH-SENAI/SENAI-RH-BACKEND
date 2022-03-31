using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SenaiRH_G1.Domains;

#nullable disable

namespace SenaiRH_G1.Contexts
{
    public partial class SenaiRHContext : DbContext
    {
        public SenaiRHContext()
        {
        }

        public SenaiRHContext(DbContextOptions<SenaiRHContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Avaliacaousuario> Avaliacaousuarios { get; set; }
        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Cep> Ceps { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Decisao> Decisaos { get; set; }
        public virtual DbSet<Desconto> Descontos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Localizacao> Localizacaos { get; set; }
        public virtual DbSet<Logradouro> Logradouros { get; set; }
        public virtual DbSet<Minhasatividade> Minhasatividades { get; set; }
        public virtual DbSet<Setor> Setors { get; set; }
        public virtual DbSet<Situacaoatividade> Situacaoatividades { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Unidadesenai> Unidadesenais { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("name=Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.HasKey(e => e.IdAtividade)
                    .HasName("PK__ATIVIDAD__E6E8EAE23696846B");

                entity.ToTable("ATIVIDADE");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.DataConclusao)
                    .HasColumnType("date")
                    .HasColumnName("dataConclusao");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoAtividade");

                entity.Property(e => e.NecessarioValidar).HasColumnName("necessarioValidar");

                entity.Property(e => e.NomeAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeAtividade");

                entity.Property(e => e.RecompensaMoeda).HasColumnName("recompensaMoeda");

                entity.Property(e => e.RecompensaTrofeu).HasColumnName("recompensaTrofeu");
            });

            modelBuilder.Entity<Avaliacaousuario>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacaoUsuario)
                    .HasName("PK__AVALIACA__08B8D285305AA64C");

                entity.ToTable("AVALIACAOUSUARIO");

                entity.Property(e => e.IdAvaliacaoUsuario).HasColumnName("idAvaliacaoUsuario");

                entity.Property(e => e.AvaliacaoUsuario1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("avaliacaoUsuario");

                entity.Property(e => e.IdUsuarioAvaliado).HasColumnName("idUsuarioAvaliado");

                entity.Property(e => e.IdUsuarioAvaliador).HasColumnName("idUsuarioAvaliador");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdUsuarioAvaliadoNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadoNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__17F790F9");

                entity.HasOne(d => d.IdUsuarioAvaliadorNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadorNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__18EBB532");
            });

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.HasKey(e => e.IdBairro)
                    .HasName("PK__BAIRRO__86B592A19C8F51F6");

                entity.ToTable("BAIRRO");

                entity.HasIndex(e => e.NomeBairro, "UQ__BAIRRO__72D4FAEC5968BB8B")
                    .IsUnique();

                entity.Property(e => e.IdBairro).HasColumnName("idBairro");

                entity.Property(e => e.NomeBairro)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeBairro");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK__CARGO__3D0E29B86A5D5967");

                entity.ToTable("CARGO");

                entity.Property(e => e.IdCargo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCargo");

                entity.Property(e => e.CargaHoraria).HasColumnName("cargaHoraria");

                entity.Property(e => e.IdSetor).HasColumnName("idSetor");

                entity.Property(e => e.NomeCargo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCargo");

                entity.HasOne(d => d.IdSetorNavigation)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.IdSetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CARGO__idSetor__7D439ABD");
            });

            modelBuilder.Entity<Cep>(entity =>
            {
                entity.HasKey(e => e.IdCep)
                    .HasName("PK__CEP__398F6FDA4D40D6E1");

                entity.ToTable("CEP");

                entity.HasIndex(e => e.Cep1, "UQ__CEP__D83671A51C7A5BE1")
                    .IsUnique();

                entity.Property(e => e.IdCep).HasColumnName("idCep");

                entity.Property(e => e.Cep1)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("cep")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK__CIDADE__559AD0FE24907F5E");

                entity.ToTable("CIDADE");

                entity.HasIndex(e => e.NomeCidade, "UQ__CIDADE__FF0A5458844E4F18")
                    .IsUnique();

                entity.Property(e => e.IdCidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCidade");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCidade");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSO__8551ED05FA217063");

                entity.ToTable("CURSO");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.CaminhoImagemCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemCurso");

                entity.Property(e => e.CargaHoraria).HasColumnName("cargaHoraria");

                entity.Property(e => e.DataFinalizacao)
                    .HasColumnType("date")
                    .HasColumnName("dataFinalizacao");

                entity.Property(e => e.DescricaoCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoCurso");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.MediaAvaliacaoCurso)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoCurso");

                entity.Property(e => e.ModalidadeCurso).HasColumnName("modalidadeCurso");

                entity.Property(e => e.NomeCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCurso");

                entity.Property(e => e.SiteCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("siteCurso");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSO__idEmpresa__208CD6FA");
            });

            modelBuilder.Entity<Decisao>(entity =>
            {
                entity.HasKey(e => e.IdDecisao)
                    .HasName("PK__DECISAO__181085E631919018");

                entity.ToTable("DECISAO");

                entity.Property(e => e.IdDecisao).HasColumnName("idDecisao");

                entity.Property(e => e.DataDecisao)
                    .HasColumnType("date")
                    .HasColumnName("dataDecisao");

                entity.Property(e => e.DescricaoDecisao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricaoDecisao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.PrazoDeAvaliacao)
                    .HasColumnType("date")
                    .HasColumnName("prazoDeAvaliacao");

                entity.Property(e => e.ResultadoDecisao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("resultadoDecisao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Decisaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DECISAO__idUsuar__114A936A");
            });

            modelBuilder.Entity<Desconto>(entity =>
            {
                entity.HasKey(e => e.IdDesconto)
                    .HasName("PK__DESCONTO__3D5D117AAA23E8DC");

                entity.ToTable("DESCONTO");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.CaminhoImagemDesconto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemDesconto");

                entity.Property(e => e.DescricaoDesconto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoDesconto");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.MediaAvaliacaoDesconto)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoDesconto");

                entity.Property(e => e.NomeDesconto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeDesconto");

                entity.Property(e => e.NumeroCupom)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numeroCupom");

                entity.Property(e => e.ValidadeDesconto)
                    .HasColumnType("date")
                    .HasColumnName("validadeDesconto");

                entity.Property(e => e.ValorDesconto).HasColumnName("valorDesconto");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Descontos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTO__idEmpr__236943A5");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__EMPRESA__75D2CED439D9AC74");

                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.EmailEmpresa, "UQ__EMPRESA__440803BDABB57DCE")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneEmpresa, "UQ__EMPRESA__8FB435A9D2A16CEA")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.CaminhoImagemEmpresa)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemEmpresa");

                entity.Property(e => e.EmailEmpresa)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailEmpresa");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeEmpresa");

                entity.Property(e => e.TelefoneEmpresa)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefoneEmpresa");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPRESA__idLocal__1DB06A4F");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__ESTADO__62EA894A712ED654");

                entity.ToTable("ESTADO");

                entity.HasIndex(e => e.NomeEstado, "UQ__ESTADO__20DB075BD41B4F05")
                    .IsUnique();

                entity.Property(e => e.IdEstado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEstado");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeEstado");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedBack)
                    .HasName("PK__FEEDBACK__535470E978C13E95");

                entity.ToTable("FEEDBACK");

                entity.Property(e => e.IdFeedBack).HasColumnName("idFeedBack");

                entity.Property(e => e.ComentarioFeedBack)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("comentarioFeedBack");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnType("date")
                    .HasColumnName("dataPublicacao");

                entity.Property(e => e.IdDecisao).HasColumnName("idDecisao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NotaDecisao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("notaDecisao");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdDecisaoNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdDecisao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idDeci__14270015");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idUsua__151B244E");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalizacao)
                    .HasName("PK__LOCALIZA__BEC9BF4F86CB03FF");

                entity.ToTable("LOCALIZACAO");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.IdBairro).HasColumnName("idBairro");

                entity.Property(e => e.IdCep).HasColumnName("idCep");

                entity.Property(e => e.IdCidade).HasColumnName("idCidade");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdLogradouro).HasColumnName("idLogradouro");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdBairroNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdBairro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idBai__6EF57B66");

                entity.HasOne(d => d.IdCepNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCep__6E01572D");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCid__70DDC3D8");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idEst__71D1E811");

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdLogradouro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idLog__6FE99F9F");
            });

            modelBuilder.Entity<Logradouro>(entity =>
            {
                entity.HasKey(e => e.IdLogradouro)
                    .HasName("PK__LOGRADOU__C2023C43D500A97C");

                entity.ToTable("LOGRADOURO");

                entity.HasIndex(e => e.NomeLogradouro, "UQ__LOGRADOU__9ADBBDF944412F02")
                    .IsUnique();

                entity.Property(e => e.IdLogradouro).HasColumnName("idLogradouro");

                entity.Property(e => e.NomeLogradouro)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeLogradouro");
            });

            modelBuilder.Entity<Minhasatividade>(entity =>
            {
                entity.HasKey(e => e.IdMinhasAtividades)
                    .HasName("PK__MINHASAT__4679039D883BDA58");

                entity.ToTable("MINHASATIVIDADES");

                entity.Property(e => e.IdMinhasAtividades).HasColumnName("idMinhasAtividades");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.IdSetor).HasColumnName("idSetor");

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idAti__0C85DE4D");

                entity.HasOne(d => d.IdSetorNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSet__0D7A0286");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSit__0B91BA14");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idUsu__0E6E26BF");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.HasKey(e => e.IdSetor)
                    .HasName("PK__SETOR__A37801053E31EA10");

                entity.ToTable("SETOR");

                entity.HasIndex(e => e.NomeSetor, "UQ__SETOR__DD7E5C8BC3C2F324")
                    .IsUnique();

                entity.Property(e => e.IdSetor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSetor");

                entity.Property(e => e.NomeSetor)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeSetor");
            });

            modelBuilder.Entity<Situacaoatividade>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoAtividade)
                    .HasName("PK__SITUACAO__922A85305C2B8754");

                entity.ToTable("SITUACAOATIVIDADE");

                entity.Property(e => e.IdSituacaoAtividade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.NomeSituacaoAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeSituacaoAtividade");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFFC6F3C95C");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TIPOUSUA__A017BD9F0380AC1A")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Unidadesenai>(entity =>
            {
                entity.HasKey(e => e.IdUnidadeSenai)
                    .HasName("PK__UNIDADES__EDC820B8588577DD");

                entity.ToTable("UNIDADESENAI");

                entity.HasIndex(e => e.NomeUnidadeSenai, "UQ__UNIDADES__940F41B5D68532BA")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneUnidadeSenai, "UQ__UNIDADES__B5490FA47433AC99")
                    .IsUnique();

                entity.HasIndex(e => e.EmailUnidadeSenai, "UQ__UNIDADES__C4A0ED97DE7B4AE1")
                    .IsUnique();

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.EmailUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailUnidadeSenai");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.MediaAvaliacaoUnidadeSenai)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoUnidadeSenai");

                entity.Property(e => e.MediaSatisfacaoUnidadeSenai)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaSatisfacaoUnidadeSenai");

                entity.Property(e => e.NomeUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeUnidadeSenai");

                entity.Property(e => e.TelefoneUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefoneUnidadeSenai");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Unidadesenais)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .HasConstraintName("FK__UNIDADESE__idLoc__778AC167");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A61829545D");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.CaminhoFotoPerfil, "UQ__USUARIO__863E7F426ACBE0C5")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E6164DEEAAF37")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__USUARIO__D836E71FEB894CE4")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.CaminhoFotoPerfil)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoFotoPerfil");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.LocalizacaoUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("localizacaoUsuario");

                entity.Property(e => e.NivelSatisfacao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("nivelSatisfacao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Salario)
                    .HasColumnType("money")
                    .HasColumnName("salario");

                entity.Property(e => e.SaldoMoeda).HasColumnName("saldoMoeda");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(62)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Trofeus).HasColumnName("trofeus");

                entity.Property(e => e.Vantagens).HasColumnName("vantagens");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idCargo__02FC7413");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idTipoU__04E4BC85");

                entity.HasOne(d => d.IdUnidadeSenaiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdUnidadeSenai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idUnida__03F0984C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
