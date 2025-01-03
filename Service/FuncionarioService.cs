using System.Collections.Generic;
using FuncionarioAPI.DataContext;
using FuncionarioAPI.Interfaces;
using FuncionarioAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioAPI.Service
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly FuncionarioDbContext _context;    
        public FuncionarioService(FuncionarioDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<FuncionarioModel>> AtivaFuncioario(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel? funcionario = _context.Funcionario.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.Ativo = true;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionario.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionario.FirstOrDefault(x => x.Id == id);

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novofuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (novofuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novofuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionario.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                var funcionario = await _context.Funcionario.FirstOrDefaultAsync(b => b.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Funcionario.Remove(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Funcionario.ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteLogicoFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try 
            {
                var funcionario = await _context.Funcionario.FirstOrDefaultAsync(b => b.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.Ativo = false;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                await _context.SaveChangesAsync();

                serviceResponse.Dados = await _context.Funcionario.Where(x => x.Ativo != false).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                var funcionario = await _context.Funcionario.FirstOrDefaultAsync(b => b.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                serviceResponse.Dados = funcionario;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }            
            
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                serviceResponse.Dados = await _context.Funcionario.ToListAsync();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionariosAtivos()
        {

            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try 
            {
                serviceResponse.Dados = await _context.Funcionario.Where(x => x.Ativo != false).ToListAsync();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }
            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> InativaFuncioario(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try 
            { 
                FuncionarioModel? funcionario = _context.Funcionario.FirstOrDefault(x  => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                funcionario.Ativo = false;
                funcionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionario.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionario.FirstOrDefault(x => x.Id == id);

                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editadofuncionario)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel? funcionario = _context.Funcionario.AsNoTracking().FirstOrDefault(x => x.Id == editadofuncionario.Id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                editadofuncionario.DataCriacao = funcionario.DataCriacao;
                editadofuncionario.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionario.Update(editadofuncionario);
                await _context.SaveChangesAsync();
                
                serviceResponse.Dados = _context.Funcionario.FirstOrDefault(x => x.Id == funcionario.Id);

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        
        }
    }
}
