using App5LP.Models;
using App5LP.Repository;
using App5LP.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace App5LP.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            return View(_clienteRepository.ObterTodosClientes());
        }
        [HttpGet]
        public IActionResult CadastrarCliente()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteRepository.Cadastrar(cliente);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AtualizarCliente(int id)
        {
            return View(_clienteRepository.ObterCliente(id));
        }
        [HttpPost]
        public IActionResult AtualizarCliente(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult DetalhesCliente(int id)
        {
            return View(_clienteRepository.ObterCliente(id));
        }
        [HttpPost]
        public IActionResult DetalhesCliente(Cliente cliente)
        {
            _clienteRepository.Atualizar(cliente);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult ExcluirCliente(int id)
        {
            _clienteRepository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
