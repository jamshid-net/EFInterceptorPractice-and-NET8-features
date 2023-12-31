namespace Domain.Models;
public abstract class BaseEntity
{
    public string CreatedBy { get; set; } 

    public DateTime CreatedDate { get; set; }   

    public string? UpdatedBy { get; set; } 

    public DateTime? UpdatedDate { get; set;}
}
