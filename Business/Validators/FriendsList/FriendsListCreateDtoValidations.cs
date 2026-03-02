using FluentValidation;

using Entities.DTOs.FriendsList;

namespace Business.Validators.FriendsList;

public class FriendsListCreateDtoValidations:AbstractValidator<FriendsListCreateDto>
{
    public FriendsListCreateDtoValidations()
    {
    }
}
