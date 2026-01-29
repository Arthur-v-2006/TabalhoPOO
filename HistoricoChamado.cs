using System;

namespace SistemaHelpDesk
{
    public class HistoricoChamado
    {
        // Atributos
        public int IdHistorico { get; set; }
        public string Descricao { get; set; }
        public DateTime DataRegistro { get; set; }

        // Relacionamento
        public Chamado Chamado { get; set; }

        // Construtor
        public HistoricoChamado(string descricao, Chamado chamado)
        {
            Descricao = descricao;
            Chamado = chamado;
            DataRegistro = DateTime.Now;
        }

        // Métodos
        public void AtualizarDescricao(string novaDescricao)
        {
            Descricao = novaDescricao;
        }

        public string ObterResumo()
        {
            return $"{DataRegistro}: {Descricao}";
        }
    }
}
