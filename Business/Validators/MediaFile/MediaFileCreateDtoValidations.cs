using FluentValidation;

using Entities.DTOs.MediaFile;

namespace Business.Validators.MediaFile;

public class MediaFileCreateDtoValidations:AbstractValidator<MediaFileCreateDto>
{
    public MediaFileCreateDtoValidations()
    {
        // RuleFor(mf => mf.FileName)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(100).WithMessage("This field requires less than or equal to 100 symbols!");
        // RuleFor(mf => mf.FilePath)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(100).WithMessage("This field requires less than or equal to 100 symbols!");
        // RuleFor(mf => mf.FileType)
        //     .MinimumLength(1).WithMessage("This field requires greater than or equal to 1 symbols!")
        //     .MaximumLength(16).WithMessage("This field requires less than or equal to 16 symbols!");
    }
}
