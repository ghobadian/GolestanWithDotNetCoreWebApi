using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Services;

namespace Golestan.Services.Interfaces;
public interface ITermService : ICrudService<Term, TermInputDto>
{
    
}