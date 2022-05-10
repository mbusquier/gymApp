using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries;
using SilvermanGym.Application.Exceptions;
using SilvermanGym.Application.Interfaces;

namespace SilvermanGym.Application.Handlers.Queries
{
    public class GetExerciseByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseDto>
    {
        public readonly IExerciseRepository _exerciseRepository;

        public GetExerciseByIdQueryHandler(IExerciseRepository exerciseRepository)
        {
            this._exerciseRepository = exerciseRepository;
        }

        public async Task<ExerciseDto> Handle(GetExerciseByIdQuery request, CancellationToken cancellationToken)
        {
            var exerEntity = await _exerciseRepository.GetExerciseById(request.Id,cancellationToken);
            
            if(exerEntity is null)
            {
                throw new NotFoundException($"The exercise with the Id = {request.Id} could not be found.");
            }
            else
            {
                var exercise = new ExerciseDto
                (
                    exerEntity.Id,
                    exerEntity.Name,
                    exerEntity.ExerciseEquipment,
                    exerEntity.ExerciseType,
                    exerEntity.Description
                );

                return exercise;
            }
            
        }
    }
}