using RpgApi.models;

namespace RpgApi
{
    public class PersonagemHabilidade
    {
        public int PersonagemId { get; set; }
        public Personagem Personagem { get; set; }
        public int HabilidadeId { get; set; }
        public Habilidades HabilidadeId { get; set; }
    }
}