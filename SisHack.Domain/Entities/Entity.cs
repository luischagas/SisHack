using FluentValidation.Results;
using System;
using FluentValidation;

namespace SisHack.Domain.Entities
{
    public abstract class Entity<T> : AbstractValidator<T>
        where T : Entity<T>
    {
        #region Protected Constructors

        public Entity()
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedOn = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        #endregion Protected Constructors

        #region Public Properties

        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        #endregion Public Properties

        #region Public Methods

        public abstract bool IsValid();

        public void Delete()
        {
            IsDeleted = true;
        }

        #endregion Public Methods

        #region Protected Methods

        protected void AddErrors(ValidationResult validateResult)
        {
            foreach (var error in validateResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        #endregion Protected Methods
    }
}