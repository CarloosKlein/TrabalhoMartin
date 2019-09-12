using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TrabalhoPCMenu
{
    class Program
    {


        static void Main(string[] args)
        {
            Boolean continua = true;
            List<Pessoa> listaPessoas;
            listaPessoas = new List<Pessoa>();

            do
            {

                Console.WriteLine("---------------------------");
                Console.WriteLine("Menu de Cadastro");
                Console.WriteLine("01 - Incluir");
                Console.WriteLine("02 - Alterar");
                Console.WriteLine("03 - Excluir");
                Console.WriteLine("04 - Listar");
                Console.WriteLine("05 - Pesquisar");
                Console.WriteLine("06 - Limpar");
                Console.WriteLine("09 - Sair");
                Console.WriteLine("---------------------------");
                Console.WriteLine("Digite sua opção desejada: ");
                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "01": //Incluir
                        listaPessoas.Add(incluirPessoa());
                        break;

                    case "02": //Editar

                        Console.WriteLine("Informe o ID do usuario em que deseja alterar: ");

                        int searchId = int.Parse(Console.ReadLine()); //Variavel recebendo o valor de ID 
                        Pessoa buscaID = listaPessoas.Find(x => x.Id == searchId); //.Find - buscando o ID na listaPessoas

                        Console.WriteLine("O que deseja alterar: ");
                        Console.WriteLine(" 01 - Nome");
                        Console.WriteLine(" 02 - Salario");

                        string opcAlterar = Console.ReadLine();

                        switch (opcAlterar)
                        {
                            case "01": //Nome                               
                                if (buscaID != null)
                                {
                                    Console.WriteLine();
                                    Console.Write("Digite o novo Nome: ");
                                    string textoNovo = Console.ReadLine(); //Variavel pra receber o texto
                                    buscaID.alteraNome(textoNovo); //Buscando o parametro da classe e inserir o novo Texto(Nome)
                                }
                                break;

                            case "02": //Salario
                                if (buscaID != null)
                                {
                                    Console.WriteLine();
                                    Console.Write("Digite a porcentagem que deseja aumentar: ");
                                    double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); //Recebe valor digitando e fazendo a conversão
                                    buscaID.PercentualSalario(porcentagem); //Buscando o parametro do calculo da porcentagem
                                }
                                else
                                {
                                    Console.WriteLine("Dados Invalidos");
                                }
                                break;
                        }

                        Console.WriteLine();
                        Console.WriteLine("Dados Atualizados com sucesso: ");
                        foreach (var cadastro in listaPessoas)
                        {
                            Console.WriteLine(cadastro);
                        }

                        break;

                    case "03": //Remover
                        Console.WriteLine("Excluir Dados");
                        foreach (var cadastro in listaPessoas)
                        {
                            Console.WriteLine(cadastro);
                        }

                        Console.WriteLine("Informe o ID do usuario em que deseja excluir: ");
                        int searchUsuario = int.Parse(Console.ReadLine()); //Variavel para receber o ID digitado 
                        Pessoa buscaIDUsuario = listaPessoas.Find(x => x.Id == searchUsuario); //Variavel usada para receber o ID digitado e pesquisar atraves do .Find na lista
                        if (buscaIDUsuario != null) //Se o valor recebido for diferente de Nulo(Nada)
                        {
                            listaPessoas.Remove(new Pessoa() { Id = searchUsuario }); //Remover as informações do ID encontrado
                            Console.WriteLine("Dados Atualizados:");
                            foreach (var cadastro in listaPessoas) //Para item do ID encontrado em listaPessoas
                            {
                                Console.WriteLine(cadastro);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Id do produto não existente!!");
                        }
                        break;

                    case "04": //Listar Usuarios Cadastrados
                        Console.WriteLine("Lista Ordenada por Id");
                        listaPessoas.Sort(delegate (Pessoa p1, Pessoa p2) //Sort = Ordenar
                        {
                            return p1.Id.CompareTo(p2.Id); //Comparação entre dois parametros
                        });
                        listaPessoas.ForEach(delegate (Pessoa p) //Para cada item na lista Pessoas - faça uma referencia
                        {
                            Console.WriteLine(String.Format("{0}|{1}|{2}", p.Id, p.Nome, p.Salario));
                        });
                        break;

                    case "05": //Pesquisa
                        Console.WriteLine();
                        Console.WriteLine("Pesquisar");

                        Console.Write("Localize pelo Nome: ");
                        string filtro = Console.ReadLine(); //Recebendo o texto(nome)                         
                        Pessoa localizar = listaPessoas.Find(x => x.Nome == filtro); //Localizando na list atraves do campo digitado
                        if (localizar != null)
                        {
                            Console.WriteLine("\nLocalizado: " + localizar);
                        }
                        else
                        {
                            Console.WriteLine("Nome não existente!!");
                        }
                        break;

                    case "06": //Limpar Conteúdo
                        Console.Clear();
                        break;

                    case "09": //Sair
                        Console.WriteLine("Aplicação Encerrada");
                        Thread.Sleep(2000); //Tempo em miliSegundos
                        Environment.Exit(1);
                        //System.Diagnostics.Process.GetCurrentProcess().Close();
                        continua = false;
                        break;


                    default:
                        Console.WriteLine("Opção invalida ou não existente");
                        break;
                }

            } while (continua);


        }

        private static Pessoa incluirPessoa()
        {

            Pessoa pessoa = new Pessoa();

            Console.WriteLine("---------------------------");
            Console.WriteLine("Cadastro de Pessoa");
            Console.WriteLine("ID: ");
            pessoa.Id = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Nome: ");
            pessoa.Nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Salario: ");
            pessoa.Salario = double.Parse(Console.ReadLine());


            return pessoa;
        }

    }
}