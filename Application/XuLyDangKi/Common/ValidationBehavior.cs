using FluentValidation;
using MediatR;

namespace finalproject.Application.Common;
public class ValidationBehavior<TRequest,TReponse> : IPipelineBehavior<TRequest,TReponse> where TRequest : IRequest<TReponse>

{
    private readonly IEnumerable<IValidator<TRequest>> _validator;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
    {
        _validator=validator;

    }
    public async Task<TReponse> Handle(TRequest request,RequestHandlerDelegate<TReponse> next,CancellationToken cancellationToken)
    {
        if(_validator.Any())
        {
            var context=new ValidationContext<TRequest>(request);
            var errors=_validator
            .Select(v=> v.Validate(context))
            .SelectMany(r=>r.Errors)
            .Where(e=>e != null)
            .ToList();
             if (errors.Any())
                    throw new ValidationException(errors);
        }
        return await next();
    }
}
