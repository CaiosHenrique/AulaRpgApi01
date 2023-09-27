using System.Collections.Generic;
using RpgApi.models;

namespace RpgApi
{
    public class Habilidades
    {
        public List<PersonagemHabilidade> PersonagemHabilidades {get; set;}
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Dano { get; set; }
    }
}