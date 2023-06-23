using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TAF_TMS_C1onl.Models;

[Table("customers")]
public record Customers
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    
    [Column("firstname")]
    public string? FirstName { get; set; }
    
    [Column("lastname")]
    public string? LastName { get; set; }
    
    [Column("email")]
    public string? Email { get; set; }
    
    [Column("age")]
    public int Age { get; set; }
};
