using System.ComponentModel.DataAnnotations;

public class Permission
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}