using Framework.Authentication;

namespace Framework
{
    public class Credentials
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public AuthenticationType AuthenticationType { get; private set; }
        public static readonly Credentials Annonymous  = new Credentials();

        public Credentials()
        {
            AuthenticationType = AuthenticationType.Anonymous;
        }

        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
            AuthenticationType = AuthenticationType.Standard;
        }
    }
}