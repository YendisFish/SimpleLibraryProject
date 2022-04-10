using SimpleLibraryProject.Processing.Types;

namespace SimpleLibraryProject.Processing
{
    public class SOTryCatch<T>
    {
        public static async Task<T> Execute(Func<T> func)
        {
            try
            {
                T ret = func();
                return ret;
            }
            catch (Exception ex)
            {
                ProcessInput inp = new ProcessInput("firefox", $"https://stackoverflow.com/search?q={ex.Message.ToString()}");
                await Handlers.ProcessHandler.Execute(inp);
            }

            return default;
        }
    }

    public class SOTryCatch
    {
        public static async Task Execute(Action func)
        {
            try
            {
                func();
            }
            catch (Exception ex)
            {
                ProcessInput inp = new ProcessInput("firefox", $"https://stackoverflow.com/search?q={ex.Message.ToString()}");
                await Handlers.ProcessHandler.Execute(inp);
            }
        }
    }
}