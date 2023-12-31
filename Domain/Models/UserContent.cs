using Domain.Enums;

namespace Domain.Models;
public class UserContent : BaseEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string? ContentName { get; set; }

    public ContentTypes ContentType { get; set; }   

    public string? Description { get; set; }
}
