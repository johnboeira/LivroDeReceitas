using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivroDeReceitas.Exceptions.ExecptionBase;

public class ErrorOnValidationException : LivroDeReceitasException
{
    public IList<string> ErrorsMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorsMessages)
    {
        ErrorsMessages = errorsMessages;
    }
}
