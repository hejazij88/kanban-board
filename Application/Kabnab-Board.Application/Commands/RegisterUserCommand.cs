using Kabnab_Board.Application.DTOs;
using MediatR;

namespace Kabnab_Board.Application.Commands;

public record RegisterUserCommand(string email,string password,string fullName):IRequest;