using ApoioNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class WebsitesController : ControllerBase
{
    private static List<Website> _websites = new List<Website>();
    private static int _idCounter = 1; 
    private readonly Contexto _context;

    public WebsitesController(Contexto context)
    {
        _context = context;
    }

    [HttpPost("cadastrar")]
    public async Task<ActionResult> CadastrarWebsite(Website website)
    {
     
        if (string.IsNullOrEmpty(website.Nome) || string.IsNullOrEmpty(website.Tipo) || string.IsNullOrEmpty(website.URL))
        {
            return BadRequest("Nome, Tipo e URL do site são obrigatórios");
        }

        try
        {
            _context.Website.Add(website);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterTodosWebsites), website);
        }
        catch (Exception ex) {
            throw new Exception(ex.Message);
                }


    }

    [HttpGet("obterTodos")]
    public async Task<ActionResult<IEnumerable<Website>>> ObterTodosWebsites()
    {
        var websites = await _context.Website.ToListAsync();

        if (websites.Count == 0)
        {
            return NotFound("Nenhum website encontrado");
        }

        return websites;
    }

    [HttpGet("obterPorTipo/{tipo}")]
    public ActionResult<IEnumerable<Website>> ObterWebsitesPorTipo(string tipo)
    {
        var websitesPorTipo = _websites.Where(w => w.Tipo == tipo).ToList();
        if (websitesPorTipo.Count == 0)
        {
            return NotFound($"Nenhum website encontrado para o tipo {tipo}");
        }

        return websitesPorTipo;
    }
}
