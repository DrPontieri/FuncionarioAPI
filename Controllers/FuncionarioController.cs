using FuncionarioAPI.Interfaces;
using FuncionarioAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            return Ok(await _funcionarioInterface.GetFuncionarioById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            return Ok(await _funcionarioInterface.UpdateFuncionario(editadoFuncionario));
        }

        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> InativaFuncioario(int id)
        {
            return Ok(await _funcionarioInterface.InativaFuncioario(id));
        }

        [HttpPut("ativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> AtivaFuncioario(int id)
        {
            return Ok(await _funcionarioInterface.AtivaFuncioario(id));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        { 
            return Ok( await _funcionarioInterface.DeleteFuncionario(id));
        }

        [HttpDelete("deleteLogico")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteLogicoFuncionario(int id)
        {
            return Ok(await _funcionarioInterface.DeleteLogicoFuncionario(id));
        }

        [HttpGet("funcionarioAtivo")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionariosAtivos()
        {
            return Ok(await _funcionarioInterface.GetFuncionariosAtivos());
        }
    }
}
