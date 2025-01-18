using MediatR;
using EduPlanner.Application.Rooms;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Application.Common;
using EduPlanner.Domain.Entities.Rooms;

namespace EduPlanner.Infrastructure.Database.Handlers.Courses;

public class GetRoomTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetRoomTreeNodes, TreeNodesDTO<RoomDTO>>
{
    public async Task<TreeNodesDTO<RoomDTO>> Handle(GetRoomTreeNodes request, CancellationToken cancellationToken)
    {
        var roomNodes = await dbContext
            .RoomTrees
            .Where(x => x.ParentId == request.ParentId)
            .ToListAsync(cancellationToken: cancellationToken);

        var nodes = roomNodes
            .Select(x =>
            {
                var rooms = dbContext
                    .Rooms
                    .Where(y => y.RoomTreeId == x.Id)
                    .ToArray();
                return new TreeNodeDTO<RoomDTO>(x.Id, x.Name, x.ShowPlan, rooms.Select(ToRoomDTO));
            })
            .ToList();

         return new TreeNodesDTO<RoomDTO>(nodes);
    }

    private RoomDTO ToRoomDTO(Room room) => new RoomDTO(room.Id, room.NrRoom);
}