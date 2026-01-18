using System;
using System.Collections.Generic;
using System.Text;

namespace GoldSystemSolutions.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        //Construtor da classe que recebe a mensagem de erro
        public DomainExceptionValidation(String error) : base(error){}


        //Método estático para validar regras de negócio
        public static void When(bool hasError, String error)
        {
            if (hasError)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
