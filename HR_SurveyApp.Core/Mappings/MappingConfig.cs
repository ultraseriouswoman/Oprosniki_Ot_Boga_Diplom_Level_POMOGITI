using AutoMapper;
using HR_SurveyApp.Core.DTO;
using HR_SurveyApp.Domain.Entities;

namespace HR_SurveyApp.Core.Mappings
{
    public class MappingConfig : Profile
    {
        private readonly string SurveyPath = "https://localhost:7002/"; // TODO: Для стабильной работы изменить в конфигурации
        private readonly string SurveyStatisticsPath = "https://localhost:7002/statistics/";
        public MappingConfig()
        {
            CreateMap<SurveyCreateRequest, Survey>();
            CreateMap<Survey, SurveyReplaceRequest>().ReverseMap();
            CreateMap<Survey, SurveyResponse>()
                .ForMember(dest => dest.ParticipantUrl, opt => opt.MapFrom(src => SurveyPath + src.Id.ToString()))
                .ForMember(dest => dest.StatisticsUrl, opt => opt.MapFrom(src => SurveyStatisticsPath + src.Id.ToString()));

            CreateMap<QuestionCreateRequest, Question>();
            CreateMap<Question, QuestionReplaceRequest>().ReverseMap();
            CreateMap<Question, QuestionResponse>();

            CreateMap<ChoiceCreateRequest, Choice>();
            CreateMap<Choice, ChoiceResponse>();

            CreateMap<SubmissionCreateRequest, Submission>();
            CreateMap<Submission, SubmissionResponse>();

            CreateMap<AnswerCreateRequest,Answer>();
            CreateMap<Answer, AnswerResponse>();
        }
    }
}
