using SisHack.Domain.Enums.People;

namespace SisHack.Application.Models.People.Request
{
    public class PeopleRequestModel
    {
        #region Public Properties

        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public EPeopleType Type { get; set; }

        #endregion Public Properties
    }
}