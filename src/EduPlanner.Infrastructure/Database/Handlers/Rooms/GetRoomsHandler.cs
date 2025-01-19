using MediatR;
using EduPlanner.Application.Rooms;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Domain.Entities.Rooms;

namespace EduPlanner.Infrastructure.Database.Handlers.Rooms;

internal class GetRoomsHandler(NewDbContext dbContext) : IRequestHandler<GetRooms, IEnumerable<RoomDTO>>
{
    public async Task<IEnumerable<RoomDTO>> Handle(GetRooms request, CancellationToken cancellationToken)
    {
        var trimmedNr = request.Nr.Trim();
        
        var rooms = await dbContext
            .Rooms
            .Where(x=>x.NrRoom.Contains(trimmedNr))
            .ToListAsync(cancellationToken);
        
        return rooms
            .Select(ToDTO)
            .ToArray();
    }
    
    private RoomDTO ToDTO(Room room) => new RoomDTO(room.Id, room.NrRoom, room.Type);
}