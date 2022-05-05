using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilvermanGym.Application.Contracts.DTOs;

namespace SilvermanGym.Application.Contracts.Queries;
    public record GetWorkoutByIdQuery(Guid Id) : IRequest<WorkoutDto>;