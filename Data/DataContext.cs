using Microsoft.EntityFrameworkCore;
using RpgApi.models;
using RpgApi.models.Enuns;
using RpgApi.Utils;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Personagem> TB_PERSONAGENS { get; set; }
        public DbSet<Armas> TB_ARMAS { get; set; }
        public DbSet<Usuarios> TB_USERS {get; set;}
        public DbSet<Habilidades> TB_SKILLS {get; set;}
        public DbSet<PersonagemHabilidade> TB_PERSONAGEM_HABILIDADE {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personagem>().HasData
            (
                    new Personagem() { Id = 1, Nome = "Frodo", PontosVida = 100, Forca = 17, Defesa = 23, Inteligencia = 33, Classe = ClasseEnum.Cavaleiro },
                    new Personagem() { Id = 2, Nome = "Sam", PontosVida = 100, Forca = 15, Defesa = 25, Inteligencia = 30, Classe = ClasseEnum.Cavaleiro },
                    new Personagem() { Id = 3, Nome = "Galadriel", PontosVida = 100, Forca = 18, Defesa = 21, Inteligencia = 35, Classe = ClasseEnum.Clerigo },
                    new Personagem() { Id = 4, Nome = "Gandalf", PontosVida = 100, Forca = 18, Defesa = 18, Inteligencia = 37, Classe = ClasseEnum.Mago },
                    new Personagem() { Id = 5, Nome = "Hobbit", PontosVida = 100, Forca = 20, Defesa = 17, Inteligencia = 31, Classe = ClasseEnum.Cavaleiro },
                    new Personagem() { Id = 6, Nome = "Celeborn", PontosVida = 100, Forca = 21, Defesa = 13, Inteligencia = 34, Classe = ClasseEnum.Clerigo },
                    new Personagem() { Id = 7, Nome = "Radagast", PontosVida = 100, Forca = 25, Defesa = 11, Inteligencia = 35, Classe = ClasseEnum.Mago }

            );
            modelBuilder.Entity<Armas>().HasData
            (
                    new Armas() { Id = 1, Nome = "Excalibur", Dano = 99, PersonagemId = 1},
                    new Armas() { Id = 2, Nome = "Destrói Mundos", Dano = 90, PersonagemId = 2},
                    new Armas() { Id = 3, Nome = "Faca Infernal", Dano = 11, PersonagemId = 3},
                    new Armas() { Id = 4, Nome = "Machado Arcano", Dano = 35, PersonagemId = 4},
                    new Armas() { Id = 5, Nome = ".Furadeira", Dano = 100, PersonagemId = 5},
                    new Armas() { Id = 6, Nome = "Night Blade", Dano = 44, PersonagemId = 6},
                    new Armas() { Id = 7, Nome = "Veneno Corrupto", Dano = 10, PersonagemId = 7}

            );
            modelBuilder.Entity<PersonagemHabilidade>()
            .HasKey(ph => new {ph.PersonagemId, ph.HabilidadeId});
            modelBuilder.Entity<Habilidades>().HasData
            (
                new Habilidades(){Id=1, Nome="Purificar", Dano=0},
                new Habilidades(){Id=2, Nome="Flash", Dano=0},
                new Habilidades(){Id=3, Nome="Incendiar", Dano=0}
            );
            modelBuilder.Entity<Habilidades>().HasData
            (
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 1},
                new PersonagemHabilidade() {PersonagemId = 1, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 2, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 3, HabilidadeId = 3},
                new PersonagemHabilidade() {PersonagemId = 4, HabilidadeId = 3},
                new PersonagemHabilidade() {PersonagemId = 5, HabilidadeId = 1},
                new PersonagemHabilidade() {PersonagemId = 6, HabilidadeId = 2},
                new PersonagemHabilidade() {PersonagemId = 7, HabilidadeId = 3}

            );
              //Início da criação do usuário padrão.
            Usuarios user = new Usuarios();
            Criptografia.CriarPasswordHash("123456", out byte[] hash, out byte[]salt);
            user.Id = 1;
            user.Username = "UsuarioAdmin";
            user.PasswordString = string.Empty;
            user.PasswordHash = hash;
            user.PasswordSalt = salt;
            user.Perfil = "Admin";
            user.Email = "seuEmail@gmail.com";
            user.Latitude = -23.5200241;
            user.Longitude = -46.596498;

            modelBuilder.Entity<Usuarios>().HasData(user);            
            //Fim da criação do usuário padrão.
             modelBuilder.Entity<Usuarios>().Property(u => u.Perfil).HasDefaultValue("Jogador");
        }
    }


}