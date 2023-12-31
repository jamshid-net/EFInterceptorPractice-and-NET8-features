
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;
public class ApplicationUser : IdentityUser<Guid>
{
    public Guid? UserFriendId { get; set; } 

    public UserFriend? UserFriends { get; set; } 
}
