using FluentValidation;

using Entities.DTOs.FriendsList;

namespace Business.Validators.FriendsList;

public class FriendsListUpdateDtoValidations:AbstractValidator<FriendsListUpdateDto>
{
    public FriendsListUpdateDtoValidations()
    {
    }
}
