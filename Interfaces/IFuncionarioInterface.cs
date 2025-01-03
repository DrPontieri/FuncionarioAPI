using FuncionarioAPI.Model;

namespace FuncionarioAPI.Interfaces
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionariosAtivos();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novofuncionario);
        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);
        Task<ServiceResponse<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadofuncionario);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id);
        Task<ServiceResponse<List<FuncionarioModel>>> DeleteLogicoFuncionario(int id);
        Task<ServiceResponse<FuncionarioModel>> InativaFuncioario(int id);
        Task<ServiceResponse<FuncionarioModel>> AtivaFuncioario(int id);
    }
}
