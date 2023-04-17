using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models.DTOs.Output;

public record SummeryDto(List<TermDetailsDto> TermDetails, double TotalAverage);

