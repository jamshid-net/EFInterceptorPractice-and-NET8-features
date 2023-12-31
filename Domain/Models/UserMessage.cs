using Domain.Enums;

namespace Domain.Models;
public class UserMessage : BaseEntity
{
    public Guid Id { get; set; }    

    public string? Message { get; set; }

    public Guid FromUserId { get; set; }    

    public Guid ToUserId { get; set; }  

    public ContentTypes? ContentType { get; set; }
}
