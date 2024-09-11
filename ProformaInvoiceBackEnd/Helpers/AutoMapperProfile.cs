using AutoMapper;
using Newtonsoft.Json;
using ProformaInvoiceBackEnd.DTOs;
using ProformaInvoiceBackEnd.Models;
using static ProformaInvoiceBackEnd.DTOs.CreateRequestDTO;

namespace ProformaInvoiceBackEnd.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            // ReverseMap is used to create bidirectional mapping
            CreateMap<User, userDTO>().ReverseMap();
            CreateMap<plant, plantDTO>().ReverseMap();
            CreateMap<Departement, departementDTO>().ReverseMap();
            /*CreateMap<request, CreateRequestDTO>().ReverseMap();
            CreateMap<request, CreateRequestDTO>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Item));
            CreateMap<Items, CreateRequestDTO.CreateItemDTO>();*/
            // Mapping configuration for CreateRequestDTO to request
            CreateMap<CreateRequestDTO, request>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Items))
                .ReverseMap();

            // Mapping configuration for CreateItemDTO to Items
            CreateMap<Items, CreateRequestDTO.CreateItemDTO>()
               .ForMember(dest => dest.Id_items, opt => opt.MapFrom(src => src.id_items))
               .ForMember(dest => dest.PN, opt => opt.MapFrom(src => src.PN))
               .ForMember(dest => dest.QUANTITY, opt => opt.MapFrom(src => src.QUANTITY))
               .ForMember(dest => dest.UNITOFQUANTITY, opt => opt.MapFrom(src => src.UNITOFQUANTITY))
               .ForMember(dest => dest.UNITVALUEFINANCE, opt => opt.MapFrom(src => src.UNITVALUEFINANCE))
               .ForMember(dest => dest.DESCRIPTION, opt => opt.MapFrom(src => src.DESCRIPTION))
               .ForMember(dest => dest.COSTCENTER, opt => opt.MapFrom(src => src.COSTCENTER))
               .ForMember(dest => dest.BUSINESSUNIT, opt => opt.MapFrom(src => src.BUSINESSUNIT))
               .ForMember(dest => dest.PLANT, opt => opt.MapFrom(src => src.PLANT));

            CreateMap<CreateRequestDTO.CreateItemDTO, Items>()
               .ForMember(dest => dest.id_items, opt => opt.MapFrom(src => src.Id_items))
               .ForMember(dest => dest.PN, opt => opt.MapFrom(src => src.PN))
               .ForMember(dest => dest.QUANTITY, opt => opt.MapFrom(src => src.QUANTITY))
               .ForMember(dest => dest.UNITOFQUANTITY, opt => opt.MapFrom(src => src.UNITOFQUANTITY))
               .ForMember(dest => dest.UNITVALUEFINANCE, opt => opt.MapFrom(src => src.UNITVALUEFINANCE))
               .ForMember(dest => dest.DESCRIPTION, opt => opt.MapFrom(src => src.DESCRIPTION))
               .ForMember(dest => dest.COSTCENTER, opt => opt.MapFrom(src => src.COSTCENTER))
               .ForMember(dest => dest.BUSINESSUNIT, opt => opt.MapFrom(src => src.BUSINESSUNIT))
               .ForMember(dest => dest.PLANT, opt => opt.MapFrom(src => src.PLANT))
               .ForMember(dest => dest.RequestNumber, opt => opt.Ignore())
               .ForMember(dest => dest.request, opt => opt.Ignore());
            CreateMap<scenario, scenarioDTO>().ReverseMap();
            CreateMap<approverscenario, approverScenarioDTO>().ReverseMap();
            CreateMap<request_item, request_itemDTO>().ReverseMap();
            CreateMap<scenario_items_configuration, scenario_items_configurationDTO>().ReverseMap();
            CreateMap<UserPlant, UserPlantDTO>().ReverseMap();
            CreateMap<shippoint, shipPointDTO>().ReverseMap();
            CreateMap<ApproverRequest, CreateApproverRequestDTO>().ReverseMap();
        }
    }
}
