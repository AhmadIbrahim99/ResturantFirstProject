using System.Text;

namespace ResturantFirstProject.Extentions
{
    public static class CapitalizeExtention
    {
        public static double FromNIStoUSD = 3.5;
        public static string ToTitleCase(this string str)
        {
            str.ToLower();
            var listResult = str.Split();
            var sb = new StringBuilder();
            int count = 0;
            foreach (string item in listResult)
            {
                count++;
                for (int i = 0; i < item.Length; i++)
                {
                    if (i == 0)
                    {
                        sb.Append(char.ToUpper(item[i]));
                    }
                    else
                    {
                        sb.Append(item[i]);
                    }

                    if (i == item.Length - 1 && count != listResult.Length)
                    {
                        sb.Append(' ');
                    }
                }
            }
            str = sb.ToString();
            return str;
        }
    }
}
