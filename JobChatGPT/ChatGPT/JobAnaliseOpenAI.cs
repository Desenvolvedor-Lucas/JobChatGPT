using OpenAI_API;
using System.Text.RegularExpressions;

namespace JobChatGPT.ChatGPT
{
    public class JobAnaliseOpenAI
    {
        private static string pergunta = "Se for uma vaga de emprego. extraia sua função, descrição completa, (cidade/estado ou se ela home office ou remota), (salario, empresa) se informado e seu link para se candidatar ou eu e-mail para se candidatar, se não for uma vaga de emprego fale apenas \"não é uma vaga\"";
        private const string _apiKey = "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";

        private static OpenAIAPI openAI = new OpenAIAPI(_apiKey);

        public static async Task<string> AnalisarEObterDados(string analiseVagaTexto)
        {
            var texto = Regex.Replace(analiseVagaTexto, @".+msg =", "", RegexOptions.IgnoreCase);
            Console.WriteLine($"Analisando -> [ {Regex.Replace(analiseVagaTexto, @"\s+", " ")} ]");

            var chat = openAI.Chat.CreateConversation();

            //Treinamento para receber uma mensagem padronizada
            chat.AppendUserInput($"do texto \"Arquiteto de Software Pleno\r\n\r\nContratação: PJ\r\nModelo: Remoto\r\n\r\nNecessário experiência com:\r\n\r\nConhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN.\r\nMetodologia Ágil: Scrum e Kanban.\r\nInfraestrutura (Servidores Linux, Docker).\r\nMonitoramento de Tarefas: Jira e MantisBT.\r\nDesenvolvimento Mobile: Android (Java) e iOS.\r\nBanco de dados relacionais e Modelagem: PostgreSQL e MySQL.\r\nDevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap.\r\nAnálise de requisitos funcionais e não-funcionais.\r\nSalario: R$ 3.000\r\n\r\nGraduação completa na área de TI;\r\n\r\nInteressados enviar o currículo para:  gabriela.nascimento@globalweb.com.br\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim, é uma vaga de emprego\nFunção: Arquiteto de Software Pleno\nDescrição: Contratação: PJ Modelo: Remoto Necessário experiência com: Conhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN. Metodologia Ágil: Scrum e Kanban. Infraestrutura (Servidores Linux, Docker). Monitoramento de Tarefas: Jira e MantisBT. Desenvolvimento Mobile: Android (Java) e iOS. Banco de dados relacionais e Modelagem: PostgreSQL e MySQL. DevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap. Análise de requisitos funcionais e não-funcionais. Salario: R$ 3.000 Graduação completa na área de TI\nLocalização: Remoto\nSalario: 3000\nEmpresa: globalweb\nContado: gabriela.nascimento@globalweb.com.br");
            chat.AppendUserInput($"do texto \"Arquiteto de Software Pleno\r\n\r\nContratação: PJ\r\nModelo: Remoto\r\n\r\nNecessário experiência com:\r\n\r\nConhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN.\r\nMetodologia Ágil: Scrum e Kanban.\r\nInfraestrutura (Servidores Linux, Docker).\r\nMonitoramento de Tarefas: Jira e MantisBT.\r\nDesenvolvimento Mobile: Android (Java) e iOS.\r\nBanco de dados relacionais e Modelagem: PostgreSQL e MySQL.\r\nDevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap.\r\nAnálise de requisitos funcionais e não-funcionais.\r\n\r\nGraduação completa na área de TI;\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim, é uma vaga de emprego\nFunção: Arquiteto de Software Pleno\nDescrição: Contratação: PJ Modelo: Remoto Necessário experiência com: Conhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN. Metodologia Ágil: Scrum e Kanban. Infraestrutura (Servidores Linux, Docker). Monitoramento de Tarefas: Jira e MantisBT. Desenvolvimento Mobile: Android (Java) e iOS. Banco de dados relacionais e Modelagem: PostgreSQL e MySQL. DevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap. Análise de requisitos funcionais e não-funcionais. Graduação completa na área de TI;\nLocalização: Remoto\nSalario: não informado\nEmpresa: não informado\nContado: não informado");
            chat.AppendUserInput($"do texto \"para fazer um bolo é preciso muita coragem, além de muita força para preparar a massa, claro que o bolo fica uma delicia né gente\" {pergunta}");
            chat.AppendExampleChatbotOutput("não é uma vaga");

            chat.AppendUserInput($"do texto \"{texto}\" {pergunta}");
            var resposta = await chat.GetResponseFromChatbotAsync();

            Console.WriteLine("\n\n    ANALISES COMPLETADAS\n    #####Resultados#####\n");
            Console.WriteLine($"\n-------------------------\n   {resposta}\n-------------------------\n");

            return resposta;
        }
    }
}
