namespace src.Features.Common.Interfaces;

public interface IMapper<TRequest, TResponse>
{
    TResponse MapToResponse(TRequest request);
    TRequest MapToRequest(TResponse response);
}