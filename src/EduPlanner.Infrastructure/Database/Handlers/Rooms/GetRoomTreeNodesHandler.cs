using EduPlanner.Application.Common;
using EduPlanner.Application.Rooms;
using EduPlanner.Application.Tree;
using EduPlanner.Domain.Entities.Rooms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduPlanner.Infrastructure.Database.Handlers.Rooms;

internal class GetRoomTreeNodesHandler(NewDbContext dbContext)
    : IRequestHandler<GetRoomTreeNodes, TreeNodesDTO<RoomDTO>>
{
    public async Task<TreeNodesDTO<RoomDTO>> Handle(GetRoomTreeNodes request, CancellationToken cancellationToken)
    {
        // var roomNodes = await dbContext
        //     .RoomTrees
        //     .Include(x=>x.Rooms)
        //     .Where(x => x.ParentId == request.ParentId)
        //     .ToListAsync(cancellationToken: cancellationToken);
        //
        // var nodes = roomNodes
        //     .Select(x => new TreeNodeDTO<RoomDTO>(x.Id, x.Name, x.ShowPlan, x.Rooms.Select(ToRoomDTO)))
        //     .ToList();
        //
        //  return new TreeNodesDTO<RoomDTO>(nodes);
        return null;
    }

    private RoomDTO ToRoomDTO(Room room) => new RoomDTO(room.Id, room.NrRoom, room.Type);
}