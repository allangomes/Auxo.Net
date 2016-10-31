using System.Net;
using System.Threading.Tasks;
using Auxo.Business;
using Auxo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Auxo.Api.Controllers
{
    [Route("[controller]")]
    public class CrudController<T>
        where T : Entity
    {
        private readonly ICrudService<T> _service;
        public CrudController(ICrudService<T> service)
        {
            _service = service;
        }
        protected virtual async Task<IActionResult> Get(HttpStatusCode status, string key)
        {
            var data = await _service[key];
            return Result.Factory(status, data);
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get() 
        {
            var data = await _service.Query().FetchAsync();
            return Result.Factory(HttpStatusCode.OK, data);
        }

        [HttpGet("{key}")]
        public virtual async Task<IActionResult> Get(string key) => await Get(HttpStatusCode.OK, key);

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object obj)
        {
            var model = _service.New();
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(obj), model);
            _service.Insert(model);
            return await Get(HttpStatusCode.Created, model.Id.ToString());
        }

        [HttpPut("{key}")]
        public virtual async Task<IActionResult> Put(string key, [FromBody] object obj)
        {
            var model = await _service[key];
            JsonConvert.PopulateObject(JsonConvert.SerializeObject(obj), model);
            _service.Update(model);
            return await Get(HttpStatusCode.OK, model.Id.ToString());
        }

        [HttpDelete("{key}")]
        public virtual async Task<IActionResult> Delete(string key)
        {
            var model = await _service[key];
            _service.Delete(model);
            return Result.Factory();
        }
    }
}