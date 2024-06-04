using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Repositories;
using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Configuration;
using Stocker_webAPI.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Stocker_webAPI.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class ProfileRepository(AppDbContext context) : BaseRepository<Profile>(context), IProfileRepository
{
    public Task<Profile?> FindProfileByEmailAsync(EmailAddress email)
    {
        return Context.Set<Profile>().Where(p => p.Email == email).FirstOrDefaultAsync();
    }
}