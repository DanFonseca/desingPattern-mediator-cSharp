using MediatR;
using MediatRSample.Application.Models;
using MediatRSample.Application.Models.Interfaces;
using MediatRSample.Application.Notifications;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRSample.Application.Commands.Handler
{
    public class CadastraPessoaCommandHandler : IRequestHandler<CadastraPessoaCommand, String>

    {

        private readonly IMediator _mediator;
        private readonly IRepository<Pessoa> _repository;


        public CadastraPessoaCommandHandler(IMediator mediator, IRepository<Pessoa> repository)
        {
            this._mediator = mediator;
            this._repository = repository;
        }


        public async Task<string> Handle(CadastraPessoaCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new Pessoa { 
                Nome = request.Nome, 
                Idade = request.Idade,
                Sexo = request.Sexo 
            };

            try
            {
                await  _repository.Add(pessoa);
                await _mediator.Publish(new PessoaCriadaNotification { Id = pessoa.Id, Nome = pessoa.Nome, Idade = pessoa.Idade, Sexo = pessoa.Sexo });

                return await Task.FromResult("Pessoa cadastrada com sucesso!");
            }catch(Exception ex)
            {
                await _mediator.Publish(new PessoaExcluidaNotification { Id =  request.Id, IsEfetivado = false });
                await _mediator.Publish(new ErroNotification { Excecao = ex.Message, PilhaErro = ex.StackTrace });
                return await Task.FromResult("Ocorreu um erro no momento da exclusão");
            }
        }



    }
}
