﻿using DTOLayer.DTOs.DestinationsDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules.DestinationValidator
{
    public class DestinationViewValidator : AbstractValidator<DestinationViewDTO>
    {
        public DestinationViewValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir kısmını boş geçemezsiniz...!");
            RuleFor(x => x.DayNight).NotEmpty().WithMessage("Gün gece kısmını boş geçemezsiniz...!");
            RuleFor(x => x.Capacity).NotEmpty().WithMessage("Kapasite kısmını boş geçemezsiniz...!");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat kısmını boş geçemezsiniz...!");
        }
    }
}