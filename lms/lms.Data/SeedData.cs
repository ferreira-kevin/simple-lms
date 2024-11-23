using lms.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace lms.Data;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new LmsDbContext(serviceProvider.GetRequiredService<DbContextOptions<LmsDbContext>>());
        if (context.Assignments.Any()) return;
        var assignments = MockAssignmentData();
        context.Assignments.AddRange(assignments);
        context.Questions.AddRange(MockQuestionData(Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC5")));
        context.Grades.AddRange([
            new GradingModel(Guid.NewGuid(), Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC4"), Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC1"), 5, DateTime.UtcNow.AddDays(-7)),
            new GradingModel(Guid.NewGuid(), Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC3"), Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC1"), 0, DateTime.UtcNow.AddDays(-5))
        ]);

        context.Courses.Add(new CourseModel { Id = Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC3"), Name = "Seminários II", Description = "Turma 123" });
        context.StudentCourses.Add(new() { CourseId = Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC9"), Status = "ativo"});
        context.SaveChanges();
    }

    private static List<AssignmentModel> MockAssignmentData()
    {
        return [
            new() {
                Id = Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC5"),
                Name = "Atividade Extensão Universitária 2",
                Description = "Responder de forma individual; \n É permitida a consulta ao matetial de aula.",
                Points = 10,
                OpensAt = DateTime.UtcNow.AddDays(-5),
                ClosesAt = DateTime.UtcNow.AddDays(5)
            },
            new() {
                Id = Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC4"),
                Name = "Atividade Extensão Universitária 1",
                Points = 5,
                Description = "",
                OpensAt = DateTime.UtcNow.AddDays(-5),
                ClosesAt = DateTime.UtcNow.AddDays(-1)
            },
            new() {
                Id = Guid.Parse("68B51F73-C12A-44F5-AD97-E6524007DFC3"),
                Name = "Atividade Introdução a Extensão Universitária",
                Points = 5,
                Description = "",
                OpensAt = DateTime.UtcNow.AddDays(-10),
                ClosesAt = DateTime.UtcNow.AddDays(-5)
            },
        ];
    }

    private static List<QuestionModel> MockQuestionData(Guid assignmentId)
    {
        return new List<QuestionModel> {
            new QuestionModel
            {
                Id = Guid.Parse("54c76eda-ff85-4a3d-808f-0544914e6363"),
                AssignmentId = assignmentId,
                Statment = "O que é extensão universitária?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("54c76eda-ff85-4a3d-808f-0544914e6363"), "Uma forma de ensino e aprendizado focada apenas em teorias acadêmicas.", false),
                    new(Guid.NewGuid(), Guid.Parse("54c76eda-ff85-4a3d-808f-0544914e6363"), "Uma integração entre universidade e comunidade para promover desenvolvimento mútuo.", true),
                    new(Guid.NewGuid(), Guid.Parse("54c76eda-ff85-4a3d-808f-0544914e6363"), "Um tipo de estágio obrigatório.", false),
                    new(Guid.NewGuid(), Guid.Parse("54c76eda-ff85-4a3d-808f-0544914e6363"), "Um evento de confraternização entre os alunos.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("d25f6b99-44bf-49dc-b188-bb2e47116f7f"),
                AssignmentId = assignmentId,
                Statment = "Qual é o principal objetivo da extensão universitária?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("d25f6b99-44bf-49dc-b188-bb2e47116f7f"), "Promover eventos esportivos na universidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("d25f6b99-44bf-49dc-b188-bb2e47116f7f"), "Aproximar a universidade da comunidade e gerar impactos sociais positivos.", true),
                    new(Guid.NewGuid(), Guid.Parse("d25f6b99-44bf-49dc-b188-bb2e47116f7f"), "Aumentar a carga horária dos alunos.", false),
                    new(Guid.NewGuid(), Guid.Parse("d25f6b99-44bf-49dc-b188-bb2e47116f7f"), "Substituir a pesquisa acadêmica.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbd"),
                AssignmentId = assignmentId,
                Statment = "Como a extensão universitária contribui para o desenvolvimento acadêmico?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbd"), "Desenvolve apenas habilidades teóricas.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbd"), "Proporciona experiência prática e aplica o conhecimento acadêmico na solução de problemas reais.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbd"), "Impede a realização de pesquisas científicas.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbd"), "Desconecta os alunos dos desafios da comunidade.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbe"),
                AssignmentId = assignmentId,
                Statment = "Qual é uma das vantagens da extensão universitária para a comunidade?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbe"), "A comunidade passa a depender totalmente da universidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbe"), "A comunidade recebe apoio na forma de conhecimento, tecnologias e práticas inovadoras.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbe"), "A universidade decide todas as necessidades da comunidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbe"), "A comunidade é obrigada a financiar projetos acadêmicos.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbf"),
                AssignmentId = assignmentId,
                Statment = "De que forma a extensão universitária pode fortalecer o currículo de um aluno?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbf"), "Aumentando as horas de aula teórica.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbf"), "Ao agregar experiências práticas e habilidades de resolução de problemas.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbf"), "Reduzindo o tempo dedicado aos estudos.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021697dbf"), "Diminuindo a interação com a comunidade.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c512047-4aee-4163-9f5e-11d021696dbd"),
                AssignmentId = assignmentId,
                Statment = "A extensão universitária pode ser considerada uma via de mão dupla porque:",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021696dbd"), "A universidade dá, mas não recebe nada em troca.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021696dbd"), "A comunidade colabora apenas financeiramente com a universidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021696dbd"), "Ambas, universidade e comunidade, se beneficiam do intercâmbio de conhecimento e experiências.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-11d021696dbd"), "Os alunos são obrigados a participar sem escolha.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c512047-4aee-4163-9f5e-12d021697dbd"),
                AssignmentId = assignmentId,
                Statment = "Qual das opções é um exemplo de projeto de extensão universitária?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-12d021697dbd"), "Desenvolvimento de tecnologias para pequenas empresas locais.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-12d021697dbd"), "Somente aulas teóricas dentro da universidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-12d021697dbd"), "Trabalho de conclusão de curso teórico.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4aee-4163-9f5e-12d021697dbd"), "Atividades extracurriculares esportivas.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c512047-4bee-4163-9f5e-11d021697dbd"),
                AssignmentId = assignmentId,
                Statment = "Quem pode se beneficiar da extensão universitária?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4bee-4163-9f5e-11d021697dbd"), "Somente os professores universitários.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4bee-4163-9f5e-11d021697dbd"), "Apenas os alunos.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4bee-4163-9f5e-11d021697dbd"), "Somente a comunidade local.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c512047-4bee-4163-9f5e-11d021697dbd"), "Tanto a comunidade quanto alunos e professores da universidade.", true)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c532047-4aee-4163-9f5e-11d021697dbd"),
                AssignmentId = assignmentId,
                Statment = "Como a extensão universitária pode impactar a comunidade a longo prazo?",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c532047-4aee-4163-9f5e-11d021697dbd"), "Criando uma dependência total da universidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c532047-4aee-4163-9f5e-11d021697dbd"), "Fortalecendo a autonomia e o desenvolvimento social e econômico da comunidade.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c532047-4aee-4163-9f5e-11d021697dbd"), "Focando apenas no desenvolvimento acadêmico dos alunos.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c532047-4aee-4163-9f5e-11d021697dbd"), "Desconectando a comunidade de soluções práticas.", false)
                ]
            },
            new QuestionModel
            {
                Id = Guid.Parse("8c612047-4aee-4163-9f5e-12d021697dbd"),
                AssignmentId = assignmentId,
                Statment = "A extensão universitária é uma atividade:",
                Options =
                [
                    new(Guid.NewGuid(), Guid.Parse("8c612047-4aee-4163-9f5e-12d021697dbd"), "Exclusivamente acadêmica, sem participação comunitária.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c612047-4aee-4163-9f5e-12d021697dbd"), "Focada em resolver problemas internos da universidade.", false),
                    new(Guid.NewGuid(), Guid.Parse("8c612047-4aee-4163-9f5e-12d021697dbd"), "Que busca promover interação entre universidade e sociedade para benefício mútuo.", true),
                    new(Guid.NewGuid(), Guid.Parse("8c612047-4aee-4163-9f5e-12d021697dbd"), "Obrigatória em todos os cursos universitários.", false)
                ]
            }
        };
    }
}
