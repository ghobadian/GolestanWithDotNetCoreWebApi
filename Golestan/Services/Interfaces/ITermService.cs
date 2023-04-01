using DataLayer.Models;
using DataLayer.Services;

namespace Golestan.Services.Interfaces;
public interface ITermService
{
    IEnumerable<Term> List( /*int page, int number*/);
    Term Create(string title, bool open);
    Term Read(int termId);
    Term Update(string title, bool? open, int termId);
    void Delete(int id);
}