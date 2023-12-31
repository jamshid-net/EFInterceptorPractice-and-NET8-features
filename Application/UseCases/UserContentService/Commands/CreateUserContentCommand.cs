using Application.Common.Interfaces;
using AutoMapper;
using Domain.Enums;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.UseCases.UserContentService.Commands;
public class CreateUserContentCommand 
    : IRequest<bool>
{
    
    public string? ContentName { get; set; }
    public ContentTypes ContentType { get; set; }
    public string? Description { get; set; }
    public IFormFile? File { get; set; }    

}
public class CreateUserContentCommandHandler
    (
     IApplicationDbContext _context, 
     ICurrentUser currentUser,
     IMapper _mapper,
     IConfiguration configuration
    )
    : IRequestHandler<CreateUserContentCommand, bool>
{
    public async Task<bool> Handle(CreateUserContentCommand request, CancellationToken cancellationToken)
    {
        if(request is null || string.IsNullOrEmpty(currentUser.UserId))
        {
            throw new ArgumentNullException("Request is null or user is not authorized");
        }

        var userContent = _mapper.Map<UserContent>(request);


        await _context.UserContents.AddAsync(userContent, cancellationToken);

        userContent.UserId = Guid.Parse(currentUser.UserId);

        if (request.File?.Length > 0)
        {
            string? directoryPath = configuration["ContentFilePath"];

            var fileName = $"{userContent.Id}{Path.GetExtension(request.File.FileName)}";

            var fullPath = Path.Combine(directoryPath, fileName);

            using(var stream = new FileStream(fullPath, FileMode.Create))
            {
               await request.File.CopyToAsync(stream);
            }

        }
       

        return await _context.SaveChangesAsync(cancellationToken) > 0;

    }
}