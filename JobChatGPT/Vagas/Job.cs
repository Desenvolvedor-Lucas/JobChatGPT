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
        public bool? IsRemoto { get; set; }

        public Job(string urlCandidatar, string funcao, string descricao, string localizacao, string dataPublicacao, string? email = null, string? salario = null, string? empresa = null, bool? isRemoto = null)
        {
            Funcao = funcao;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Localizacao = localizacao;
            UrlCandidatar = urlCandidatar;
            Email = email;
            Salario = salario;
            Empresa = empresa;
            IsRemoto = isRemoto;
        }

        //Para caso tenha somente e-mail
        public Job(string email, string funcao, string descricao, string localizacao, string dataPublicacao, string? salario = null, string? empresa = null, bool? isRemoto = null, string? urlCandidatar = null)
        {
            Funcao = funcao;
            Descricao = descricao;
            DataPublicacao = dataPublicacao;
            Localizacao = localizacao;
            UrlCandidatar = urlCandidatar;
            Email = email;
            Salario = salario;
            Empresa = empresa;
            IsRemoto = isRemoto;
        }

        public static Job? GetVagaConfig(string resposta)
        {
            //Pega os atributos por parte
            var funcao = Regex.Match(resposta, @"Função: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var descricao = Regex.Match(resposta, @"Descrição: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var local = Regex.Match(resposta, @"Localização: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var remoto = Regex.Match(resposta, @"Remoto: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var salario = Regex.Match(resposta, @"Salario: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var empresa = Regex.Match(resposta, @"Empresa: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var url = Regex.Match(resposta, @"Url Candidatar: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var email = Regex.Match(resposta, @"Email: (.+)", RegexOptions.IgnoreCase).Groups[1].Value;
            var dataPublicacao = DateTime.Now.ToString("dd/MM/yyyy");

            //Arruma algumas coisas
            var isRemoto = remoto.Contains("Sim") || remoto.Contains("sim") ? true : false;
            local = string.IsNullOrEmpty(local) || local.Contains("não informado") ? "Brasil" : new BuscarCidade().buscaCidade(local);
            empresa = string.IsNullOrEmpty(empresa) || empresa.Contains("não informado") ? "Confidencial" : empresa;
            email = string.IsNullOrEmpty(email) || email.Contains("não informado") ? "" : email;
            url = string.IsNullOrEmpty(url) || url.Contains("não informado") ? "" : url;
            descricao = Regex.Replace(descricao, @"\s+", " ", RegexOptions.IgnoreCase);
            salario = FormataSalario(salario);
            email = ValidaEmail(email);

            //Atribui vaga se condições forem validas
            if (string.IsNullOrEmpty(descricao) || descricao.Contains("não informado"))
                return null;
            else if (!string.IsNullOrEmpty(url))
                return new Job(urlCandidatar: url, funcao, descricao, local, dataPublicacao, email: email, salario: salario, empresa: empresa, isRemoto: isRemoto);
            else if (!string.IsNullOrEmpty(email))
                return new Job(email: email, funcao, descricao, local, dataPublicacao, salario: salario, empresa: empresa, isRemoto: isRemoto, urlCandidatar: url);
            else
                return null;
        }

        public static void MostrarVagasObtidas(List<Job> vagas)
        {
            Console.WriteLine($"\n\nEncontramos {vagas.Count} vagas!!!");
            foreach (var vaga in vagas)
                Console.WriteLine(
                    $"\n+++++++++++++++++++ Vaga {vagas.IndexOf(vaga) + 1} +++++++++++++++++++\n" +
                    $"\nFUNCAO:\n\r     {vaga.Funcao}\n" +
                    $"\nDATA PUBLICACAO:\n\r     {vaga.DataPublicacao}\n" +
                    $"\nLOCALICAZAO:\n\r     {vaga.Localizacao}\n" +
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
