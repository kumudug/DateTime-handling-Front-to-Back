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
        [ResponseType(typeof(DataPocAsIsViewModel))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var retObj = await _pocContext.DataPocs.FindAsync(id);
            if (retObj != null)
            {
                return Ok(retObj);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [ResponseType(typeof(DataPocAsIsViewModel))]
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

                #region DataManipulationPart-Not a concern in 
                //DataManipulationPart-Not a concern in POC
                _pocContext.Set<DataPoc>().Add(dataPocDomVar);

                var retVal = await _pocContext.SaveChangesAsync();

                if (retVal > 0)
                {
                    var returnVm = new DataPocAsIsViewModel()
                    {
                        Id = dataPocDomVar.Id,
                        StoredDateTimeOffset = dataPocDomVar.StoredDateTimeOffset,
                        StoredDateTimeUTC = dataPocDomVar.StoredDateTimeUTC
                    };
                    return Created($"put get url/{dataPocDomVar.Id}", returnVm);
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
