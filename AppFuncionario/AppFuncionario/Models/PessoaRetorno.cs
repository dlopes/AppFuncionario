using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppFuncionario.Models
{
    public class PessoaRetorno
    {
        public string status { get; set; }

        public IList<PessoaModel> data { get; set; }
    }
}