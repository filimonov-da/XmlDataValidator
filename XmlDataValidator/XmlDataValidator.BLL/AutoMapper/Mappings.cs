using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace XmlDataValidator.BLL.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //CreateMap<LDAPUser, User>()
            //    .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.Company.Name))
            //    .ForMember(d => d.CompanyShortName, o => o.MapFrom(s => s.Company.ShortName));

            //CreateMap<User, t_web_client>()
            //    .ForMember(d => d.COMPANY_NAME, o => o.MapFrom(s => s.CompanyName))
            //    .ForMember(d => d.COMPANY_SHORT_NAME, o => o.MapFrom(s => s.CompanyShortName))
            //    .ForMember(d => d.FIRST_NAME, o => o.MapFrom(s => s.FirstName))
            //    .ForMember(d => d.LAST_NAME, o => o.MapFrom(s => s.LastName))
            //    .ForMember(d => d.LDAP_ID, o => o.MapFrom(s => s.LdapId))
            //    .ForMember(d => d.MIDDLE_NAME, o => o.MapFrom(s => s.MiddleName))
            //    .ForMember(d => d.ROLES, o => o.MapFrom(s => String.Join(",", s.Roles.Select(t => t.Name).ToArray())))
            //    .ReverseMap()
            //    .ForMember(d => d.CompanyName, o => o.MapFrom(s => s.COMPANY_NAME))
            //    .ForMember(d => d.CompanyShortName, o => o.MapFrom(s => s.COMPANY_SHORT_NAME))
            //    .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FIRST_NAME))
            //    .ForMember(d => d.LastName, o => o.MapFrom(s => s.LAST_NAME))
            //    .ForMember(d => d.LdapId, o => o.MapFrom(s => s.LDAP_ID))
            //    .ForMember(d => d.MiddleName, o => o.MapFrom(s => s.MIDDLE_NAME))
            //    .ForMember(d => d.Roles, o => o.MapFrom(s => Role.GetRoles(s.ROLES)));

            //CreateMap<Block, t_web_client_block>()
            //    .ReverseMap()
            //    .ForMember(d => d.BlockIsImported, o => o.MapFrom(s => s.BLOCK_IS_IMPORTED))
            //    .ForMember(d => d.BlockName, o => o.MapFrom(s => s.BLOCK_NAME))
            //    .ForMember(d => d.BlockTotal, o => o.MapFrom(s => s.BLOCK_TOTAL))
            //    .ForMember(d => d.BlockId, o => o.MapFrom(s => s.ID));

            //CreateMap<Section, t_web_client_section>()
            //    .ReverseMap()
            //    .ForMember(d => d.SectionId, o => o.MapFrom(s => s.ID))
            //    .ForMember(d => d.SectionName, o => o.MapFrom(s => s.SECTION_NAME))
            //    .ForMember(d => d.SectionView, o => o.MapFrom(s => s.SECTION_VIEW));

            //CreateMap<Import, t_web_client_section>()
            //    .ReverseMap()
            //    .ForMember(d => d.ImportBlockId, o => o.MapFrom(s => s.BLOCK_ID))
            //    .ForMember(d => d.ImportName, o => o.MapFrom(s => s.SECTION_NAME))
            //    .ForMember(d => d.ImportView, o => o.MapFrom(s => s.SECTION_VIEW));

            //CreateMap<QueryHistory, t_web_client_query_history>()
            //    .ForMember(d => d.BLOCK_ID, o => o.MapFrom(s => s.QueryHistoryBlockId))
            //    .ForMember(d => d.CLIENT_ID, o => o.MapFrom(s => s.QueryHistoryClientId))
            //    .ForMember(d => d.QUERY_PROCESSED, o => o.MapFrom(s => s.QueryHistoryQueryProcessed))
            //    .ForMember(d => d.QUERY_RECEIVED, o => o.MapFrom(s => s.QueryHistoryQueryReceived))
            //    .ForMember(d => d.QUERY_SENT, o => o.MapFrom(s => s.QueryHistoryQuerySent))
            //    .ForMember(d => d.QUERY_TEXT, o => o.MapFrom(s => Query.Serialize(s.QueryHistoryQuery)))
            //    .ForMember(d => d.QUERY_TEXT_SQL, o => o.MapFrom(s => s.QueryHistoryQueryText))
            //    .ReverseMap()
            //    .ForMember(d => d.QueryHistoryBlockId, o => o.MapFrom(s => s.BLOCK_ID))
            //    .ForMember(d => d.QueryHistoryClientId, o => o.MapFrom(s => s.CLIENT_ID))
            //    .ForMember(d => d.QueryHistoryQueryProcessed, o => o.MapFrom(s => s.QUERY_PROCESSED))
            //    .ForMember(d => d.QueryHistoryQueryReceived, o => o.MapFrom(s => s.QUERY_RECEIVED))
            //    .ForMember(d => d.QueryHistoryQuerySent, o => o.MapFrom(s => s.QUERY_SENT))
            //    .ForMember(d => d.QueryHistoryQueryText, o => o.MapFrom(s => s.QUERY_TEXT_SQL))
            //    .ForMember(d => d.QueryHistoryQuery, o => o.MapFrom(s => Query.Deserialize(s.QUERY_TEXT)));

            //CreateMap<Report, t_web_client_report>()
            //    .ForMember(d => d.ID, o => o.MapFrom(s => s.ReportId))
            //    .ForMember(d => d.REPORT_IS_VISIBLE, o => o.MapFrom(s => s.ReportIsVisible))
            //    .ForMember(d => d.REPORT_NAME, o => o.MapFrom(s => s.ReportName))
            //    .ForMember(d => d.REPORT_TEXT, o => o.MapFrom(s => s.ReportText))
            //    .ReverseMap()
            //    .ForMember(d => d.ReportId, o => o.MapFrom(s => s.ID))
            //    .ForMember(d => d.ReportIsVisible, o => o.MapFrom(s => s.REPORT_IS_VISIBLE))
            //    .ForMember(d => d.ReportName, o => o.MapFrom(s => s.REPORT_NAME))
            //    .ForMember(d => d.ReportText, o => o.MapFrom(s => s.REPORT_TEXT));

            //CreateMap<ReportHistory, t_web_client_report_history>()
            //    .ForMember(d => d.ID, o => o.MapFrom(s => s.ReportHistoryId))
            //    .ForMember(d => d.REPORT_PROCESSED, o => o.MapFrom(s => s.ReportHistoryProcessed))
            //    .ForMember(d => d.REPORT_RECEIVED, o => o.MapFrom(s => s.ReportHistoryReceived))
            //    .ForMember(d => d.REPORT_SENT, o => o.MapFrom(s => s.ReportHistorySent))
            //    .ForMember(d => d.REPORT_TEXT_SQL, o => o.MapFrom(s => s.ReportHistoryText))
            //    .ForMember(d => d.CLIENT_ID, o => o.MapFrom(s => s.ReportHistoryClientId))
            //    .ReverseMap()
            //    .ForMember(d => d.ReportHistoryId, o => o.MapFrom(s => s.ID))
            //    .ForMember(d => d.ReportHistoryProcessed, o => o.MapFrom(s => s.REPORT_PROCESSED))
            //    .ForMember(d => d.ReportHistoryReceived, o => o.MapFrom(s => s.REPORT_RECEIVED))
            //    .ForMember(d => d.ReportHistorySent, o => o.MapFrom(s => s.REPORT_SENT))
            //    .ForMember(d => d.ReportHistoryText, o => o.MapFrom(s => s.REPORT_TEXT_SQL))
            //    .ForMember(d => d.ReportHistoryClientId, o => o.MapFrom(s => s.CLIENT_ID));

            //CreateMap<StoredQuery, t_web_client_query>()
            //    .ForMember(d => d.BLOCK_ID, o => o.MapFrom(s => s.StoredQueryBlockId))
            //    .ForMember(d => d.CLIENT_ID, o => o.MapFrom(s => s.StoredQueryClientId))
            //    .ForMember(d => d.QUERY_NAME, o => o.MapFrom(s => s.StoredQueryName))
            //    .ForMember(d => d.QUERY_TEXT, o => o.MapFrom(s => StoredQuery.Serialize(s.StoredQueryParams)))
            //    .ReverseMap()
            //    .ForMember(d => d.StoredQueryBlockId, o => o.MapFrom(s => s.BLOCK_ID))
            //    .ForMember(d => d.StoredQueryClientId, o => o.MapFrom(s => s.CLIENT_ID))
            //    .ForMember(d => d.StoredQueryName, o => o.MapFrom(s => s.QUERY_NAME))
            //    .ForMember(d => d.StoredQueryParams, o => o.MapFrom(s => StoredQuery.Deserialize(s.QUERY_TEXT)));

            //CreateMap<Stream, t_web_client_stream>()
            //    .ForMember(d => d.STREAM_IS_VISIBLE, o => o.MapFrom(s => s.StreamIsVisible))
            //    .ForMember(d => d.STREAM_NAME, o => o.MapFrom(s => s.StreamName))
            //    .ForMember(d => d.STREAM_TEXT, o => o.MapFrom(s => s.StreamText))
            //    .ForMember(d => d.ID, o => o.MapFrom(s => s.StreamId))
            //    .ReverseMap()
            //    .ForMember(d => d.StreamIsVisible, o => o.MapFrom(s => s.STREAM_IS_VISIBLE))
            //    .ForMember(d => d.StreamName, o => o.MapFrom(s => s.STREAM_NAME))
            //    .ForMember(d => d.StreamText, o => o.MapFrom(s => s.STREAM_TEXT))
            //    .ForMember(d => d.StreamId, o => o.MapFrom(s => s.ID));

            //CreateMap<StreamHistory, t_web_client_stream_history>()
            //    .ForMember(d => d.ID, o => o.MapFrom(s => s.StreamHistoryId))
            //    .ForMember(d => d.STREAM_PROCESSED, o => o.MapFrom(s => s.StreamHistoryProcessed))
            //    .ForMember(d => d.STREAM_RECEIVED, o => o.MapFrom(s => s.StreamHistoryReceived))
            //    .ForMember(d => d.STREAM_SENT, o => o.MapFrom(s => s.StreamHistorySent))
            //    .ForMember(d => d.STREAM_TEXT_SQL, o => o.MapFrom(s => s.StreamHistoryText))
            //    .ForMember(d => d.CLIENT_ID, o => o.MapFrom(s => s.StreamHistoryClientId))
            //    .ReverseMap()
            //    .ForMember(d => d.StreamHistoryId, o => o.MapFrom(s => s.ID))
            //    .ForMember(d => d.StreamHistoryProcessed, o => o.MapFrom(s => s.STREAM_PROCESSED))
            //    .ForMember(d => d.StreamHistoryReceived, o => o.MapFrom(s => s.STREAM_RECEIVED))
            //    .ForMember(d => d.StreamHistorySent, o => o.MapFrom(s => s.STREAM_SENT))
            //    .ForMember(d => d.StreamHistoryText, o => o.MapFrom(s => s.STREAM_TEXT_SQL))
            //    .ForMember(d => d.StreamHistoryClientId, o => o.MapFrom(s => s.CLIENT_ID));


            //CreateMap<User, DAL.Models.User>();
            //CreateMap<Parameter, DAL.Models.Parameter>();

            //CreateMap<Meta, DAL.Models.Meta>();
            //CreateMap<Image, DAL.Models.Image>();
            //CreateMap<Publisher, DAL.Models.Publisher>();

            //CreateMap<Data, DAL.Models.Data>()
            //    .ForMember(d => d.Structure, o => o.Ignore())
            //    .ForMember(d => d.Valid, o => o.MapFrom(src => src.Valid.GetDateTimeFromISO8601()))
            //    .ReverseMap()
            //    .ForMember(d => d.Valid, o => o.MapFrom(src => src.Valid.GetStringISO8601WithoutTime()));
            //CreateMap<ShortData, DAL.Models.Data>()
            //    .ForMember(d => d.Structure, o => o.Ignore())
            //    .ReverseMap()
            //    .ForMember(d => d.Created, o => o.MapFrom(src => src.Created.GetStringISO8601()))
            //    .ForMember(d => d.Valid, o => o.MapFrom(src => src.Valid.GetStringISO8601WithoutTime()))
            //    .ForMember(d => d.Structure, o => o.MapFrom(src => src.Structure.Created.GetStringISO8601())); ;

            //CreateMap<Structure, DAL.Models.Structure>()
            //    .ForMember(d => d.Meta, o => o.Ignore());
            //CreateMap<ShortStructure, DAL.Models.Structure>()
            //    .ForMember(d => d.Meta, o => o.Ignore())
            //    .ReverseMap()
            //    .ForMember(d => d.Created, o => o.MapFrom(src => src.Created.GetStringISO8601()));
        }
    }
}
