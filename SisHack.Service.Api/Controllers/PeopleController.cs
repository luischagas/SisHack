using Microsoft.AspNetCore.Mvc;
using SisHack.Application.Interfaces;
using SisHack.Domain.Shared.Interface.Notification;
using System;
using System.Net;
using System.Threading.Tasks;
using SisHack.Application.Models.People.Request;

namespace SisHack.Service.Api.Controllers
{
    [Route("api/[controller]")]
    public class PeopleController : BaseController
    {
        #region Private Fields

        private readonly IPeopleService _peopleService;

        #endregion Private Fields

        #region Public Constructors

        public PeopleController(INotifier notifier,
            IPeopleService peopleService) : base(notifier)
        {
            _peopleService = peopleService;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var people = await _peopleService.Get(id);

            if (ValidOperation() is false)
                return GenerateResponse(HttpStatusCode.NotFound, people);

            return GenerateResponse(HttpStatusCode.OK, people);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PeopleRequestModel request)
        {
           var people = await _peopleService.Add(request);

            if (ValidOperation() is false)
                return GenerateResponse(HttpStatusCode.NotFound, people);

            return GenerateResponse(HttpStatusCode.Created, people);
        }

        #endregion Public Methods
    }
}