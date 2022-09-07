using Application.Features.LanguageFeatures.Commands.CreateLanguage;
using Application.Features.LanguageFeatures.Commands.DeleteLanguageCommand;
using Application.Features.LanguageFeatures.Commands.UpdateLanguage;
using Application.Features.LanguageFeatures.Dtos;
using Application.Features.LanguageFeatures.Models;
using Application.Features.LanguageFeatures.Queries.GetByIdLanguage;
using Application.Features.LanguageFeatures.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result= await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async  Task<IActionResult> GetById([FromRoute]GetByIdLanguageQuery getByIdLanguageQuery)
        {
            LanguageGetByIdDto languageGetByIdDto = await Mediator.Send(getByIdLanguageQuery);
            return Ok(languageGetByIdDto);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Updated([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdatedLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Ok(result);
        }
        [HttpPost("Name")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeletedLanguageDto result = await Mediator.Send(deleteLanguageCommand);
            return Ok(result);
        }
    }
}
