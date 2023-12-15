
using ApoioNet.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private static List<User> _Users = new List<User>();
    private readonly Contexto _context;

    public UserController(Contexto context)
    {
        _context = context;
    }

    [HttpPost("cadastrar")]
    public ActionResult CadastrarUser(User User)
    {
        _context.User.Add(User);

        return CreatedAtAction(nameof(ObterUserPorCPF), new { cpf = User.CPF }, User);
    }

    [HttpGet("obterPorCPF/{cpf}")]
    public ActionResult<User> ObterUserPorCPF(string cpf)
    {
        var User = _context.User.FirstOrDefault(c => c.CPF == cpf);
        if (User == null)
        {
            return NotFound("User não encontrado");
        }

        return User;
    }

    [HttpGet("obterPorCpfESenha/{cpf}/{senha}")]
    public ActionResult<User> ObterUserPorCPFeSenha(string cpf, string senha)
    {
        var User = _context.User.FirstOrDefault(c => c.CPF == cpf && c.Senha == senha);
        if (User == null)
        {
            return NotFound("User não encontrado");
        }

        return User;
    }
}