using TL;
using WTelegram;

namespace JobChatGPT.Telegram
{
    public class TelegramManager
    {
        private bool isButMessage = true;
        private static List<string> MenssagensTelegram = new List<string>();

        static Client? Client;
        static User? My;
        static readonly Dictionary<long, User> Users = new Dictionary<long, User>();
        static readonly Dictionary<long, ChatBase> Chats = new Dictionary<long, ChatBase>();

        public async Task<List<string>> ExtrairMenssagens(int quantidade)
        {
            Helpers.Log = (l, s) => System.Diagnostics.Debug.WriteLine(s);
            Client = new Client(TelegramConfig.LoginApi);

            using (Client)
            {
                My = await Client.LoginUserIfNeeded();
                Users[My.id] = My;

                while (isButMessage)
                {
                    var dialogs = await Client.Messages_GetAllDialogs();
                    Client.OnUpdate += Client_OnUpdate;

                    if (MenssagensTelegram.Count >= quantidade)
                        isButMessage = false;
                }
            }

            return MenssagensTelegram;
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
                    if (m.message.Length > 70 && !MenssagensTelegram.Contains($"{Peer(m.from_id) ?? m.post_author} para {Peer(m.peer_id)} msg = \n{m.message}"))
                    {
                        Console.WriteLine($"\n{Peer(m.from_id) ?? m.post_author} para {Peer(m.peer_id)} msg = \n{m.message}");
                        MenssagensTelegram.Add($"{Peer(m.from_id) ?? m.post_author} para {Peer(m.peer_id)} msg = \n{m.message}");
                    }
                    break;
                default:
                    break;
            }
            return Task.CompletedTask;
        }

        public static void LimparMessagensDaLista()
        {
            MenssagensTelegram.Clear();
        }

        private static string User(long id) => Users.TryGetValue(id, out var user) ? user.ToString() : $"User {id}";
        private static string? Chat(long id) => Chats.TryGetValue(id, out var chat) ? chat.ToString() : $"Chat {id}";
        private static string? Peer(Peer peer) => peer is null ? null : peer is PeerUser user ? User(user.user_id)
            : peer is PeerChat or PeerChannel ? Chat(peer.ID) : $"Peer {peer.ID}";
    }
}
