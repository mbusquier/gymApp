using MediatR;
using Microsoft.EntityFrameworkCore;
using SilvermanGym.Application.Contracts.DTOs;
using SilvermanGym.Application.Contracts.Queries.Exercises;
using SilvermanGym.Infraestructure.Persistence.DbContexts;

namespace SilvermanGym.Application.Handlers.Queries.Exercise
{
    public class GetAllExercisesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDto>>
    {
        public readonly AppDbContext _context;

        public GetAllExercisesQueryHandler(AppDbContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercisesQuery request, CancellationToken cancellationToken)
        {
            var exercises = await _context.Exercises
            .AsNoTracking()
            .Select(exc => new ExerciseDto
            (
                exc.Id,
                exc.Name,
                exc.ExerciseEquipment,
                exc.ExerciseType,
                exc.Description
            ))
            .ToListAsync(cancellationToken);

        return exercises;
        }
    }
}