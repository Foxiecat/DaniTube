namespace src.Features.Common.Interfaces;

public interface IMapper<TModel, out TResponse, in TRequest>
{
    TResponse MapToResponse(TModel model);
    TModel MapToModel(TRequest request);
}