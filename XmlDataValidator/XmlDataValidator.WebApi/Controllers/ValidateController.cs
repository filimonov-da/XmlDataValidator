using XmlDataValidator.BLL.Exceptions;
using XmlDataValidator.BLL.Interfaces;
using XmlDataValidator.BLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace XmlDataValidator.WebApi.Controllers
{
    public class ValidateController : ApiController
    {
        private ILoggerService LoggerService;
        private ISchemaValidationService SchemaValidationService;

        public ValidateController(ILoggerService loggerService, ISchemaValidationService schemaValidationService)
        {
            LoggerService = loggerService;
            SchemaValidationService = schemaValidationService;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Validate([FromBody] ValidationRequest validationRequest)
        {
            var validationTask = new Task<IHttpActionResult>(() =>
            {
                try
                {
                    return Ok(SchemaValidationService.Validate(validationRequest));
                }
                catch (BLL.Exceptions.ValidationException ex)
                {
                    LoggerService.Error(ex);

                    return BadRequest(ex.Message);
                }
                catch (SchemaNotFoundException ex)
                {
                    LoggerService.Error(ex);

                    return BadRequest(ex.Message);
                }
                catch (StandardVersionNotSupportedException ex)
                {
                    LoggerService.Error(ex);

                    return BadRequest(ex.Message);
                }
                catch (Base64DecodingException ex)
                {
                    LoggerService.Error(ex);

                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    LoggerService.Error(ex);

                    return InternalServerError(ex);
                }
            });

            validationTask.Start();

            return await validationTask;
        }

        [HttpGet]
        public IHttpActionResult Ping() => Ok();
    }
}
