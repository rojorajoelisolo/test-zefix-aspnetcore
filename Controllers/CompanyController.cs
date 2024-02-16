using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Interfaces.Services;
using ZefixTest.Requests;
using ZefixTest.Responses.Base;
using ZefixTest.Responses.Company;

namespace ZefixTest.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        private readonly ILogger<CompanyController> _logger;

        public CompanyController(
            ICompanyService companyService,
            ILogger<CompanyController> logger
        ) {
            _companyService = companyService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(typeof(BaseResponse<CompanyListResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCompany()
        {
            try
            {
                var companies = await _companyService.GetCompanyList();
                return Ok(companies);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[ GET : /list ] An Error has occured : { exception.Message }");
                var errorResponse = new BaseResponse<ErrorResponse>
                {
                    Success = false,
                    Data = new ErrorResponse()
                    {
                        Message = $"An error has occured : { exception.Message }"
                    }
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("addbychid/{chid}")]
        [ProducesResponseType(typeof(BaseResponse<CompanyAdditionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCompanyByChid([FromRoute] string chid)
        {
            try
            {
                var companyAdded = await _companyService.AddCompanyByChid(chid);
                return Ok(companyAdded);
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, $"[ POST : /add/{ chid } ] An Error has occured : { exception.Message }");
                var errorResponse = new BaseResponse<ErrorResponse>
                {
                    Success = false,
                    Data = new ErrorResponse()
                    {
                        Message = $"An error has occured : { exception.Message }"
                    }
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(BaseResponse<CompanyAdditionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddCompany([FromBody] CompanyAdditionRequest company)
        {
            try
            {
                var companyAdded = await _companyService.AddCompany(company);
                return Ok(companyAdded);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[ POST : /add ] An Error has occured : { exception.Message }");
                var errorResponse = new BaseResponse<ErrorResponse>
                {
                    Success = false,
                    Data = new ErrorResponse()
                    {
                        Message = $"An error has occured : { exception.Message }"
                    }
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("delete/{chid}")]
        [ProducesResponseType(typeof(BaseResponse<CompanyDeletionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<ErrorResponse>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCompany([FromRoute] string chid)
        {
            try
            {
                var status = await _companyService.DeleteCompany(chid);
                return Ok(status);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[ DELETE : /delete/{ chid } ] An Error has occured : { exception.Message }");
                var errorResponse = new BaseResponse<ErrorResponse>
                {
                    Success = false,
                    Data = new ErrorResponse()
                    {
                        Message = $"An error has occured : { exception.Message }"
                    }
                };
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
