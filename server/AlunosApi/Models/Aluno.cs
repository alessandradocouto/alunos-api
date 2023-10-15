using System.ComponentModel.DataAnnotations;

namespace AlunosApi.Models;

public class Aluno
{
    public int Id { get; set; }

    [Required]
    [StringLength(80)]
    public string Name { get; set; }

    [Required]
    [StringLength(150)]
    public string Email { get; set; }

    public int Age { get; set; }

    public DateTime CreatedAt { get; set; }
}
