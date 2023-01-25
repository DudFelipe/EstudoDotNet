namespace EstudoDotNet
{
    public static class Configuration
    {
        //Token
        public static string JwtKey = "517d335c7e244dec96d118dab27a756b";
        public static string ApiKeyName = "api_key";
        public static string ApiKey = "curso_api";
        public static SmtpConfiguration Smtp = new();

        public class SmtpConfiguration
        {
            public string Host { get; set; }
            public int Port { get; set; } = 25;
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}