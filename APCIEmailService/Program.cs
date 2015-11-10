using Topshelf;


namespace APCIEmailService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>                                    //1
            {
                x.Service<APCIService>(s =>                       //2
                {
                    s.ConstructUsing(name => new APCIService());  //3
                    s.WhenStarted(tc => tc.Start());                //4
                    s.WhenStopped(tc => tc.Stop());                 //5
                });

                //x.UseLog4Net();
                x.RunAsLocalSystem();                               //6
                x.SetDescription("APCI Mail Service");           //7
                x.SetDisplayName("APCI Mail Service");                          //8
                x.SetServiceName("APCIMailService");                          //9

            });               
        }
    }
}
