using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AlunosApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AlunoController : ControllerBase
{
    public IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
    {
        try
        {
            var alunos = await _alunoService.GetAlunos();
            if (alunos.Count() == 0)
            {
                return NotFound($"List Not Found...");
            }
            return Ok(alunos);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "There was a problem handling your request.");
        }
    }


    [HttpGet("Name")]
    public async Task<ActionResult<IEnumerable<Aluno>>> GetAlunosByName(string name)
    {
        try
        {
            var alunos = await _alunoService.GetAlunosByName(name);
            if (string.IsNullOrWhiteSpace(name) || alunos.Count() == 0)
            {
                return NotFound($"{name} Not Found...");
            }
            return Ok(alunos);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "There was a problem handling your request.");
        }
    }


    [HttpGet("{id:int}", Name = "GetAluno")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
        try
        {
            var aluno = await _alunoService.GetAluno(id);
            if (aluno is null)
            {
                return NotFound($"Aluno {id} Not Found...");
            }

            return Ok($"Aluno {id} was returned with success.");
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "There was a problem handling your request.");
        }
    }


    [HttpPost]
    public async Task<ActionResult> CreateAluno(Aluno aluno)
    {
        try
        {
            if (aluno is null)
            {
                return BadRequest("Failed when add Aluno.");
            }
            await _alunoService.CreateAluno(aluno);
            return new CreatedAtRouteResult(nameof(GetAluno), new {id = aluno.Id}, aluno);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "There was a problem handling your request.");
        }
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateAluno(int id, Aluno aluno)
    {
        try
        {
            if (aluno is null || id != aluno.Id)
            {
                return BadRequest($"Failed when update Aluno {id}.");
            }
            await _alunoService.UpdateAluno(aluno);
            return Ok($"Aluno {id} was updated with success.");
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "There was a problem handling your request.");
        }
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteAluno(int id)
    {
        try
        {
            var aluno = await _alunoService.GetAluno(id);
            if (id != aluno.Id || aluno is null)
            {
                return BadRequest($"Failed when delete Aluno {id}.");
            }
            await _alunoService.DeleteAluno(aluno);
            return Ok($"Aluno {id} was deleted with success.");
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "There was a problem handling your request.");
        }
    }
}