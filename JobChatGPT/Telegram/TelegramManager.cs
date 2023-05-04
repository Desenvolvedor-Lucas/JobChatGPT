using TL;
using WTelegram;

namespace JobChatGPT.Telegram
{
    public class TelegramManager
    {
        private bool isButMessage = true;
        private static List<string> MsgTelegram = new List<string>();
        private static List<string> MsgTelegramAuxiliar = new List<string>();

        static Client? Client;
        static User? My;
        static readonly Dictionary<long, User> Users = new Dictionary<long, User>();
        static readonly Dictionary<long, ChatBase> Chats = new Dictionary<long, ChatBase>();

        public async Task<List<Msg>> ExtrairMenssagensDeGrupos(int periodoDias)
        {
            Helpers.Log = (l, s) => System.Diagnostics.Debug.WriteLine(s);
            Client = new Client(TelegramConfig.LoginApi);
            var listMsg = new List<Msg>();

            using (Client)
            {
                My = await Client.LoginUserIfNeeded();
                Users[My.id] = My;

                var dialogs = await Client.Messages_GetAllDialogs();
                dialogs.CollectUsersChats(Users, Chats);

                var messages_chats = new Messages_Chats();
                messages_chats.chats = Chats;
                var chatsGrupos = TelegramConfig.ChatGruposDeEmpregos(messages_chats, true);

                foreach (var chatGrupo in chatsGrupos)
                {
                    var pegarMsgDoGrupo = true;
                    for (int offset = 0; ;)
                    {
                        var messagesBase = await Client.Messages_GetHistory(chatGrupo.ToInputPeer(), 0, default, offset, 10000, 0, 0, 0);
                        if (messagesBase is not Messages_ChannelMessages channelMessages) break;
                        foreach (var msgBase in channelMessages.messages)
                            if (msgBase is Message msg)
                            {
                                //Obs: da data arruma o fuso horário e ignora a hora do envio, leva em consideração o dia do envio
                                if (DateTime.Parse(msg.Date.AddHours(-3).ToString("dd/MM/yyyy")) >= DateTime.Now.AddDays(-periodoDias) && !(string.IsNullOrEmpty(msg.message) || string.IsNullOrWhiteSpace(msg.message)))
                                    listMsg.Add(new Msg
                                    {
                                        GrupoMsg = new Grupo
                                        {
                                            Id = chatGrupo.ID,
                                            Nome = chatGrupo.Title
                                        },
                                        Menssagem = msg.message,
                                        DateEnvio = msg.Date.AddHours(-3)
                                    });
                                else if (DateTime.Parse(msg.Date.AddHours(-3).ToString("dd/MM/yyyy")) < DateTime.Now.AddDays(-periodoDias))
                                {
                                    pegarMsgDoGrupo = false;
                                    break;
                                }
                            }

                        offset += channelMessages.messages.Length;
                        if (offset >= channelMessages.count || !pegarMsgDoGrupo) break;
                    }
                }
            }

            return listMsg;
        }

        public async Task<List<string>> ExtrairMenssagens(int quantidade)
        {
            Helpers.Log = (l, s) => System.Diagnostics.Debug.WriteLine(s);
            Client = new Client(TelegramConfig.LoginApi);
            
            isButMessage = true;
            
            using (Client)
            {
                My = await Client.LoginUserIfNeeded();
                Users[My.id] = My;

                while (isButMessage)
                {
                    var dialogs = await Client.Messages_GetAllDialogs();
                    dialogs.CollectUsersChats(Users, Chats);

                    Client.OnUpdate += Client_OnUpdate;

                    if (MsgTelegram.Count >= quantidade)
                        isButMessage = false;
                }
            }

            return MsgTelegram;
        }


        private static async Task Client_OnUpdate(IObject arg)
        {
            if (!(arg is UpdatesBase updates)) return;
            updates.CollectUsersChats(Users, Chats);
            foreach (var update in updates.UpdateList)
                switch (update)
                {
                    case UpdateNewMessage unm:
                        await DisplayMessage(unm.message);
                        break;
                    default:
                        break;
                }
        }

        private static Task DisplayMessage(MessageBase messageBase, bool edit = false)
        {
            switch (messageBase)
            {
                case Message m:
                    if (m.message.Length > 70 && !MsgTelegramAuxiliar.Contains($"{Peer(m.from_id) ?? m.post_author} para {Peer(m.peer_id)} msg = \n{m.message}"))
                    {
                        Console.WriteLine($"{Peer(m.from_id) ?? m.post_author} para {Peer(m.peer_id)} msg = \n{m.message}");

                        var origem = "";
                        //Na busca da origem, condições para cada caso
                        //Se msg de grupo publico, se não tenta procura no caso de msg privada se não conseguir procura no caso de chat bot
                        if (m.From is not null)
                        {
                            if (m.From.ID > 0) origem = Users.First(x => x.Key == m.From.ID).Value.MainUsername;
                            if (m.Peer is not null) // 2 if para que se Peer for nulo não lançar exceção na busca onde confere do ID
                                if (m.Peer.ID > 0)  origem = $"{Chats.First(x => x.Key == m.Peer.ID).Value.Title} -> {origem}";
                        }
                        else if (m.Peer is not null)
                        {
                            try
                            {
                                if (m.Peer.ID > 0)
                                    origem = Users.First(x => x.Key == m.Peer.ID).Value.MainUsername;
                            }
                            catch
                            {
                                if (m.Peer.ID > 0)
                                    origem = Chats.First(x => x.Key == m.Peer.ID).Value.Title;
                            }
                        }

                        MsgTelegramAuxiliar.Add($"{Peer(m.from_id) ?? m.post_author} para {Peer(m.peer_id)} msg = \n{m.message}");
                        MsgTelegram.Add($"{origem} para {Peer(m.peer_id)} msg = \n{m.message}");
                    }
                    break;
                default:
                    break;
            }

            return Task.CompletedTask;
        }

        public static void LimparMessagensDaLista()
        {
            MsgTelegram.Clear();
        }

        private static string User(long id) => Users.TryGetValue(id, out var user) ? user.ToString() : $"User {id}";
        private static string? Chat(long id) => Chats.TryGetValue(id, out var chat) ? chat.ToString() : $"Chat {id}";
        private static string? Peer(Peer peer) => peer is null ? null : peer is PeerUser user ? User(user.user_id)
            : peer is PeerChat or PeerChannel ? Chat(peer.ID) : $"Peer {peer.ID}";
    }
}
