namespace CshBackendDev.Models;

using System.ComponentModel.DataAnnotations;

public class User
{
  public int Id { get; set; }

  [Required]
  [StringLength(100)]
  public string FirstName { get; set; } = string.Empty;

  [Required]
  [StringLength(100)]
  public string LastName { get; set; } = string.Empty;

  [Required]
  [EmailAddress]
  public string Email { get; set; } = string.Empty;

  [Required]
  [StringLength(100)]
  public string Department { get; set; } = string.Empty;
}
