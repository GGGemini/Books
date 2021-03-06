using System.Linq;

namespace Books.Helpers
{
    public static class StringHelper
    {
        public static string GetShortName(string surname, string name, string patronymic)
        {
            return $"{surname} {name.FirstOrDefault()}. {patronymic.FirstOrDefault()}.";
        }
    }
}
