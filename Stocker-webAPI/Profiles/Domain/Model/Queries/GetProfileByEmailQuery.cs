using Stocker_webAPI.Profiles.Domain.Model.ValueObjects;

namespace Stocker_webAPI.Profiles.Domain.Model.Queries;

public record GetProfileByEmailQuery(EmailAddress Email);