using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Interfaces.Handlers;
using ZefixTest.Interfaces.Repositories;
using ZefixTest.Interfaces.Services;
using ZefixTest.Models;
using ZefixTest.Requests;
using ZefixTest.Responses.Base;
using ZefixTest.Responses.Company;
using ZefixTest.Responses.ZefixApi.Company;

namespace ZefixTest.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        public ICompanyRepository _companyRepository { get; set; }

        public IZefixCompanyHandler _zefixCompanyHandler { get; set; }

        public CompanyService(
            IMapper mapper,
            ICompanyRepository companyRepository,
            IZefixCompanyHandler zefixCompanyHandler
        ) : base(mapper)
        {
            _companyRepository = companyRepository;
            _zefixCompanyHandler = zefixCompanyHandler;
        }

        public async Task<BaseResponse<CompanyAdditionResponse>> AddCompanyByChid(string chid)
        {
            var company = await _companyRepository.GetCompanyByChid(chid);
            var isSuccess = false;

            if (company == null)
            {
                var companyResponseMessage = await _zefixCompanyHandler.GetByChid(chid);
                isSuccess = companyResponseMessage.IsSuccessStatusCode;
                var jsonResponseContent = await companyResponseMessage.Content.ReadAsStringAsync();

                if (isSuccess)
                {
                    var companySuccessResponseList = JsonConvert.DeserializeObject<List<CompanySuccessResponse>>(jsonResponseContent);
                    var companySuccessResponse = companySuccessResponseList.FirstOrDefault();
                    var companyModel = _mapper.Map<Company>(companySuccessResponse);
                    company = await _companyRepository.AddAsync(companyModel);
                }
                else
                {
                    var errorContent = JsonConvert.DeserializeObject<CompanyErrorResponse>(jsonResponseContent);
                    throw new ArgumentException(errorContent.message);
                }
            }

            return new BaseResponse<CompanyAdditionResponse>
            {
                Success = isSuccess,
                Data = new CompanyAdditionResponse
                {
                    Company = company
                }
            };
        }

        public async Task<BaseResponse<CompanyAdditionResponse>> AddCompany(CompanyAdditionRequest company)
        {
            var companyModel = _mapper.Map<Company>(company);
            var companyAdded = await _companyRepository.AddAsync(companyModel);

            return new BaseResponse<CompanyAdditionResponse>
            {
                Success = true,
                Data = new CompanyAdditionResponse
                {
                    Company = companyAdded
                }
            };
        }

        public async Task<BaseResponse<CompanyDeletionResponse>> DeleteCompany(string chid)
        {
            var company = await _companyRepository.GetCompanyByChid(chid);
            await _companyRepository.DeleteAsync(company);

            return new BaseResponse<CompanyDeletionResponse>
            {
                Success = true,
                Data = new CompanyDeletionResponse
                {
                    Deleted = true
                }
            };
        }

        public async Task<BaseResponse<CompanyListResponse>> GetCompanyList()
        {
            var companies = (IList<Company>) await _companyRepository.GetAllAsync();

            return new BaseResponse<CompanyListResponse>
            {
                Success = true,
                Data = new CompanyListResponse
                {
                    Companies = companies
                }
            };
        }
    }
}
