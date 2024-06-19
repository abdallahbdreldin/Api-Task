using APIs.Day2.CleanCrud.BL;
using APIs.Day2.CleanCrud.DAL;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Day2.CleanCrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IDoctorsManager _doctorsManager;

    public DoctorsController(IDoctorsManager doctorsManager)
    {
        _doctorsManager = doctorsManager;
    }

    [HttpGet]
    public ActionResult<List<DoctorReadDto>> GetAll()
    {
        return _doctorsManager.GetAllForCustomers(); //Ok, 200
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<DoctorReadDetailsDto> GetDetails(int id)
    {
        DoctorReadDetailsDto? doctor = _doctorsManager.GetDetailsById(id);
        if (doctor is null)
            return NotFound();

        return doctor;
    }

    [HttpPost]
    public ActionResult Add(DoctorAddDto doctorDto)
    {
        _doctorsManager.Add(doctorDto);
        return StatusCode(StatusCodes.Status201Created);
    }


    [HttpPut]
    public ActionResult Update(DoctorUpdateDto doctorDto)
    {
        bool result = _doctorsManager.Update(doctorDto);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
