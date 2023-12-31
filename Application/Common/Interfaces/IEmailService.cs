using Domain.ModelViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;
public interface IEmailService
{
    Task<bool> SendEmailAsync(EmailMessageDto messageDto, CancellationToken token = default);
}
