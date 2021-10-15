using System.Collections.Generic;
using FluentValidation;
using SisHack.Domain.Enums.People;

namespace SisHack.Domain.Entities
{
    public class People : Entity<People>
    {

        #region Public Constructors

        public People(string name, string phoneNumber, EPeopleType type)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Type = type;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public EPeopleType Type { get; private set; }

        #endregion Public Properties

        #region Public Methods

        public override bool IsValid()
        {
            ValidateName();
            ValidatePhoneNumber();
            ValidateType();

            AddErrors(Validate(this));

            return ValidationResult.IsValid;
        }

        #endregion Public Methods

        #region Private Methods

        private void ValidateName()
        {
            RuleFor(d => d.Name)
                .NotEmpty()
                .WithMessage("O nome deve ser preenchido");
        }

        private void ValidatePhoneNumber()
        {
            RuleFor(d => d.PhoneNumber)
                .NotEmpty()
                .WithMessage("O telefone deve ser preenchido");
        }

        private void ValidateType()
        {
            RuleFor(d => d.Type)
                .IsInEnum()
                .WithMessage("O tipo não é válido");
        }

        #endregion Private Methods

    }
}