namespace SimpleLibraryProject.Processing
{
    public class FileManager
    {
        public static async Task<FileInfo> FindFile(DirectoryInfo dir, string Filename, bool output = false)
        {
            if (dir?.GetDirectories() is not null)
            {
                foreach (DirectoryInfo directory in dir?.GetDirectories())
                {
                    try
                    {
                        if (directory?.GetFiles().Where(x => x.FullName.Contains(Filename)) is not null)
                        {
                            try
                            {
                                foreach (FileInfo file in directory.GetFiles().Where(x => x.FullName.Contains(Filename)))
                                {
                                    return file;
                                }
                            }
                            catch (Exception ex)
                            {
                                if (output is not false)
                                {
                                    Console.WriteLine("Didn't find file in " + directory.FullName);
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        if (output is not false)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    if (directory?.GetDirectories() is not null)
                    {
                        FileInfo ret = await FindFile(directory, Filename, output);
                        return ret;
                    }
                }
            }
            else
            {
                foreach (FileInfo file in dir?.GetFiles())
                {
                    if (file.FullName.Contains(Filename))
                    {
                        return file;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }
    }
}