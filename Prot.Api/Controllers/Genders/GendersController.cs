using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prot.Domain.Configurations;
using Prot.Domain.Dto.Genders;
using Prot.Domain.Models.Genders;
using Prot.Domain.Models.Response;
using Prot.Service.Extentions;
using Prot.Service.Interfaces.Genders;

namespace Prot.Api.Controllers.Genders;

[Route("customapi/[controller]")]
[ApiController]
public class GendersController : ControllerBase
{
    private readonly IGenderRepository _genderRepository;
    public GendersController(IGenderRepository genderRepository)
        => _genderRepository = genderRepository;

    [HttpGet]
    [ProducesResponseType(typeof(ResponseModel<GenderModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseModel<>), StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> GetAll([FromQuery] PaginationParams @params)
    => ResponseHandler.ReturnResponseList(await _genderRepository.GetAll(@params));

    [HttpPost]
   // [Authorize]
    [ProducesResponseType(typeof(ResponseModel<GenderModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseModel<>), StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> CreateAsync([FromBody] GenderDto genderDto)
        => ResponseHandler.ReturnIActionResponse(await _genderRepository.CreateAsync(genderDto));

    [HttpDelete("{id}")]
    //[Authorize]
    [ProducesResponseType(typeof(ResponseModel<bool>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseModel<>), StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> DeleteAsync([FromRoute] int id)
        => ResponseHandler.ReturnIActionResponse(await _genderRepository.DeleteAsync(id));


    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ResponseModel<GenderModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseModel<>), StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> GetAsync([FromRoute] int id)
        => ResponseHandler.ReturnIActionResponse(await _genderRepository.GetAsync(u => u.Id == id));


    [HttpPut]
   // [Authorize]
    [ProducesResponseType(typeof(ResponseModel<GenderModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseModel<>), StatusCodes.Status400BadRequest)]
    public async ValueTask<IActionResult> UpdateAsync(int id, [FromBody] GenderDto genderDto)
        => ResponseHandler.ReturnIActionResponse(await _genderRepository.UpdateAsync(id, genderDto));
}
