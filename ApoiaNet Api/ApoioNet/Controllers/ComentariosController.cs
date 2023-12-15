using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ComentariosController : ControllerBase
{
    private static List<Comentario> _comentarios = new List<Comentario>();

    [HttpPost("cadastrar")]
    public ActionResult CadastrarComentario(Comentario comentario)
    {
        
        if (string.IsNullOrEmpty(comentario.Email) || comentario.SiteId <= 0)
        {
            return BadRequest("E-mail e ID do site são obrigatórios");
        }

        _comentarios.Add(comentario);

        return CreatedAtAction(nameof(ObterTodosComentarios), comentario);
    }

    [HttpGet("obterTodos")]
    public ActionResult<IEnumerable<Comentario>> ObterTodosComentarios()
    {
        if (_comentarios.Count == 0)
        {
            return NotFound("Nenhum comentário encontrado");
        }

        return _comentarios;
    }

    [HttpGet("obterPorEmail/{email}")]
    public ActionResult<IEnumerable<Comentario>> ObterComentariosPorEmail(string email)
    {
        var comentarios = _comentarios.Where(c => c.Email == email).ToList();
        if (comentarios.Count == 0)
        {
            return NotFound($"Nenhum comentário encontrado para o e-mail {email}");
        }

        return comentarios;
    }
}
