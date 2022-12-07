using AutoMapper;
using Vacancy.Core;
using Vacancy.Repository.Dto;
using Vacancy.Repository.Dto.EducationDto;
using Vacancy.Repository.Dto.ExperienceDto;
using Vacancy.Repository.Dto.ResumeDto;
using Vacancy.Repository.Dto.SkillDto;

namespace Vacancy.Mapper
{   
        public class AppAutoMapper : Profile
        {
            public AppAutoMapper()
            {
            CreateMap<ResumeDto, Resume>();
            CreateMap<Resume, ResumeDto>();

            CreateMap<EducationDto, Education>();
            CreateMap<Education, EducationDto>();

            CreateMap<SkillDto, Skill>();
            CreateMap<Skill, SkillDto>();

            CreateMap<ExperienceDto, Experience>();
            CreateMap<Experience, ExperienceDto>();
            }
        }
}
