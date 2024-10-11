using App5LP.Models;
using App5LP.Repository.Contract;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System.Data;

namespace App5LP.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySQL;

        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update cliente set nomeCli = @nomeCli, email=@email, CPF=@CPF," +
                                                    "telefone=@telefone Where IdCli=@IdCli", conexao);

                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.email;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cliente.telefone;
                cmd.Parameters.Add("@IdCli", MySqlDbType.VarChar).Value = cliente.idCli;


                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into cliente(nomeCli, email, CPF, telefone ) " +
                                                    "values (@nomeCli, @email, @CPF, @telefone)", conexao);
                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cliente.email;
                cmd.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = cliente.CPF;
                cmd.Parameters.Add("@telefone", MySqlDbType.VarChar).Value = cliente.telefone;

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from cliente where IdCli=@IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            List<Cliente> ClienteList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from cliente", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    ClienteList.Add(
                        new Cliente
                        {
                            idCli = Convert.ToInt32(dr["IdCli"]),
                            nomeCli = (string)dr["nomeCli"],
                            email = (string)dr["email"],
                            CPF = (string)dr["CPF"],
                            telefone = (string)dr["telefone"]
                        });
                }
                return ClienteList;
            }
        }

        public Cliente ObterCliente(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from cliente " +
                                                    "where IdCli = @IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.idCli = Convert.ToInt32(dr["IdCli"]);
                    cliente.nomeCli = (string)(dr["nomeCli"]);
                    cliente.email = (string)dr["email"];
                    cliente.CPF = (string)dr["CPF"];
                    cliente.telefone = (string)dr["telefone"];
                }
                return cliente;
            }
        }
    }
}
