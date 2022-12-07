using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vacancy.Core;
using Vacancy.Repository.Dto.ResumeDto;
using Vacancy.Repository.Repositories;

namespace VacancyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeApiController : ControllerBase
    {
        private readonly ResumeRepositories resumeApiRepositories;
        private readonly ILogger<ResumeApiController> _logger;
        public ResumeApiController(ILogger<ResumeApiController> logger, ResumeRepositories resumeApiRepositories)
        {
            _logger = logger;
            this.resumeApiRepositories = resumeApiRepositories;
        }
        [HttpGet]
        public ResumeRepositories GetResumeRepositories()
        {
            return resumeApiRepositories;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetResumeListAsync")]
        public async Task<IEnumerable<ResumeDto>> GetListAsync()
        {
            return await resumeApiRepositories.GetListAsync();
        }        
    }
}
