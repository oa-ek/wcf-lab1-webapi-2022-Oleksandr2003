using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacancy.Core;
using Vacancy.Repository.Dto.ExperienceDto;

namespace Vacancy.Repository.Repositories
{
    public class ExperienceRepositories
    {
        private readonly VacancyDbContext _ctx;
        private readonly IMapper _mapper;
        public ExperienceRepositories(VacancyDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExperienceDto>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<ExperienceDto>>(await _ctx.Experiences.ToListAsync());
        }
        public async Task<Experience> AddExperienceAsync(Experience type)
        {
            _ctx.Experiences.Add(type);
            await _ctx.SaveChangesAsync();
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceName == type.ExperienceName);
        }

        public List<Experience> GetExperiences()
        {
            var typeList = _ctx.Experiences.ToList();
            return typeList;
        }
        public async Task<Experience> AddExperienceByDtoAsync(ExperienceCreateDto experienceDto)
        {
            var experience = new Experience();
            experience.ExperienceName = experienceDto.ExperienceName;
            _ctx.Experiences.Add(experience);
            await _ctx.SaveChangesAsync();
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceName == experience.ExperienceName);
        }
        public Experience GetExperience(int id)
        {
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceId == id);
        }

        public Experience GetExperienceByName(string name)
        {
            return _ctx.Experiences.FirstOrDefault(x => x.ExperienceName == name);
        }

        public async Task DeleteExperienceAsync(int id)
        {
            _ctx.Remove(GetExperience(id));
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateExperienceAsync(ExperienceCreateDto updatedExperience)
        {
            var experience = _ctx.Experiences.FirstOrDefault(x => x.ExperienceId == updatedExperience.ExperienceId);
            experience.ExperienceName = updatedExperience.ExperienceName;
            await _ctx.SaveChangesAsync();
        }
    }
}
