using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MicroART.NTFX.Models
{
    public class AppStorageProvider
    {
        public Dictionary<string, string> StringStorage = new Dictionary<string, string>();
        public Dictionary<string, object> ObjectStorage = new Dictionary<string, object>();
        public List<object> MiscellaneousStorage = new List<object>();

        public T GetObject<T>(string key)
        {
            object value = null;
            if (ObjectStorage.TryGetValue(key, out value))
            {
                return (T)value;
            }
            else return default(T);
        }

        public bool StoreObject(string key, object blob)
        {
            try
            {
                ObjectStorage.Add(key, blob);
                return true;
            }
            catch (Exception) { return false; }
        }

        public string GetString(string key)
        {
            string value = null;
            if (StringStorage.TryGetValue(key, out value))
            {
                return value;
            }
            else return null;
        }

        public bool StoreString(string key, string value)
        {
            try
            {
                StringStorage.Add(key, value);
                return true;
            }
            catch (Exception) { return false; }
        }
    }
}
