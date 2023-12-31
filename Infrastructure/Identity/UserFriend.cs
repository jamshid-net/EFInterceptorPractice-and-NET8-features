using Domain.Models;

namespace Infrastructure.Identity;
public class UserFriend : BaseEntity
{
    public Guid Id { get; set; }

    public List<Guid> FriendIds { get; set; } = new();

}
