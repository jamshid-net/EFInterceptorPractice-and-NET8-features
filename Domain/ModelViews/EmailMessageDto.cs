using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelViews;
public record EmailMessageDto(string email, string subject, string message);

