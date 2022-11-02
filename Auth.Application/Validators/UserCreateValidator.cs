﻿using Auth.Application.Enums;
using Auth.Application.UseCases.CreateUser.Request;
using Auth.Application.Validators.Conditions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<CreateUserRequest>
    {
        public UserCreateValidator()
        {
            RuleFor(request => request.Email)
               .NotEmpty()
               .WithMessage(ErrorMessages.EmailNoEmpty)
               .EmailAddress()
               .WithMessage(ErrorMessages.EmailInvalid);

            RuleFor(request => request.Password)
               .NotEmpty()
               .WithMessage(ErrorMessages.PasswordNoEmpty)
               .Length(8, 15)
               .WithMessage(ErrorMessages.PasswordLen)
               .Must(Password => ValidatorConditions.HasValidPassword(Password))
               .WithMessage(ErrorMessages.PasswordLogic);
        }
    }
}
