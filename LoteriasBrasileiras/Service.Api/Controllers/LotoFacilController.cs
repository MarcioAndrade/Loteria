using Application.Interfaces;
using Domain.LotoFacil;
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
        public IList<LotoFacilCEF> Get()
        {
            return _appService.ObterTodos();
        }

        // GET: api/LotoFacil/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LotoFacil
        [HttpPost]
        public int Post()
        {
            return _appService.Importar();
        }

        //[HttpPost]
        //public void Importar(string sorteio)
        //{
        //    var ultimoSorteio = _appService.ImportarArquivo(0);
        //}

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
