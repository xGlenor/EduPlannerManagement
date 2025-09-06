using EduPlanner.Application.Tree;
using EduPlanner.Domain.Entities.Teachers;
using MediatR;

namespace EduPlanner.Application.Teachers;

public sealed record GetTeacherTree(int? RootId = null) : IRequest<List<TreeDTO<TeacherDTO>>>;