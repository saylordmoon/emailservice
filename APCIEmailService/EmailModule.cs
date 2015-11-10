using Nancy.ModelBinding;
using Nancy;

namespace APCIEmailService
{
    public class EmailModule : Nancy.NancyModule
    {
        public EmailModule()
        {
            Get["/"] = index;
            Post["/"] = post;
            Post["/mail"] = email;
        }

        private dynamic index(dynamic args)
        {
            return "APCI Mail Service";
        }

        private dynamic email(dynamic args)
        {
            EmailData data = this.Bind<EmailData>();
            Email mail = new Email();
            mail.send(data);
            return Negotiate.WithModel(data).WithStatusCode(HttpStatusCode.OK);

        }

        private dynamic post(dynamic args)
        {
            EmailData data = this.Bind<EmailData>();
            Email mail = new Email();
            mail.send(data);
            return Negotiate.WithModel(data).WithStatusCode(HttpStatusCode.OK);
        }
    }
}
