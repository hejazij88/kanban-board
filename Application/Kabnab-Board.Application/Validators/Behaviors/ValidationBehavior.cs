using FluentValidation;
using Kabnab_Board.Application.Commands;
using MediatR;

namespace Kabnab_Board.Application.Validators.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                var errors = failures.Select(f => f.ErrorMessage).ToList();

                var resultType = typeof(TResponse);

                if (resultType.IsGenericType &&
                    resultType.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var failureMethod = resultType
                        .GetMethod("Failure",
                            System.Reflection.BindingFlags.Public |
                            System.Reflection.BindingFlags.Static);

                    return (TResponse)failureMethod!
                        .Invoke(null, new object[] { errors })!;
                }

                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}