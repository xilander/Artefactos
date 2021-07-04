namespace Extensiones.Models
{
    public class MailSettings
    {
        public string EmailFromAddress { get; set; }
        public string NameFrom { get; set; }
        public string MailAuthUser { get; set; }
        public string MailAuthPass { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
