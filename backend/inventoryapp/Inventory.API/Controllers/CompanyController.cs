using Inventory.Application.Services;
using Inventory.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {

        private readonly CompanyService _service;

        public CompanyController(
            CompanyService service
        )
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(
                await _service.GetAllAsync()
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(
            int id
        )
        {

            var data =
                await _service.GetByIdAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);

        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany()
        {

            var form = Request.Form;

            var logo =
                form.Files["CompanyLogo"];

            var company = new Company
            {

                CompanyName =
                    form["CompanyName"],

                CompanyCode =
                    form["CompanyCode"],

                CompanyEmail =
                    form["CompanyEmail"],

                CompanyPhone =
                    form["CompanyPhone"],

                BusinessType =
                    form["BusinessType"],

                CompanyDescription =
                    form["CompanyDescription"],

                Address1 =
                    form["Address1"],

                Address2 =
                    form["Address2"],

                Country =
                    form["Country"],

                State =
                    form["State"],

                City =
                    form["City"],

                PostalCode =
                    form["PostalCode"],

                SubscriptionPlan =
                    form["SubscriptionPlan"],

                UserLimit =
                    Convert.ToInt32(
                        form["UserLimit"]
                    )

            };

            var result =
                await _service.CreateCompanyAsync(
                    company,
                    logo
                );

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Company company
        )
        {

            company.Id = id;

            return Ok(
                await _service.UpdateAsync(
                    company
                )
            );

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            int id
        )
        {

            return Ok(
                await _service.DeleteAsync(id)
            );

        }

    }
}