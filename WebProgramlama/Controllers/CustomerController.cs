using Microsoft.AspNetCore.Mvc;
using WebProgramlama.DBHelpers;
using WebProgramlama.EfCore;
using WebProgramlama.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProgramlama.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerHelper _dbHelper;

        public CustomerController(EF_DataContext eF_DataContext)
        {
            _dbHelper = new CustomerHelper(eF_DataContext);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("api/[controller]/GetCustomers")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<CustomerModel> data = _dbHelper.GetAll();
                if(!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type , data));
            }
            catch(Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet]
        [Route("api/[controller]/GetById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                CustomerModel customerModel =  _dbHelper.getCustomerById(id);
                if(customerModel == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type , customerModel));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        [Route("api/[controller]/SaveCustomer")]
        public IActionResult Post([FromBody] CustomerModel value)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _dbHelper.makeRecord(value);
                return Ok(ResponseHandler.GetAppResponse(type, value));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateCustomer")]
        public IActionResult Put([FromBody] CustomerModel value)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _dbHelper.makeRecord(value);
                return Ok(ResponseHandler.GetAppResponse(type, value));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteCustomer{id}")]
        public IActionResult Delete(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                bool result = _dbHelper.DeleteRecord(id);
                if (!result)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, null));
            }
            catch(Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
