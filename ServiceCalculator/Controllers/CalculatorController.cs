using ServiceCalculator.Controllers.Business;
using ServiceCalculator.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ServiceCalculator.Controllers
{
    /// <summary>
    /// Application controller. Handles browser requests and returns a response.
    /// </summary>
    public class CalculatorController : ApiController
    {
        /// <summary>
        /// Adds two or more operands and retrieve the result
        /// </summary>
        /// <param name="AdditionRequest"></param>
        /// <returns></returns>
        [Route("api/Calculator/Add")]
        [HttpPost]
        public AdditionResult Add([FromBody] AdditionRequest AdditionRequest)
        {
            var headers = this.Request.Headers.ToList();
            string trackingAdd = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBusiness.Add(AdditionRequest, trackingAdd);
        }

        /// <summary>
        /// Sub two operands and retrieve the result.
        /// </summary>
        /// <param name="subRequest"></param>
        /// <returns></returns>
        [Route("api/Calculator/Sub")]
        [HttpPost]
        public SubtractionResult Sub([FromBody] SubtractionRequest subRequest)
        {
            var headers = this.Request.Headers.ToList();
            string trackingSub = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBusiness.Sub(subRequest, trackingSub);
        }

        /// <summary>
        /// Multiply two or more operands and retrieve the result.
        /// </summary>
        /// <param name="multRequest"></param>
        /// <returns></returns>
        [Route("api/Calculator/Mult")]
        [HttpPost]
        public MultiplicationResult Mult([FromBody] MultiplicationRequest multRequest)
        {
            var headers = this.Request.Headers.ToList();
            string trackingMult = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBusiness.Mult(multRequest, trackingMult);
        }

        /// <summary>
        /// Divide two operands and retrieve the result.
        /// </summary>
        /// <param name="divtRequest"></param>
        /// <returns></returns>
        [Route("api/Calculator/Div")]
        [HttpPost]
        public DivisionResult Div([FromBody] DivisionRequest divtRequest)
        {
            var headers = this.Request.Headers.ToList();
            string trackingDiv = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBusiness.Div(divtRequest, trackingDiv);
        }

        /// <summary>
        /// Square root a number and retrieve the result.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [Route("api/Calculator/Sqrt")]
        [HttpPost]
        public SqrtResult Sqrt([FromBody] SqrtRequest sqrtRequest)
        {
            var headers = this.Request.Headers.ToList();
            string trackingSqrt = headers[headers.Count - 1].Value.First().ToString();
            return CalculatorBusiness.Sqrt(sqrtRequest, trackingSqrt);
        }

        /// <summary>
        /// Request all operations for a TrackingId  since the last application restart.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Calculator/Query")]
        [HttpPost]
        public List<Operations> Query([FromBody] string id)
        {
            return CalculatorBusiness.Query(id);
        }
    }
}