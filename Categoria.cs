namespace SistemaHelpDesk
{
    public class Categoria
    {
        // Atributos
        public int IdCategoria { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Construtor
        public Categoria(int idCategoria, string nome, string descricao)
        {
            IdCategoria = idCategoria;
            Nome = nome;
            Descricao = descricao;
        }

        // Métodos
        public void AtualizarDescricao(string novaDescricao)
        {
            Descricao = novaDescricao;
        }

        public string ExibirCategoria()
        {
            return $"{Nome} - {Descricao}";
        }
    }
}
