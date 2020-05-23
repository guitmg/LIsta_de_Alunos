using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indexAluno = 0;
            string opcaoUsuario = receberOpcaoUsuario();


            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Digite o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        
                        Console.WriteLine("Digite a nota do aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("A nota deve ser inserida em formato decimal");
                        }

                        alunos[indexAluno] = aluno;
                        indexAluno++;

                        break;
                    case "2":
                        foreach (var i in alunos)
                        {
                            if (!string.IsNullOrEmpty(i.Nome))
                            {
                                Console.WriteLine($"NOME: {i.Nome} - NOTA: {i.Nota}");
                            }
                        }
                        break;
                    case "3":
                        decimal totalNotas = 0;
                        int totalAlunos = 0;

                        for (int a = 0; a < alunos.Length; a++)
                        {
                            if (!string.IsNullOrEmpty(alunos[a].Nome))
                            {
                                totalNotas = totalNotas + alunos[a].Nota;
                                totalAlunos++;
                            }
                        }
                        decimal mediaGeral = totalNotas / totalAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }
                        Console.WriteLine($"MÉDIA: {mediaGeral} - CONCEITO: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = receberOpcaoUsuario();
            }
        }

        private static string receberOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Digite uma das opções abaixo:");
            Console.WriteLine("1- Adicionar Aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
