using MediatR;
using EduPlanner.Application.Common;
using EduPlanner.Application.Tree;

namespace EduPlanner.Application.Teachers;

public record GetTeacherTreeNodes(int ParentId) : IRequest<TreeNodesDTO<TeacherDTO>>;