using DataLayer.Models;

namespace Golestan.Services.Interfaces;
public interface ICrudService<TInputDto, TOutputDto>
{
    IEnumerable<TOutputDto> List();
    TOutputDto Create(TInputDto dto);
    TOutputDto Read(int id);
    TOutputDto Update(int id, TInputDto dto);
    void Delete(int id);
}

