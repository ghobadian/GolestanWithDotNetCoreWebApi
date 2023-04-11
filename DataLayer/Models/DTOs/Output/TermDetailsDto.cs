using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;
public record TermDetailsDto(int Id, string Title, double StudentAverage) : TermOutputDto(Id, Title);

