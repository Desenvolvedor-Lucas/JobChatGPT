using JobChatGPT.ChatGPT;
using JobChatGPT.Telegram;
using JobChatGPT.Vagas;

var isRodarPrograma = true;
var isGetVaga = true;

var vagas = new List<Job>();

var telegram = new TelegramManager();
var jobAnalise = new JobAnaliseOpenAI();

while (isRodarPrograma)
{
    while (isGetVaga)
    {
        Console.WriteLine("TESTAR MSG TELEGRAM (1) ou EXTRAIR VAGAS DOS GRUPOS (2)");
        var r = Console.ReadLine();
        if (r == "1")
        {
            Console.WriteLine("Obtendo menssagens do Telegram! ...\n");
            var menssagensTelegram = await new TelegramManager().ExtrairMenssagens(1);

            foreach (var msg in menssagensTelegram)
            {
                var resposta = await jobAnalise.AnalisarEObterDados(msg);
                if (resposta.Contains("Sim é vaga"))
                {
                    var jobs = Job.GetVagaConfig(resposta);

                    if (vagas is not null)
                    {
                        foreach (var job in jobs)
                            if (job != null && job.Descricao.Length > 70)
                                vagas.Add(job);
                            else
                                Console.WriteLine("\nVaga sem possibilidade de se candidatar ou descrição com tamanho muito grande ou pequena demais\n");
                    }
                    else
                        Console.WriteLine("\nVaga sem possibilidade de se candidatar ou descrição com tamanho muito grande ou pequena demais\n");
                }
            }
        }
        else if (r == "2")
        {
            Console.WriteLine("Pegar vagas dos grupos de até quantos dias atrás?");
            var dias = int.Parse(Console.ReadLine());
            Console.WriteLine("Estraindo...");
            var menssagensTelegram = await telegram.ExtrairMenssagensDeGrupos(dias);

            foreach (var msg in menssagensTelegram)
            {
                var resposta = await jobAnalise.AnalisarEObterDados(msg);
                if (resposta.Contains("Sim é vaga"))
                {
                    var jobs = Job.GetVagaConfig(resposta, msg);

                    if (vagas is not null)
                    {
                        foreach (var job in jobs)
                            if (job != null && job.Descricao.Length > 70)
                                vagas.Add(job);
                            else
                                Console.WriteLine("\nVaga sem possibilidade de se candidatar ou descrição com tamanho muito grande ou pequena demais\n");
                    }
                    else
                        Console.WriteLine("\nVaga sem possibilidade de se candidatar ou descrição com tamanho muito grande ou pequena demais\n");
                }
            }
        }

        Console.WriteLine("\nTestar mais vaga? s/n");
        if (Console.ReadLine() == "s")
            TelegramManager.LimparMessagensDaLista();
        else
            isGetVaga = false;
    }

    Job.MostrarVagasObtidas(vagas);
    TelegramManager.LimparMessagensDaLista();

    Console.WriteLine("\nTestar programa de novo? s/n");
    if (Console.ReadLine() == "s")
    {
        vagas.Clear();
        isGetVaga = true;
        Console.WriteLine("\nLimpar Console? s/n");
        if (Console.ReadLine() == "s")
            Console.Clear();
    }
    else
        isRodarPrograma = false;
}