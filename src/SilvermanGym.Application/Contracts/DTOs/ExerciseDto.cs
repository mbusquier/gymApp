using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SilvermanGym.Domain.Enum;

namespace SilvermanGym.Application.Contracts.DTOs
{
    public record ExerciseDto(Guid Id, string Name, ExerciseEquipment ExerciseEquipment, 
    ExerciseType ExerciseType, string Description);
}