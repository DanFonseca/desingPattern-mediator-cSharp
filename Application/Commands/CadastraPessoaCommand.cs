using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Commands
{
    public class CadastraPessoaCommand: IRequest<String>
    {
        public String Id { get; set; }
        public String Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
}
