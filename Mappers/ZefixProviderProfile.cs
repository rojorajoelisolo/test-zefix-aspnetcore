using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZefixTest.Helpers;
using ZefixTest.Models;
using ZefixTest.Requests;
using ZefixTest.Responses.ZefixApi.Company;

namespace ZefixTest.Mappers
{
    public class ZefixProviderProfile : Profile
    {
        public ZefixProviderProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            #region Company
            CreateMap<CompanySuccessResponse, Company>()
                .ForMember(resp => resp.Name, map => map.MapFrom(root => root.name))
                .ForMember(resp => resp.Chid, map => map.MapFrom(root => root.chid))
                .ForMember(resp => resp.LegalSeat, map => map.MapFrom(root => root.legalSeat))
                .ForMember(resp => resp.LastModification, map => map.MapFrom(root => CommonHelper.ConvertStringToDate(root.sogcDate)))
                .ForMember(resp => resp.LegalForm, map => map.MapFrom(root => (root.legalForm.name.fr + " (" + root.legalForm.shortName.fr + ")")))
                .ForMember(resp => resp.Address, map => map.MapFrom(root => (root.address.street + ", " + root.address.city + " " + root.address.swissZipCode)));
            CreateMap<CompanyAdditionRequest, Company>()
                .ForMember(resp => resp.Name, map => map.MapFrom(root => root.Name))
                .ForMember(resp => resp.Chid, map => map.MapFrom(root => root.Chid))
                .ForMember(resp => resp.LegalSeat, map => map.MapFrom(root => root.Seat))
                .ForMember(resp => resp.LastModification, map => map.MapFrom(root => CommonHelper.ConvertStringToDate(root.LastModification)))
                .ForMember(resp => resp.LegalForm, map => map.MapFrom(root => root.LegalForm))
                .ForMember(resp => resp.Address, map => map.MapFrom(root => root.Address));
            #endregion
        }
    }
}
