using Microsoft.AspNetCore.Mvc;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using RpgApi.models;

namespace RpgApi.Controllers
{

[ApiController]
[Route("[Controller]")]
public class ArmasController : ControllerBase
{
    private readonly DataContext _context;
    public ArmasController(DataContext context)
    {
        _context = context;
    }

[HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Armas> lista = await _context.TB_ARMAS.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Armas novaArma)
        {
            try
            {
                if (novaArma.Dano > 101)
                {
                    throw new Exception("Dano não pode ser maior que 100");
                }
                await _context.TB_ARMAS.AddAsync(novaArma);
                await _context.SaveChangesAsync();

                return Ok(novaArma.Id);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Armas novaArma)
        {
            try
            {
                if (novaArma.Dano > 100)
                {
                    throw new System.Exception("Dano não pode ser maior que 100");
                }
                _context.TB_ARMAS.Update(novaArma);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Armas pRemover = await _context.TB_ARMAS.FirstOrDefaultAsync(p => p.Id == id);
                _context.TB_ARMAS.Remove(pRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }























}





































};