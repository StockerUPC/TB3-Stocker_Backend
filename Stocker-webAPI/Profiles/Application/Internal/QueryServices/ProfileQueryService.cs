using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Queries;
using Stocker_webAPI.Profiles.Domain.Model.Repositories;
using Stocker_webAPI.Profiles.Domain.Model.Services;

namespace Stocker_webAPI.Profiles.Application.Internal.QueryServices;

public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
{
    public async Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query)
    {
        return await profileRepository.ListAsync();
    }

    public async Task<Profile?> Handle(GetProfileByEmailQuery query)
    {
        return await profileRepository.FindProfileByEmailAsync(query.Email);
    }

    public async Task<Profile?> Handle(GetProfileByIdQuery query)
    {
        return await profileRepository.FindByIdAsync(query.ProfileId);
    }
}