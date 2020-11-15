using System.Threading.Tasks;
using AppPDFReport.Models;
using Microsoft.AspNetCore.Mvc;
using Wkhtmltopdf.NetCore;

namespace AppPDFReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IGeneratePdf _generatePdf;

        public HomeController(IGeneratePdf generatePdf)
        {
            _generatePdf = generatePdf;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetEmployeeInfo() 
        {
            var empObj = new EmployeeInfo
            {
                EmpId = "1001",
                EmpName = "Mr. Robert",
                Departament = "IT",
                Designation = "Software Engineer"
            };

            return await _generatePdf.GetPdf("Views/Employee/EmployeeInfo.cshtml", empObj);
        }
    }
}