using Microsoft.AspNetCore.Mvc;
using RpgApi.models;
using RpgApi.models.Enuns;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class PersonagensExemploController : ControllerBase 
    {
        private static List<Personagem> personagens = new List<Personagem>()
        {
            //Colar os objetos da lista do chat aqui
            new Personagem() { Id = 1, Nome = "Frodo", PontosVida=100, Forca=17, Defesa=23, Inteligencia=33, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 2, Nome = "Sam", PontosVida=100, Forca=15, Defesa=25, Inteligencia=30, Classe=ClasseEnum.Cavaleiro},
            new Personagem() { Id = 3, Nome = "Galadriel", PontosVida=100, Forca=18, Defesa=21, Inteligencia=35, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 4, Nome = "Gandalf", PontosVida=100, Forca=18, Defesa=18, Inteligencia=37, Classe=ClasseEnum.Mago },
            new Personagem() { Id = 5, Nome = "Hobbit", PontosVida=100, Forca=20, Defesa=17, Inteligencia=31, Classe=ClasseEnum.Cavaleiro },
            new Personagem() { Id = 6, Nome = "Celeborn", PontosVida=100, Forca=21, Defesa=13, Inteligencia=34, Classe=ClasseEnum.Clerigo },
            new Personagem() { Id = 7, Nome = "Radagast", PontosVida=100, Forca=25, Defesa=11, Inteligencia=35, Classe=ClasseEnum.Mago }
        };
        [HttpGet("Get")]
        public IActionResult GetFirst()
        {
            Personagem p = personagens[0];
            return Ok(p);

        }
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(personagens);

        }
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(personagens.FirstOrDefault(pe => pe.Id == id));
        }
         [HttpGet("GetOrdenado")]
         public IActionResult GetOrdem()
         {
            List<Personagem> ListaFinal = personagens.OrderBy(p => p.Forca).ToList();
            return Ok(ListaFinal);
         }
         [HttpGet("Contagem")]
         public IActionResult GetQuantidade()
         {
            return Ok("Quantidade de personagens: " + personagens.Count);
         }
         [HttpGet("GetSomaForca")]
         public IActionResult GetSomaForca()
         {
            return Ok(personagens.Sum(p => p.Forca));
         }
         [HttpGet("GetSemCavaleiro")]
         public IActionResult GetSemCavaleiro()
         {
            List<Personagem> ListaBusca = personagens.FindAll(p => p.Classe != ClasseEnum.Cavaleiro);
            return Ok(ListaBusca);
         }
         [HttpGet("GetByNomeAproximado/{nome}")]
         public IActionResult GetByNomeAproximado( string nome)
         {
            List<Personagem> ListaBusca = personagens.FindAll(p => p.Nome.Contains(nome));
            return Ok(ListaBusca);
         }
         [HttpGet("RemoverMagos")]
         public IActionResult GetRemovendoMagos()
         {
            Personagem pRemove = personagens.Find(p => p.Classe == ClasseEnum.Mago);
            personagens.Remove(pRemove);
            return Ok("Personagem Removido: " + pRemove.Nome);
         }
         [HttpGet("GetByForca/{forca}")]
         public IActionResult Get(int forca)
         {
           List<Personagem> ListaFinal = personagens.FindAll(p => p.Forca == forca );
            return Ok(ListaFinal);
         }
         [HttpPost]
         public IActionResult AddPersonagem (Personagem novoPersonagem)
         {
            if (novoPersonagem.Inteligencia == 0)
            return BadRequest("Inteligencia não pode ter o valor igual a 0 (zero)");
            personagens.Add(novoPersonagem);
            return Ok(personagens);
         }
         [HttpPut]
         public IActionResult UpdatePersonagem(Personagem p)
         {Personagem personagemAlterado = personagens.Find(pers => pers.Id == p.Id);
         personagemAlterado.Nome = p.Nome;
         personagemAlterado.PontosVida = p.PontosVida;
         personagemAlterado.Forca = p.Forca;
         personagemAlterado.Defesa = p.Defesa;
         personagemAlterado.Inteligencia = p.Inteligencia;
         personagemAlterado.Classe = p.Classe;
         return Ok(personagens);
         }
         [HttpDelete ("{id}")]
         public IActionResult Delete(int id)
         {
            personagens.RemoveAll(pers => pers.Id == id);
            return Ok(personagens);
         }

    }
}