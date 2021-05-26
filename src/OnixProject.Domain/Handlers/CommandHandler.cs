using FluentValidation.Results;
using OnixProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnixProject.Domain.Handlers
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> CommitAsync(IUnitOfWork uow, string message)
        {
            if (!await uow.CommitAsync()) AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> CommitAsync(IUnitOfWork uow)
        {
            return await CommitAsync(uow, "There was an error saving data").ConfigureAwait(false);
        }
    }
}
