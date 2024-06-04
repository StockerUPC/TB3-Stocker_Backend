using Stocker_webAPI.Profiles.Domain.Model.Commands;
using Stocker_webAPI.Profiles.Domain.Model.Queries;
using Stocker_webAPI.Profiles.Domain.Model.Services;
using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

namespace Stocker_webAPI.Profiles.Interfaces.ACL;

/**
 * Profiles context facade.
 *
 * <summary>
 * This class represents the profiles context facade, part of the profiles anti-corruption layer.
 * It contains the methods to interact with the profiles context from other bounded context.
 * </summary>
 */
public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
{
    public async Task<int> CreateProfile(string username, string password, string email, DateTime subscriptionDate, string subscriptionPlan)
    {
        var createProfileCommand = new CreateProfileCommand(username,  password,  email,  subscriptionDate,  subscriptionPlan);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
    
    /**
     * Fetch a profile id by email.
     *
     * <param name="email">The email of the profile</param>
     * <returns>The profile id</returns>
     * 
     */
    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}