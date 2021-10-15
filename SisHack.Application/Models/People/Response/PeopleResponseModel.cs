using System;
using SisHack.Domain.Enums.People;

namespace SisHack.Application.Models.People.Response
{
    public class PeopleResponseModel
    {
        #region Public Properties

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public EPeopleType Type { get; set; }

        #endregion Public Properties
    }
}