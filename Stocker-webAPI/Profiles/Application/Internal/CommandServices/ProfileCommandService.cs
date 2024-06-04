using Stocker_webAPI.Profiles.Domain.Model.Aggregates;
using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Domain.Model.Repositories;
using Stocker_webAPI.Profiles.Domain.Model.Services;
using Stocker_webAPI.Shared.Domain.Repositories;

namespace Stocker_webAPI.Profiles.Application.Internal.CommandServices;

public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
{
    public async Task<Profile?> Handle(CreateProfileCommand command)
    {
        var profile = new Profile(command);
        try
        {
            await profileRepository.AddAsync(profile);
            await unitOfWork.CompleteAsync();
            return profile;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}