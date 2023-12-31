using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IApplicationDbContext
{
    public DbSet<UserContent> UserContents { get; set; }     

    public DbSet<UserMessage> UserMessages { get; set; }    

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default); 
}
