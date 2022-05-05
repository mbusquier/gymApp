using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilvermanGym.Application.Contracts.DTOs
{
    public record UserDto(Guid id, string Username, int Age, float Height, float Weight, float IMC);
}