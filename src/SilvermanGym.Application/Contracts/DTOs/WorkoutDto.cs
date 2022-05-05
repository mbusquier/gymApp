using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilvermanGym.Application.Contracts.DTOs
{
    public record WorkoutDto(Guid id, string Name, DateTime WorkoutDate, Guid UserId);
}