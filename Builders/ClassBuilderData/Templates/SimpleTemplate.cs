namespace SimpleLibraryProject.Builders.ClassBuilderData.Templates
{
    public class SimpleTemplate
    {
        public static List<string> BuildTemplate()
        {
            List<string> ret = new();
            ret.Add("<IMPORTREGION>");
            ret.Add("namespace <REPLACEME>");
            ret.Add("{");
            ret.Add("   public class <REPLACEME>");
            ret.Add("   {");
            ret.Add("       <VALUEREGION>");
            ret.Add("");
            ret.Add("       public <REPLACEME>(<ENTER VALUES>)");
            ret.Add("       {");
            ret.Add("           <CONSTRUCTORREGION>");
            ret.Add("       }");
            ret.Add("   }");
            ret.Add("}");

            return ret;
        }
    }
}