using MediatR;
using EduPlanner.Application.Tree;
using EduPlanner.Application.Rooms;
using Microsoft.EntityFrameworkCore;
using EduPlanner.Domain.Entities.Rooms;


namespace EduPlanner.Infrastructure.Database.Handlers.Rooms;

internal class GetRoomTreeNodesHandler(NewDbContext dbContext)
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
                new TreeNodeDTO<RoomDTO>(
                    x.Id, 
                    x.Name, 
                    x.ShowPlan, 
                    dbContext.Rooms.Where(y=>y.RoomTreeId == x.Id).AsEnumerable().Select(ToDTO)
                )
            )
            .ToList();
        
        return new TreeNodesDTO<RoomDTO>(nodes);
    }

    private RoomDTO ToDTO(Room room) => new RoomDTO(room.Id, room.NrRoom, room.Type);
}