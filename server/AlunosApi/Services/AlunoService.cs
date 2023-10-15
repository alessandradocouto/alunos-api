using AlunosApi.Context;
using AlunosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Services;

public class AlunoService : IAlunoService
{
    private readonly AppDbContext _context;


    public AlunoService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
        try
        {
            var alunos = await _context.Aluno.ToListAsync();
            return alunos;
        }
        catch
        {
            throw;
        }
    }


    public async Task<IEnumerable<Aluno>> GetAlunosByName(string name)
    {
        IEnumerable<Aluno> alunos;
        try
        {
            if(!string.IsNullOrWhiteSpace(name))
            {
                alunos = await _context.Aluno.Where(n => n.Name.Contains(name)).ToListAsync();
            }
            else
            {
                alunos = await GetAlunos();
            }
        }
        catch
        {  
            throw;
        }
        return alunos;
    }


    public async Task<Aluno> GetAluno(int id)
    {
        try
        {
            var aluno = await _context.Aluno.FindAsync(id);
            return aluno;
        }
        catch
        {
            throw;
        }
    }


    public async Task CreateAluno(Aluno aluno)
    {
        try
        {
            _context.Aluno.AddAsync(aluno);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }


    public async Task UpdateAluno(Aluno aluno)
    {
        try
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }


    public async Task DeleteAluno(Aluno aluno)
    {
        try
        {
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
        catch
        {
            throw;
        }
    }
}