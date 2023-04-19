using JobChatGPT.ChatGPT;
using JobChatGPT.Telegram;
using JobChatGPT.Vagas;

var isRodarPrograma = true;
var isGetVaga = true;
var vagas = new List<Job>();

while (isRodarPrograma)
{
    while (isGetVaga)
    {
        Console.WriteLine("Obtendo menssagens do Telegram! ...\n");
        var menssagensTelegram = await new TelegramManager().ExtrairMenssagens(1);

        foreach (var msg in menssagensTelegram)
        {
            var resposta = await JobAnaliseOpenAI.AnalisarEObterDados(msg);
            if (resposta.Contains("Sim, é uma vaga de emprego"))
            {
                var vaga = Job.GetVagaConfig(resposta);

                if (vaga != null && vaga.Descricao.Length > 70)
                    vagas.Add(vaga);
                else
                    Console.WriteLine("\nVaga sem possibilidade de se candidatar ou descrição com tamanho muito grande ou pequena demais\n");
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