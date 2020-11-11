using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Notifications
{
    public class PessoaExcluidaNotification : INotification
    {
        public String Id { get; set; }
        public bool IsEfetivado { get; set; }
    }
}
