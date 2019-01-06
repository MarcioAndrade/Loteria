using Application.ViewModel;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Service.Api.Controllers
{
    [Route("api/lotoFacil")]
    [ApiController]
    public class LotoFacilController : ControllerBase
    {
        private readonly ILotoFacilAppService _appService;

        public LotoFacilController(ILotoFacilAppService appService)
        {
            _appService = appService;
        }

        // GET: api/LotoFacil
        [HttpGet]
        public IList<LotoFacilViewModel> Obter()
        {
            return _appService.ObterTodos();
        }

        // GET: api/LotoFacil/5
        [HttpGet("{concurso}", Name = "Get")]
        public LotoFacilViewModel Obter(int concurso)
        {
            return _appService.Obter(concurso);
        }

        // POST: api/LotoFacil
        [HttpPost]
        public string AtualizarCadastro()
        {
            return _appService.Importar();
        }


        // PUT: api/LotoFacil/5
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
