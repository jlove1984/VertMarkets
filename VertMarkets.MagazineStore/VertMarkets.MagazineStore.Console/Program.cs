

namespace VertMarkets.MagazineStore.Console
{
    using System.Threading.Tasks;
    using VertMarkets.MagazineStore.Core.Interfaces;
    using VertMarkets.MagazineStore.Core.Services;
    class Program
    {
        static async Task Main(string[] args)
        {
            System.Console.WriteLine("View ReadMe for a list of commands");
            var cmd = System.Console.ReadLine();
            while (cmd != Commands.EXIT)
            {
                IMagazineService service = new MagazineService();
                API.Model.ApiResponse<API.Model.AnswerResponse> response = null;
                switch (cmd.Trim())
                {
                    case Commands.EXIT:
                        break;                    
                    case Commands.RUN:
                        response = service.Challenge();
                        System.Console.WriteLine(response.ToString());
                        break;
                    case Commands.RUNASYNC:
                        response = await service.ChallengeAsync();
                        System.Console.WriteLine(response.ToString());
                        break;
                    case Commands.HELP:
                    default:
                        break;
                }
                cmd = System.Console.ReadLine();
            }
        }  
        
        struct Commands
        {
            /// <summary>
            /// This will exit the program
            /// </summary>
            public const string EXIT = "-x";
            /// <summary>
            /// This will display a list of available commands 
            /// </summary>
            public const string HELP = "-h";
            /// <summary>
            /// This will make a set of synchronous requests to complete the VertMarkets Programming Challenge
            /// </summary>
            public const string RUN = "-r";
            /// <summary>
            /// This will make a set of asynchronous requests to complete the VertMarkets Programming Challenge
            /// </summary>
            public const string RUNASYNC = "-ra";
        }
    }
}
