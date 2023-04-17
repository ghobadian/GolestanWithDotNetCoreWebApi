using DataLayer.Models;
using DataLayer.Models.DTOs.Input;
using DataLayer.Models.DTOs.Output;
using DataLayer.Services;

namespace Golestan.Services.Interfaces;
public interface ITermService : ICrudService<TermInputDto, TermOutputDto>
{
    
}