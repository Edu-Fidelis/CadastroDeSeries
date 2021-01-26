using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        LInserirSerie();
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
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por usar os nossos serviços!!\n\tJESUS te abençoe!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach ( var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}: - {1}", i, Enum.GetValues(typeof(Genero)) , i );
            }
             Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título da série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de iníco da série: ");
                int entradaAno= int.Parse(Console.ReadLine());

                Console.Write("Digite o gênero entre as opções acima: ");
                string entradaDescricao = Console.ReadLine();

                Series atualizaaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Atualiza( indiceSerie ,atualizaSerie);

        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static void InserirSerie()
        {
                Console.WriteLine("Inserir nova série");

                foreach (int i in Enum.GetValues(typeof(Genero), i));
                {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
                }
                Console.Write("Digite o gênero entre as opções acima: ");
                int entradaGenero = int.Parse(Console.ReadLine());

                Console.Write("Digite o título da série: ");
                string entradaTitulo = Console.ReadLine();

                Console.Write("Digite o Ano de iníco da série: ");
                int entradaAno= int.Parse(Console.ReadLine());

                Console.Write("Digite o gênero entre as opções acima: ");
                string entradaDescricao = Console.ReadLine();

                Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

                repositorio.Insere(novaSerie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Seja Bem-vindo(a) ao cadastro de séries!");
            Console.WriteLine("Digite a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
