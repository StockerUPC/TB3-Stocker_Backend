using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Queries;

namespace Stocker_webAPI.Profiles.Domain.Model.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}