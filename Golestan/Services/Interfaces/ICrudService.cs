using DataLayer.Models;

namespace Golestan.Services.Interfaces;
public interface ICrudService<T, TInputDto>
{
    IEnumerable<T> List();
    T Create(TInputDto dto);
    T Read(int id);
    T Update(int id, TInputDto dto);
    void Delete(int id);
}

