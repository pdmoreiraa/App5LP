using App5LP.Models;

namespace App5LP.Repository.Contract
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> ObterTodosUsuarios();

        void Cadastrar(Usuario usuario);
        void Atualizar(Usuario usuario);

        Usuario ObterUsuario(int id);
        void Excluir(int id);
    }
}
