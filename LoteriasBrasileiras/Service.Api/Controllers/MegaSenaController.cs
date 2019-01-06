using Application.ViewModel;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Service.Api.Controllers
{
    [Route("api/megaSena")]
    [ApiController]
    public class MegaSenaController : ControllerBase
    {
        private readonly IMegaSenaAppService _appService;

        public MegaSenaController(IMegaSenaAppService appService)
        {
            _appService = appService;
        }

        // GET: api/MegaSena
        [HttpGet]
        public IEnumerable<MegaSenaViewModel> Obter()
        {
            return _appService.ObterTodos();
        }

        // GET: api/MegaSena/5
        [HttpGet("{idConcurso}", Name = "Obter")]
        public MegaSenaViewModel Obter(int idConcurso)
        {
            return _appService.Obter(idConcurso);
        }

        // POST: api/MegaSena
        [HttpPost]
        public string Post()
        {
            return _appService.Importar();
        }

        // PUT: api/MegaSena/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
