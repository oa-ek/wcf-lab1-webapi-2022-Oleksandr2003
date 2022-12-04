using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Core;
using Vacancy.Repository.Dto.ExperienceDto;
using Vacancy.Repository.Repositories;

namespace VacancyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceApiController : ControllerBase
    {
        private readonly ExperienceRepositories experienceApiRepositories;
        private readonly ILogger<ExperienceApiController> _logger;
        public ExperienceApiController(ILogger<ExperienceApiController> logger, ExperienceRepositories experienceApiRepositories)
        {
            _logger = logger;
            this.experienceApiRepositories = experienceApiRepositories;
        }
        [HttpGet]
        public ExperienceRepositories GetExperienceRepositories()
        {
            return experienceApiRepositories;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetExperienceListAsync")]
        public async Task<IEnumerable<ExperienceDto>> GetListAsync()
        {
            return await experienceApiRepositories.GetListAsync();
        }
        [HttpPost]
        public async Task<Experience> Create(ExperienceCreateDto experienceDto)
        {
            var createdExperience = await experienceApiRepositories.AddExperienceByDtoAsync(experienceDto);
            return createdExperience;
        }
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await experienceApiRepositories.DeleteExperienceAsync(id);
        }

        [HttpPut]
        public async Task Edit(ExperienceCreateDto exp)
        {
            await experienceApiRepositories.UpdateExperienceAsync(exp);
        }
    }
}
