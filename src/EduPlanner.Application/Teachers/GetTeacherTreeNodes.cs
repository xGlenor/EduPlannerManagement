using MediatR;
using EduPlanner.Application.Common;

namespace EduPlanner.Application.Teachers;

public record GetTeacherTreeNodes(int ParentId) : IRequest<TreeNodesDTO<TeacherDTO>>;