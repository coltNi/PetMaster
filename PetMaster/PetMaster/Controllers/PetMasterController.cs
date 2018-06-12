using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetMaster.Common;
using PetMaster.ViewModels.PetMasterGrouping;
using PetMasterGroupingProvider.Service;
using PetMasterGroupingProvider.Domain;

namespace PetMaster.Controllers
{
    [Route("api/[controller]")]
    public class PetMasterController : Controller
    {
        private readonly IPetMasterService _service;
        private readonly ILogger<PetMasterController> _logger;

        public PetMasterController(IPetMasterService service, ILogger<PetMasterController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("{type}/master-gender-group")]
        public IActionResult GetOwnersByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                _logger.LogError("No pet type was provided");
                throw new ApiResponseException(HttpStatusCode.BadRequest, "No pet type provided");
            }

            var groups = _service.GetAscendingNameForTypeGroupByMasterGender(type);
            var vm = groups.Select(ToVm);
            return Ok(vm);
        }

        private GenderGroupVm ToVm(PetByMasterGenderGroup domainGroup)
        {
            return new GenderGroupVm()
            {
                Gender = domainGroup.Gender.ToString("G"),
                Names = domainGroup.PetNames
            };
        }
    }
}