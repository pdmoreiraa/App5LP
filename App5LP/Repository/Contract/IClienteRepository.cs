using App5LP.Models;

namespace App5LP.Repository.Contract
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> ObterTodosClientes();

        void Cadastrar(Cliente cliente);
        void Atualizar(Cliente cliente);

        Cliente ObterCliente(int id);
        void Excluir(int id);
    }
}
