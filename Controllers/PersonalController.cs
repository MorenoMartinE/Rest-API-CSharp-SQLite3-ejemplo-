using Microsoft.AspNetCore.Mvc;
using apiRest.Services;
using apiRest.Models;


namespace apiRest.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonalController : ControllerBase {


    PersonalService _service;

    public PersonalController(PersonalService service){
        _service = service;
    }

    [HttpGet("/personal")]
    public IEnumerable<Personal> GetAll(){
        return _service.GetAll();
    } 

    [HttpGet("/personal/{Usr_id}")]
    public ActionResult<Personal> Get(int Usr_id) {
        var personal = _service.Get(Usr_id);

        if(personal != null){
            return personal;
        }else{
            return NotFound();
        }
    }

    [HttpPost("/personal/add")]
    public IActionResult Create(Personal personal){
        _service.Create(personal);
        
        return CreatedAtAction(nameof(Create), new {Usr_id = personal.Usr_id}, personal);
    }

    [HttpPut("/personal/upgrade/{Usr_id}")]
    public IActionResult Update(int Usr_id, Personal personal){

        if(Usr_id != personal.Usr_id){
            return BadRequest();
        }

        var existinPersonal = _service.Get(Usr_id);
        if(existinPersonal == null){
            return NotFound();
        }

        _service.Update(personal);


        return NoContent();
    }

    [HttpDelete("/personal/delete/{Usr_id}")]
    public IActionResult Delete(int Usr_id){
        
        var personal = _service.Get(Usr_id);

        if(personal == null){
            return NotFound();
        }else{
            _service.Delete(Usr_id);
        }

        return NoContent();
    }


}