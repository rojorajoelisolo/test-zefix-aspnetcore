using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Models;
using ZefixTest.Requests;
using ZefixTest.Responses.Base;
using ZefixTest.Responses.Company;

namespace ZefixTest.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<BaseResponse<CompanyListResponse>> GetCompanyList();

        Task<BaseResponse<CompanyAdditionResponse>> AddCompanyByChid(string chid);

        Task<BaseResponse<CompanyAdditionResponse>> AddCompany(CompanyAdditionRequest company);

        Task<BaseResponse<CompanyDeletionResponse>> DeleteCompany(string chid);

    }
}
