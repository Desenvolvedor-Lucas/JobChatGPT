using TL;

namespace JobChatGPT.Telegram
{
    internal class TelegramConfig
    {
        static List<Grupo> Grupos = new List<Grupo>()
        {
            new Grupo { Id =  1812144210, Nome = "LC Vagas" },
            //new Grupo { Id =  1495858401, Nome = "Vagas De Empregos Contabéis" },
            //new Grupo { Id =  1052992679, Nome = "Vagas de TI para Todos" },
        };

        public static string LoginApi(string what)
        {
            //Depois de já conectado a uma conta do telegram, para se conectar em outra é preciso
            //apagar a pasta 'bin' e 'obj' do repositorio e limpar projeto
            switch (what)
            {
                case "api_id": return "27921761";
                case "api_hash": return "17ce1fbbe93d3d8fb02b05212707e166";
                case "phone_number": return "+55 41 99136 2804";
                case "verification_code": Console.Write("Code: "); return Console.ReadLine();
                case "first_name": return "";      // if sign-up is required
                case "last_name": return "";       // if sign-up is required
                case "password": return "secret!";      // if user has enabled 2FA
                default: return null;                  // let WTelegramClient decide the default config
            }
        }

        public static List<ChatBase> ChatGruposDeEmpregos(Messages_Chats chats, bool mostrarChats = false)
        {
            var chatGrupo = new List<ChatBase>();

            //Percorre todos os chats
            foreach (var (id, chat) in chats.chats)
                if (chat.IsActive)
                {
                    //Percorre todos os grupos e verifica se o chat pertence ao grupo
                    foreach (var grupo in Grupos)
                        if (grupo.Id == id)
                            chatGrupo.Add(chats.chats[grupo.Id]);

                    if (mostrarChats)
                        Console.WriteLine($"{id,10}: {chat}");
                }

            return chatGrupo;
        }
    }

    public class Grupo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }

    public class Msg
    {
        public Grupo GrupoMsg { get; set; }
        public string Menssagem { get; set; }
        public DateTime DateEnvio { get; set; }
    }
}
