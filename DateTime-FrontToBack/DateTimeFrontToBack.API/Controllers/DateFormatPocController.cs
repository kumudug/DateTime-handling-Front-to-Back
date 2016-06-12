using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DateTimeFrontToBack.API.Data.Context;
using DateTimeFrontToBack.API.Data.Entities;
using DateTimeFrontToBack.API.Data.ViewModels;

namespace DateTimeFrontToBack.API.Controllers
{
    [RoutePrefix("api/poc")]
    public class DateFormatPocController : ApiController
    {
        //using context directly for data manipulations due to being POC
        private readonly PocContext _pocContext;

        public DateFormatPocController()
        {
            //Not using DI due to POC
            _pocContext = new PocContext();
        }

        [HttpGet]
        [Route("byid/{id:int}")]
        public async Task<IHttpActionResult> GetUserById(int id)
        {
            Console.WriteLine("abcd");
            return Ok();
        }

        [HttpPut]
        [ResponseType(typeof(DataPocViewModel))]
        [Route("put")]
        public async Task<IHttpActionResult> Put(DataPocViewModel dataPoc)
        {
            if (ModelState.IsValid)
            {
                var dataPocDomVar = new DataPoc()
                {
                    StoredDateTimeUTC = dataPoc.StoredDateTime.ToUniversalTime(),
                    StoredDateTimeOffset = dataPoc.StoredDateTime
                };

                #region DataManipulationPart-Not a concern in POC
                _pocContext.Set<DataPoc>().Add(dataPocDomVar);

                var retVal = await _pocContext.SaveChangesAsync();

                if (retVal > 0)
                {
                    dataPoc.Id = dataPocDomVar.Id;
                    return Created($"put get url/{dataPocDomVar.Id}", dataPoc);
                }
                else
                {
                    return InternalServerError();
                }
                #endregion
            }
            return BadRequest();
        }
    }
}
