using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLink.Core.DbSet;
using ServiceLink.Core.Dto.Requests;
using ServiceLink.Core.Dto.Responses;
using ServiceLink.EF.Interfaces;

namespace ServiceLinkApi.Controllers;

public class DriveController : BaseController
{
    public DriveController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetAllDriver(){
        
        var Drivers = await _unitOfWork.Driver.All();
        var DriversDto = _mapper.Map<IEnumerable<GetDriveResponce>>(Drivers);
        return Ok(DriversDto);

    }

    [HttpGet]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> GetDriverByID([FromRoute] Guid driverId){

        var driver = await _unitOfWork.Driver.GetbyID(driverId);

        if(driver == null) 
            return NotFound();

        var _Driver = _mapper.Map<GetDriveResponce>(driver);

        return Ok(_Driver);

    }

    [HttpPost("")]
    public async Task<IActionResult> AddDriver([FromBody] CreatedDriverRequest driver)
    {

        if(!ModelState.IsValid) return BadRequest(ModelState);

        var createdDriver = _mapper.Map<Driver>(driver);

        await _unitOfWork.Driver.Add(createdDriver);
        await _unitOfWork.CompletedAsync();

        return CreatedAtAction(nameof(GetDriverByID), new { driverId = createdDriver.Id },createdDriver);

    }

    [HttpPut]
    public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest updateDriver){

        if(!ModelState.IsValid) return BadRequest(ModelState);

        var Result= _mapper.Map<Driver>(UpdateDriver);

        await _unitOfWork.Driver.Update(Result);
        await _unitOfWork.CompletedAsync();
        return NoContent();
    }

    [HttpDelete]
    [Route("{driverId:Guid}")]
    public async Task<IActionResult> DeleteDriver([FromRoute] Guid driverID)
    {
        var driver = await _unitOfWork.Driver.GetbyID(driverID);

        if(driver == null) NotFound("User is Not Found");

        var deletedDriver = await _unitOfWork.Driver.Delete(driverID);
        if(!deletedDriver) return BadRequest("Can't delete");
        
        return NoContent();
    
    }
}
