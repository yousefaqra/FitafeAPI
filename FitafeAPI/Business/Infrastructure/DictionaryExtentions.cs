using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FitafeAPI.Business.Infrastructure
{
    public static class DictionaryExtentions
    {
        public static void Add(
            this Dictionary<string, List<string>> dic,
            string key,
            string value)
        {
            if (dic.ContainsKey(key))
            {
                if (dic[key].All(s => s != value))
                    dic[key].Add(value);
            }
            else
            {
                dic.Add(key, new List<string>
                {
                    value
                });
            }
        }

        public static void Add(
            this Dictionary<string, List<string>> dic,
            string key,
            List<string> list)
        {
            foreach (var str in list)
                Add(dic, key, str);
        }

        public static void Add(
            this Dictionary<string, List<string>> dic,
            Dictionary<string, List<string>> valueDictionary)
        {
            foreach (var key in valueDictionary.Keys)
                Add(dic, key, valueDictionary[key]);
        }

        public static ReadOnlyDictionary<TKey, TValue> ToReadonlyDictionary<TKey, TValue>(this Dictionary<TKey, TValue> dic)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dic);
        }
    }
}
