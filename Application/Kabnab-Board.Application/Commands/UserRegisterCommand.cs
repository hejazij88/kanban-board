using Kabnab_Board.Application.DTOs;
using MediatR;

namespace Kabnab_Board.Application.Commands;

public record UserRegisterCommand(RegisterDTO Dto):IRequest<bool>;