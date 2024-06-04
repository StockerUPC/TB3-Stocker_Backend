using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;
using Stocker_webAPI.Shared.Domain.Repositories;

namespace Stocker_webAPI.Profiles.Domain.Model.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}