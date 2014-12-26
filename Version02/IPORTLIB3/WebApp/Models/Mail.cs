namespace WebApp.Models
{
    public class Mail
    {
        public string To { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}