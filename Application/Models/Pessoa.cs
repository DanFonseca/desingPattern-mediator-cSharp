﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediatRSample.Application.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public String Nome { get; set;}
        public int Idade { get; set; }
        public char Sexo { get; set; }
    }
}
