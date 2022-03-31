using System;
using System.Collections.Generic;

#nullable disable

namespace senai_gp3_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            AvaliacaousuarioIdUsuarioAvaliadoNavigations = new HashSet<Avaliacaousuario>();
            AvaliacaousuarioIdUsuarioAvaliadorNavigations = new HashSet<Avaliacaousuario>();
            Decisaos = new HashSet<Decisao>();
            Feedbacks = new HashSet<Feedback>();
            Minhasatividades = new HashSet<Minhasatividade>();
        }

        public int IdUsuario { get; set; }
        public byte IdCargo { get; set; }
        public int IdUnidadeSenai { get; set; }
        public byte IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public short Vantagens { get; set; }
        public decimal NivelSatisfacao { get; set; }
        public string Cpf { get; set; }
        public int SaldoMoeda { get; set; }
        public int Trofeus { get; set; }
        public string LocalizacaoUsuario { get; set; }
        public string CaminhoFotoPerfil { get; set; }
        public decimal Salario { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
        public virtual Unidadesenai IdUnidadeSenaiNavigation { get; set; }
        public virtual ICollection<Avaliacaousuario> AvaliacaousuarioIdUsuarioAvaliadoNavigations { get; set; }
        public virtual ICollection<Avaliacaousuario> AvaliacaousuarioIdUsuarioAvaliadorNavigations { get; set; }
        public virtual ICollection<Decisao> Decisaos { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
    }
}
