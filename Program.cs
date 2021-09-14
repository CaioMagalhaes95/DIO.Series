using System;


namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "x")
            {
                switch (opcaousuario)
                {
                    case "1":
                        ListaSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaousuario = ObterOpcaoUsuario();
            }
            
        }


        private static void ListaSerie()
        {
            Console.WriteLine("Listar Series: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                
                    Console.WriteLine("#ID {0}-{1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "* Exlcuido *" : ""));

               
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir Serie");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima: ");
            int entragenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entratitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento: ");
            int entraint = int.Parse(Console.ReadLine());

            Console.Write("Digite Descricao da serie: ");
            string entraDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.ProximoId(), genero: (Genero) entragenero, 
                titulo: entratitulo, ano: entraint, descricao: entraDescricao);


            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da Serie: ");
            int Indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o Genero entre as opções acima: ");
            int entragenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Serie: ");
            string entratitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Lançamento: ");
            int entraint = int.Parse(Console.ReadLine());

            Console.Write("Digite Descricao da serie: ");
            string entraDescricao = Console.ReadLine();

            Series Atualizaserie = new Series(id: Indice, genero: (Genero)entragenero,
                titulo: entratitulo, ano: entraint, descricao: entraDescricao);


            repositorio.Atualiza(Indice, Atualizaserie);

        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o Id para excluir a serie: ");
            int Indice = int.Parse(Console.ReadLine());

            repositorio.Exclui(Indice);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id para visualizar a serie: ");
            int Indice = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(Indice);

            Console.WriteLine(serie);
        }




        private static string ObterOpcaoUsuario()
            {
            Console.WriteLine();
            Console.WriteLine("Olá");
            Console.WriteLine("Informe a opcao desejada");

            Console.WriteLine("1 - Listar Serie");
            Console.WriteLine("2 - Inserir Nova Serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Excluir Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair");

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;
        }
    }
}
