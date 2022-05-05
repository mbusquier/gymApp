using MediatR;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries;
using SilvermanGym.Application.Exceptions;
using SilvermanGym.Application.Interfaces;

namespace SilvermanGym.Application.Handlers.Queries
{
    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDto>>
    {
        public readonly IExerciseRepository _exerciseRepository;

        public GetAllExercisesQueryHandler(IExerciseRepository exerciseRepository)
        {
            this._exerciseRepository = exerciseRepository;
        }

        public async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercisesEntities = await _exerciseRepository.GetAllExercises(cancellationToken);

            if(exercisesEntities.Count == 0)
            {
                throw new NotFoundException($"There is no exercises in the database");
            }
            else
            {
                var exercises = exercisesEntities
                    .Select(exc => new ExerciseDto
                    (
                        exc.Id,
                        exc.Name,
                        exc.ExerciseEquipment,
                        exc.ExerciseType,
                        exc.Description
                    ));
                return exercises;
            }
        }
    }
}