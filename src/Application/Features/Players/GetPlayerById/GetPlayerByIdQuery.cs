namespace BifrostHub.Application.Features.Players.GetPlayerById;

using Common.Interfaces.Repositories;
using Dto;

public class GetPlayerByIdQuery
{
    public Guid Id { get; set; }
}

public static class GetPlayerByIdQueryHandler
{
    public static async Task<Player> Handle(GetPlayerByIdQuery query, IPlayerRepository playerRepository) =>
        (await playerRepository.GetById(query.Id)).ToDto();
}