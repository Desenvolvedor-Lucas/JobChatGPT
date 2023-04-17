
namespace JobChatGPT.Telegram
{
    internal class TelegramConfig 
    {

        public static string LoginApi(string what)
        {
            //Adicione as informações de api do seu telegram aqui
            switch (what)
            {
                case "api_id": return "";
                case "api_hash": return "";
                case "phone_number": return "";
                case "verification_code": Console.Write("Code: "); return Console.ReadLine();
                case "first_name": return "";      // if sign-up is required
                case "last_name": return "";       // if sign-up is required
                case "password": return "secret!";      // if user has enabled 2FA
                default: return null;                  // let WTelegramClient decide the default config
            }
        }
    }
}
