
using Task_1___Bunnies.Engine;

namespace Bunnies
{
    public class BunniesStartUp
    {
        public static void Main()
        {
            var bunniesEngine = new BunniesEngine();

            var bunniesList = bunniesEngine.CreateListOfBunnies();
            var bunniesWriter = bunniesEngine.CreateConsoleWriter();

            bunniesEngine.IntroduceBunnies(bunniesList, bunniesWriter);

            var bunniesSavingLocation = @"..\..\bunnies.txt";

            bunniesEngine.CreateFileForSaving(bunniesSavingLocation);

            bunniesEngine.SaveBunniesToFile(bunniesSavingLocation, bunniesList, bunniesWriter);

            // bunniesEngine.SaveBunniesToFile(@"invalid location\invalidfile.txt", bunniesList, bunniesWriter);
        }
    }
}
