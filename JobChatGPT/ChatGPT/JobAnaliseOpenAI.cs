using JobChatGPT.Telegram;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Text.RegularExpressions;

namespace JobChatGPT.ChatGPT
{
    public class JobAnaliseOpenAI
    {
        private static string pergunta = "Se uma vaga de emprego. extrair se informado, sua função, descrição completa, localização, se ela home office ou remota, salario, empresa, url, e-mail, se não for vaga de emprego fale apenas \"não é uma vaga\"";
        private const string _apiKey = "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";
        //https://platform.openai.com/account/api-keys

        private static OpenAIAPI openAI = new OpenAIAPI(_apiKey);
        private Conversation chat;

        public async Task<string> AnalisarEObterDados(string analiseVagaTexto)
        {
            // 3 por minuto | 20s por analise
            var origem = Regex.Match(analiseVagaTexto, @"(.+) para .+ (msg = )", RegexOptions.IgnoreCase).Groups[1].Value;
            origem = Regex.Replace(origem, @"\s+", " ", RegexOptions.IgnoreCase).Trim();

            var texto = Regex.Replace(analiseVagaTexto, @".+msg =", "", RegexOptions.IgnoreCase);
            Console.WriteLine($"\nAnalisando -> [ {Regex.Replace(analiseVagaTexto, @"\s+", " ")} ]");

            if (texto.Length < 70)
                return "Msg muito pequena";

            Thread.Sleep(5000);
            chat = TreinamentoJob(openAI.Chat.CreateConversation());
            Thread.Sleep(5000);

            chat.AppendUserInput($"do texto \"{texto}\" {pergunta}");
            var resposta = await chat.GetResponseFromChatbotAsync();

            Console.WriteLine("\n\n    ANALISES COMPLETADAS\n    #####Resultados#####\n");
            Console.WriteLine($"\n-------------------------\n   {resposta}\n-------------------------\n");
            Thread.Sleep(10000);

            return $"{resposta}\nOrigem: {origem}";
        }

        public async Task<string> AnalisarEObterDados(Msg analiseVaga)
        {
            // 3 por minuto | 20s por analise
            var texto = Regex.Replace(analiseVaga.Menssagem, @".+msg =", "", RegexOptions.IgnoreCase);
            Console.WriteLine($"\nAnalisando -> ({analiseVaga.GrupoMsg.Nome} : {analiseVaga.DateEnvio}),\n [ {Regex.Replace(analiseVaga.Menssagem, @"\s+", " ")} ]");

            if (analiseVaga.Menssagem.Length < 70)
                return "Msg muito pequena";

            Thread.Sleep(5000);
            chat = TreinamentoJob(openAI.Chat.CreateConversation());
            Thread.Sleep(5000);

            chat.AppendUserInput($"do texto \"{texto}\" {pergunta}");
            var resposta = await chat.GetResponseFromChatbotAsync();

            Console.WriteLine("\n\n    ANALISES COMPLETADAS\n    #####Resultados#####\n");
            Console.WriteLine($"\n-------------------------\n   {resposta}\n-------------------------\n");
            Thread.Sleep(10000);

            return resposta;
        }

