using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceLink.Core.DbSet;
using ServiceLink.Core.Dto.Requests;
using ServiceLink.Core.Dto.Responses;
using ServiceLink.EF.Interfaces;

namespace ServiceLinkApi.Controllers;

public class AchivementController : BaseController
{
    public AchivementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {

    }



    [HttpGet]
    [Route("{driverId:guid}")]
    public async Task<IActionResult> GetDriverAchievements(Guid id)
    {
        var driverAchievement = await _unitOfWork.Achievement.GetDriverAchievementsAsync(id);
        if(driverAchievement == null) return NotFound();

        var result = _mapper.Map<DriveAchivementResponce>(driverAchievement);
        return Ok(result);
    }

    [HttpPost("")]
    public async Task<IActionResult> AddAchievement([FromBody] CreateDriveAchivementRequest achivement){

        if(!ModelState.IsValid) return BadRequest(ModelState);

        var Driver = await _unitOfWork.Driver.GetbyID(achivement.DriverId);
        if(Driver == null) return NotFound("No Driver");

        var _achievement = _mapper.Map<Achievement>(achivement);
        
        await _unitOfWork.Achievement.Add(_achievement);
        await _unitOfWork.CompletedAsync();
        
        return CreatedAtAction(nameof(GetDriverAchievements),new {driverId = _achievement.DriverID} , _achievement);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> UpdateAchievement([FromRoute] Guid id , [FromBody] UpdateDriveAchivementRequest achivement){

        if(!ModelState.IsValid) return BadRequest(ModelState);        

        var _achievement = _mapper.Map<Achievement>(achivement);

        await _unitOfWork.Achievement.Update(_achievement);
        await _unitOfWork.CompletedAsync();
        
        return NoContent();
    }
}
