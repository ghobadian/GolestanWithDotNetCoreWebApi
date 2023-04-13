namespace Golestan.Controllers;

public interface ICrudController<TInputDto, TOutputDto>
{
    IEnumerable<TOutputDto> List(string token, int pageNumber = 1, int pageSize = 100);
    TOutputDto Create(TInputDto dto, string token);
    TOutputDto Read(int id, string token);
    TOutputDto Update(int id, TInputDto dto, string token);
    void Delete(int id, string token);
}