        private Conversation TreinamentoJob(Conversation chat)
        {
            chat.AppendUserInput($"do texto \"Arquiteto de Software Pleno\r\n\r\nContratação: PJ\r\nModelo: Remoto\r\n\r\nNecessário experiência com:\r\n\r\nConhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN.\r\nMetodologia Ágil: Scrum e Kanban.\r\nInfraestrutura (Servidores Linux, Docker).\r\nMonitoramento de Tarefas: Jira e MantisBT.\r\nDesenvolvimento Mobile: Android (Java) e iOS.\r\nBanco de dados relacionais e Modelagem: PostgreSQL e MySQL.\r\nDevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap.\r\nAnálise de requisitos funcionais e não-funcionais.\r\nSalario: R$ 3.000\r\nNecessário morar em Curitiba\r\n\r\nGraduação completa na área de TI;\r\n\r\nInteressados enviar o currículo para:  gabriela.nascimento@globalweb.com.br\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim é vaga\nFunção: Arquiteto de Software Pleno\nDescrição: Contratação: PJ Modelo: Remoto Necessário experiência com: Conhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN. Metodologia Ágil: Scrum e Kanban. Infraestrutura (Servidores Linux, Docker). Monitoramento de Tarefas: Jira e MantisBT. Desenvolvimento Mobile: Android (Java) e iOS. Banco de dados relacionais e Modelagem: PostgreSQL e MySQL. DevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap. Análise de requisitos funcionais e não-funcionais. Salario: R$ 3.000 Graduação completa na área de TI\nLocalização: Curitiba/PR\nRemoto: Sim\nSalario: 3000\nEmpresa: globalweb\nUrl Candidatar: não informado\nEmail: gabriela.nascimento@globalweb.com.br");

            //chat.AppendUserInput($"do texto \"Arquiteto de Software Pleno\r\n\r\nContratação: PJ\r\nModelo: Remoto\r\n\r\nNecessário experiência com:\r\n\r\nConhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN.\r\nMetodologia Ágil: Scrum e Kanban.\r\nInfraestrutura (Servidores Linux, Docker).\r\nMonitoramento de Tarefas: Jira e MantisBT.\r\nDesenvolvimento Mobile: Android (Java) e iOS.\r\nBanco de dados relacionais e Modelagem: PostgreSQL e MySQL.\r\nDevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap.\r\nAnálise de requisitos funcionais e não-funcionais.\r\n\r\nGraduação completa na área de TI;\" {pergunta}");
            //chat.AppendExampleChatbotOutput("Sim é vaga\nFunção: Arquiteto de Software Pleno\nDescrição: Contratação: PJ Modelo: Remoto Necessário experiência com: Conhecimentos em versionamento de código: Git (Pipelines CI/CD) e SVN. Metodologia Ágil: Scrum e Kanban. Infraestrutura (Servidores Linux, Docker). Monitoramento de Tarefas: Jira e MantisBT. Desenvolvimento Mobile: Android (Java) e iOS. Banco de dados relacionais e Modelagem: PostgreSQL e MySQL. DevOps Backend e Frontend: PHP (Apache), HTML, CSS, NodeJS, API REST, Swagger, ReactJS/React Native, Angular e Bootstrap. Análise de requisitos funcionais e não-funcionais. Graduação completa na área de TI;\nLocalização: não informado\nRemoto: Sim\nSalario: não informado\nEmpresa: não informado\nUrl Candidatar: não informado\nEmail: não informado");

            chat.AppendUserInput($"do texto \"Ajudante Geral\r\nCentro – São Paulo / SP\r\nTurno: Escala 6×1\r\nSalário: R$ 1.572,00\r\nDescrição: Atuar com arrumação e serviços de copa/cozinha\r\nRequisitos:\r\nDisponibilidade para início imediato\r\nBenefícios:\r\nVale-Refeição / Vale-Alimentação / Vale-Transporte\r\nAcesse: <https://empregossaopauloeregioes.blogspot.com/2023/04/ajudante-geral_52.html>\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim é vaga\nFunção: Ajudante Geral\nDescrição: Atuar com arrumação e serviços de copa/cozinha. Requisitos: Disponibilidade para início imediato\nLocalização: São Paulo/SP\nRemoto: Não\nSalario: R$ 1.572,00\nEmpresa: não informado\nUrl Candidatar: https://empregossaopauloeregioes.blogspot.com/2023/04/ajudante-geral_52.html\nEmail: não informado");

            chat.AppendUserInput($"do texto \"APW Brasil - Executivo de Aquisições - Presencial (SP) e Remoto (Outros Estados)\r\nhttps://recruiting.ultipro.com/RAD1007RDGI/JobBoard/37333b2b-2e59-4fb3-b643-214c259a4cf0/OpportunityDetail?opportunityId=c17c5da9-6ed0-4643-8319-e1995ad84209&sourceId=b578f286-44ea-46fc-97a5-356876a213b5\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim é vaga\nFunção: Executivo de Aquisições\nDescrição: não informado\nLocalização: São Paulo/SP\nRemoto: Sim\nSalario: não informado\nEmpresa: APW Brasil\nUrl Candidatar: https://recruiting.ultipro.com/RAD1007RDGI/JobBoard/37333b2b-2e59-4fb3-b643-214c259a4cf0/OpportunityDetail?opportunityId=c17c5da9-6ed0-4643-8319-e1995ad84209&sourceId=b578f286-44ea-46fc-97a5-356876a213b5\nEmail: não informado");

            //chat.AppendUserInput($"do texto \"A ADSet está com uma oportunidade para Analista de Sistemas Full Stack Pleno CLT. Informações sobre a vaga:\r\n- Remuneração mensal: 7K \r\n- Formato de contratação: CLT\r\n- Modelo de trabalho: Remoto\r\n- Local de trabalho: Salvador ou Região Metropolitana\r\n- Sodexo diário R$34,86 (mesmo em home office)\r\n- Plano de saúde: Unimed Nacional Absoluto (CNU Absoluto)\r\n\r\n\r\nMissão\r\nA missão, enquanto Analista de Sistemas Full Stack Pleno da ADSet, será colaborar com o crescimento da nossa empresa, tornando alguns produtos comercializáveis e criando outros através do uso das mais recentes tecnologias e melhores práticas no desenvolvimento de software.\r\n\r\n\r\nResponsabilidades e atividades\r\n- Com ética e pró-atividade, será responsável pelo desenvolvimento do sistema de nossa plataforma, sempre de olho na sua escalabilidade e na excelente experiência dos usuários.\r\n- Desenvolver novas features;\r\n- Realizar a sustentação do sistema;\r\n- Pensar colaborativamente em soluções inovadoras para os desafios;\r\n- Atualizar o sistema de gestão das tarefas.\r\n\r\n\r\nPerfil técnico esperado\r\n- HTML, CSS, JavaScript, POO, WebApi, Bootstrap, jQuery, C#, ASP NET MVC, SQL, LINQ.\r\n- Entity Framework, Code First, Desenvolvimento Mobile e Design Responsivo;\r\n- Banco de dados SQL Server;\r\n- WebServices (SOAP), APIs Restfull e Windows Services\r\n\r\n\r\nRequisitos Desejáveis \r\n- Azure Devops, Cloud Computing e AWS WebServices\r\n- Controle de versão de código (Git/TFS)\r\n\r\n\r\nPerfil Comportamental Esperado\r\n- Capaz de estabelecer vínculo com a empresa e dedicar-se ao cumprimento de seu propósito;\r\n- É proativo(a), preferindo a execução, em vez de esperar as coisas acontecerem por si só;\r\n- Tem perfil autorresponsável e autônomo, sabendo gerir as rotinas diárias, bem como a si mesmo(a);\r\n- É autodidata, quer dizer, aprende por si próprio(a).\r\nEnviar currículo + link do github com o assunto “Analista de Sistemas Full Stack Pleno CLT” para talentosrecruta.insight@gmail.com\" {pergunta}");
            //chat.AppendExampleChatbotOutput("Sim é vaga\nFunção: Analista de Sistemas Full Stack Pleno\nDescrição: Enquanto Analista de Sistemas Full Stack Pleno da ADSet, será colaborar com o crescimento da nossa empresa, tornando alguns produtos comercializáveis e criando outros através do uso das mais recentes tecnologias e melhores práticas no desenvolvimento de software. Responsabilidades e atividades - Com ética e pró-atividade, será responsável pelo desenvolvimento do sistema de nossa plataforma, sempre de olho na sua escalabilidade e na excelente experiência dos usuários. - Desenvolver novas features; - Realizar a sustentação do sistema; - Pensar colaborativamente em soluções inovadoras para os desafios; - Atualizar o sistema de gestão das tarefas. Perfil técnico esperado - HTML, CSS, JavaScript, POO, WebApi, Bootstrap, jQuery, C#, ASP NET MVC, SQL, LINQ. - Entity Framework, Code First, Desenvolvimento Mobile e Design Responsivo; - Banco de dados SQL Server; - WebServices (SOAP), APIs Restfull e Windows Services Requisitos Desejáveis - Azure Devops, Cloud Computing e AWS WebServices - Controle de versão de código (Git/TFS).\nLocalização: Salvador ou Região Metropolitana\r\nRemoto: Sim\r\nSalario: R$ 7.000,00\r\nEmpresa: ADSet\r\nUrl Candidatar: não informado\r\nEmail: talentosrecruta.insight@gmail.com");

            chat.AppendUserInput($"do texto \"Estamos com vaga aberta para Analista fiscal.\r\nSalário R$ 4.000,00 + VT + VR.\r\nCom amplos conhecimento na rotina fiscal completa.\r\nConhecimento no sistema Dominio.\r\nPresencial 100%\r\nHorário das 8:00 às 18:00 de segunda a quinta e sexta das 8:00 às 17:00.\r\n1 hora de almoço e café da manhã.\r\nE-mail: israel.contabil@bol.com.br\r\nEndereço Rua Coronel Otaviano da Silveira, 175 - Ferreira Ao lado do metro Vila Sonia. SP\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim é vaga\nFunção: Analista fiscal\nDescrição: Com amplos conhecimento na rotina fiscal completa. Conhecimento no sistema Dominio. Presencial 100% Horário das 8:00 às 18:00 de segunda a quinta e sexta das 8:00 às 17:00. 1 hora de almoço e café da manhã.\nLocalização: São Paulo/SP\nRemoto: Não\r\nSalario: R$ 4.000,00\nEmpresa: não informado\nUrl Candidatar: não informado\nEmail: israel.contabil@bol.com.br");

            chat.AppendUserInput($"do texto \"Boa tarde Rede Amada 💐\r\n\r\n🚨 VAGAS URGENTE 🚨\r\n\r\nEnviar CV para Amanda Costa 91338-6563, ou pelo link https://lnkd.in/d5GrK24w\r\n\r\nASSISTENTE DE LEGALIZAÇÃO\r\n💰 R$ 2.300,00 + VT e VR\r\n⏰ Seg a Qui das 8:30 às 18:00 Sex das 8:30 às 17:00\r\n📍 Belém - SP\r\n\r\nANALISTA CONTÁBIL\r\n💰 De R$ 3.600,00 a R$ 4.500,00 + VT e VA Seguro de vida e Convênio odontológico\r\n⏰ Seg a Qui das 8:00 às 18:00 Sex das 8:30 às 17:30\r\n📍 Leopoldina - SP\r\n\r\nANALISTA CONTÁBIL\r\n💰 R$ 3.250,00 + VT e VR e Seguro de vida\r\n⏰ Seg a Qui das 8:00 às 18:00 Sex das 8:00 às 17:00\r\n📍 Vila Mariana - SP\r\n\r\n\r\nRequisitos\r\nExperiência em escritório contábil\r\n\r\n\r\n\r\n#cv #vagastecnologia\" {pergunta}");
            chat.AppendExampleChatbotOutput("Sim é vaga\n\nFunção: Assistente De Legalização\r\nDescrição: Salario + VT e VR. Seg a Qui das 8:30 às 18:00 Sex das 8:30 às 17:00. Requisitos, Experiência em escritório contábil\nLocalização: Belém/SP\nRemoto: Não\nSalario: R$ 2.300,00\nEmpresa: não informado\nUrl Candidatar: https://lnkd.in/d5GrK24w\nEmail: não informado\n\nFunção: Analista Contábil\nDescrição: Salario + VT e VA Seguro de vida e Convênio odontológico. Seg a Qui das 8:00 às 18:00 Sex das 8:30 às 17:30. Requisitos, Experiência em escritório contábil\nLocalização: Leopoldina/SP\nRemoto: Não\nSalario: De R$ 3.600,00 a R$ 4.500,00\nEmpresa: não informado\nUrl Candidatar: https://lnkd.in/d5GrK24w\nEmail: não informado\n\nFunção: Analista Contábil\nDescrição: Salario + VT e VR e Seguro de vida. Seg a Qui das 8:00 às 18:00 Sex das 8:00 às 17:00. Requisitos, Experiência em escritório contábil\nLocalização: Vila Mariana/SP\nRemoto: Não\nSalario: R$ 3.250,00\nEmpresa: não informado\nUrl Candidatar: https://lnkd.in/d5GrK24w\nEmail: não informado");

            chat.AppendUserInput($"do texto \"para fazer um bolo é preciso muita coragem, além de muita força para preparar a massa, claro que o bolo fica uma delicia né gente\" {pergunta}");
            chat.AppendExampleChatbotOutput("não é uma vaga");

            return chat;
        }
    }
}