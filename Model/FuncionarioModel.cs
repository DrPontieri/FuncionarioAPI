using FuncionarioAPI.Entity;
using FuncionarioAPI.Enum;
using Microsoft.AspNetCore.Components.Web;

namespace FuncionarioAPI.Model
{
    public class FuncionarioModel : BaseEntity
    {
        public string? Nome { get; set; } = null;
        public string? Sobrenome { get; set; } = null;
        public DepartamentoEnum Departamento { get; set; }
        public bool Ativo { get; set; }
        public TurnoEnum Turno { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();

    }
}
