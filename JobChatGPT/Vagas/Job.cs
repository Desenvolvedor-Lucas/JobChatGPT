using JobChatGPT.Telegram;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace JobChatGPT.Vagas
{
    public class Job
    {
        public string Funcao { get; set; }
        public string Descricao { get; set; }
        public string DataPublicacao { get; set; }
        public string? Localizacao { get; set; }
        public string? UrlCandidatar { get; set; }
        public string? Email { get; set; }
        public string? Salario { get; set; }
        public string? Empresa { get; set; }
        public string? Origem { get; set; }
        public bool? IsRemoto { get; set; }

        public Job(string urlCandidatar, string funcao, string descricao, string localizacao, string dataPublicacao, string? email = null, string? salario = null, string? empresa = null, string? origem = null, bool? isRemoto = null)
        {
            Funcao = funcao;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Localizacao = localizacao;
            UrlCandidatar = urlCandidatar;
            Email = email;
            Salario = salario;
            Empresa = empresa;
            Origem = origem;
            IsRemoto = isRemoto;
        }

        //Para caso tenha somente e-mail
        public Job(string email, string funcao, string descricao, string localizacao, string dataPublicacao, string? salario = null, string? empresa = null, string? origem = null, bool? isRemoto = null, string? urlCandidatar = null)
        {
            Funcao = funcao;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Localizacao = localizacao;
            UrlCandidatar = urlCandidatar;
            Email = email;
            Salario = salario;
            Empresa = empresa;
            Origem = origem;
            IsRemoto = isRemoto;
        }

        public static List<Job>? GetVagaConfig(string resposta, Msg msg = null)
        {
            var jobs = new List<Job>();

            //Pega os atributos por parte, indenpendente de quantas vagas tenham
            var funcoes = Regex.Matches(resposta, @"Função: (.+)", RegexOptions.IgnoreCase);
            var descricoes = Regex.Matches(resposta, @"Descrição: (.+)", RegexOptions.IgnoreCase);
            var locais = Regex.Matches(resposta, @"Localização: (.+)", RegexOptions.IgnoreCase);
            var remotos = Regex.Matches(resposta, @"Remoto: (.+)", RegexOptions.IgnoreCase);
            var salarios = Regex.Matches(resposta, @"Sal[aá]rio: (.+)", RegexOptions.IgnoreCase);
            var empresas = Regex.Matches(resposta, @"Empresa: (.+)", RegexOptions.IgnoreCase);
            var urls = Regex.Matches(resposta, @"[Uu][Rr][Ll]( Candidatar)?: (.+)", RegexOptions.IgnoreCase);
            var emails = Regex.Matches(resposta, @"E-?mail: (.+)", RegexOptions.IgnoreCase);
            var origem = Regex.Match(resposta, @"Origem: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            
            //Pega vaga por vaga que achar e configura
            for (var i = 0; i < funcoes.Count; i++)
            {
                var funcao = funcoes[i].Groups[1].Value;
                var descricao = descricoes[i].Groups[1].Value;
                var local = locais[i].Groups[1].Value;
                var remoto = remotos[i].Groups[1].Value;
                var salario = salarios[i].Groups[1].Value;
                var empresa = empresas[i].Groups[1].Value;
                var email = emails[i].Groups[1].Value;
                var dataPublicacao = DateTime.Now.ToString("dd/MM/yyyy");

                var url = "";
                try { url = urls[i].Groups[2].Value; }
                catch { url = urls[i].Groups[1].Value; }

                if (msg is not null)
                {
                    dataPublicacao = msg.DateEnvio.ToString("dd/MM/yyyy");
                    origem = msg.GrupoMsg.Nome;
                }

                //Arruma algumas coisas
                var isRemoto = remoto.Contains("Sim") || remoto.Contains("sim") ? true : false;
                funcao = string.IsNullOrEmpty(funcao) || funcao.ToLower().Contains("não informado") || funcao.ToLower().Contains("não especificado") ? "" : funcao;
                local = string.IsNullOrEmpty(local) || local.Contains("não informado") || local.ToLower().Contains("não especificado") ? "Brasil" : new BuscarCidade().buscaCidade(local);
                empresa = string.IsNullOrEmpty(empresa) || empresa.Contains("não informado") || empresa.ToLower().Contains("não especificado") ? "Confidencial" : empresa;
                email = string.IsNullOrEmpty(email) || email.ToLower().Contains("não informado") || email.ToLower().Contains("não especificado") ? "" : email;
                url = string.IsNullOrEmpty(url) || url.ToLower().Contains("não informado") || url.ToLower().Contains("não especificado") ? "" : url;
                descricao = Regex.Replace(descricao, @"\s+", " ", RegexOptions.IgnoreCase);
                salario = FormataSalario(salario);
                email = ValidaEmail(email);

                if (string.IsNullOrEmpty(local)) local = "Brasil";

                //Adiciona vaga se condições forem validas
                if (string.IsNullOrEmpty(funcao) || string.IsNullOrEmpty(descricao) || descricao.Contains("não informado"))
                    continue;
                else if (!string.IsNullOrEmpty(url))
                    jobs.Add(new Job(urlCandidatar: url, funcao, descricao, local, dataPublicacao, email: email, salario: salario, empresa: empresa, origem: origem, isRemoto: isRemoto));
                else if (!string.IsNullOrEmpty(email))
                    jobs.Add(new Job(email: email, funcao, descricao, local, dataPublicacao, salario: salario, empresa: empresa, origem: origem, isRemoto: isRemoto, urlCandidatar: url));
                else
                    continue;
            }

            return jobs;
        }

        public static void MostrarVagasObtidas(List<Job> vagas)
        {
            Console.WriteLine($"\n\nEncontramos {vagas.Count} vagas!!!");
            foreach (var vaga in vagas)
                Console.WriteLine(
                    $"\n+++++++++++++++++++ Vaga {vagas.IndexOf(vaga) + 1} +++++++++ Origem -> {vaga.Origem} +++++++++++++++++++\n" +
                    $"\nFUNCAO:\n\r     {vaga.Funcao}\n" +
                    $"\nDATA PUBLICACAO:\n\r     {vaga.DataPublicacao}\n" +
                    $"\nLOCALICAZAO:\n\r     {vaga.Localizacao}\n" +
                    $"\nHOME OFFICE:\n\r     {vaga.IsRemoto}\n" +
                    $"\nSALARIO:\n\r     {vaga.Salario}\n" +
                    $"\nEMPRESA:\n\r     {vaga.Empresa}\n" +
                    $"\nEMAIL:\n\r     {vaga.Email}\n" +
                    $"\nDESCRICAO:\n\r     {vaga.Descricao}\n" +
                    $"\nURL:\n\r     {vaga.UrlCandidatar}\n"
                    );
        }

        private static string FormataSalario(string txt)
        {
            txt = string.IsNullOrEmpty(txt) || txt.Contains("não informado") ? "0" : txt;
            var salario = Regex.Matches(txt, @"((sal[aáÁ]rio\s?:\s?|\$|R\$?\s?)(\d{3,5}\b|\d{1,2}.\d{3}\b))|((\d{3,5}|\d{1,2}.\d{3})(?=,\d{2}\b))", RegexOptions.IgnoreCase);
            List<int> values = new List<int>();
            foreach (var valor in salario)
            {
                string aux = Regex.Replace(valor.ToString(), @"\D", "");
                int num = int.Parse(aux);
                values.Add(num);

            }
            values.Add(0);
            var maxvalue = values.Max();
            string result = maxvalue.ToString();
            return result;
        }

        private static string ValidaEmail(string email)
        {
            const string EXPEMAIL = @"[\wÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç\.-]+(\+[\w-]*)?[ ]*@[ ]*\w+[ ]*([ \w-]+\.[ ]*)+[\w-]+";

            var mEspaco = Regex.Match(email, EXPEMAIL);

            if (mEspaco.Success)
            {
                email = (mEspaco.Value).ToLower();
                email = Regex.Replace(email, @"\s+", "");

                var mFinalEmail = Regex.Match(email, @"@.*([.](br|com|net|org))");
                var recebeEmail = Regex.Replace(email, "@.*", "");

                if (mFinalEmail.Success)
                    email = string.Concat(recebeEmail, mFinalEmail.Value);

                email = RemoveAcentuacao(email);
            }
            else
                email = string.Empty;

            return email;
        }

        private static string RemoveAcentuacao(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            var s = texto.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var t in s)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }

            return sb.ToString();
        }
    }
}
