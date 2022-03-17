namespace SimpleLibraryProject.Encryption
{
    public class EncryptionBuilder
    {
        public static async Task<string> OverEncrypt(string input, string key, string salt, int overtime)
        {
            string currentval = input;
            for (int i = 0; i < overtime; i++)
            {
                currentval = currentval + await SimpleEncrypt(currentval, key, salt);
            }

            return currentval.Replace(input, "");
        }
        
        public static async Task<string> SimpleEncrypt(string input, string key, string salt)
        {
            List<char> blocksL = new();
            List<char> keyb = new();
            foreach (char blk in input)
            {
                blocksL.Add(blk);
            }

            foreach (char val in key)
            {
                keyb.Add(val);
            }

            char[] blocks = blocksL.ToArray();
            char[] kb = keyb.ToArray();

            List<char> one = new();
            List<char> two = new();
            List<char> three = new();
            List<char> four = new();

            for (int i = 0; i < kb.Length; i++)
            {
                if (kb[i] == '1')
                {
                    one.Add(blocks[i]);
                }

                if (kb[i] == '2')
                {
                    two.Add(blocks[i]);
                }

                if (kb[i] == '3')
                {
                    three.Add(blocks[i]);
                }

                if (kb[i] == '4')
                {
                    four.Add(blocks[i]);
                }
            }
            
            string lastval = "";
                
            foreach (char val in one)
            {
                lastval = lastval + val;
            }                
                
            foreach (char val in two)
            {
                lastval = lastval + val;
            }                
                
            foreach (char val in three)
            {
                lastval = lastval + val;
            }                
                
            foreach (char val in four)
            {
                lastval = lastval + val;
            }

            string ret = "";
            for (int i = 0; i < salt.Length; i++)
            {
                ret = ret + lastval[i] + salt[i];
            }
            
            return ret;
        }
    }
}