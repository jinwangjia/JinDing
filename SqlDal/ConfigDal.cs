using Microsoft.EntityFrameworkCore;
using Model;
using System;

namespace SqlDal
{
    public class ConfigDal:ParentDal<ConfigDefinition>
    {
        public string GetValue(string configName, string defaultValue)
        {
            if (string.IsNullOrEmpty(defaultValue))
            {
                throw new Exception(string.Format("配置项{0}不能为空", configName));
            }

            using (var dal = new BaseDal())
            {
                var p = dal.Config.Find(configName);
                if (p == null)
                {
                    dal.Config.Add(new ConfigDefinition() { Name = configName, Value = defaultValue, Comment = "" });
                    dal.SaveChanges();
                    return defaultValue;
                }
                else
                {
                    if (string.IsNullOrEmpty(p.Value))
                    {
                        throw new Exception(string.Format("配置项{0}不能为空", p.Name));
                    }
                    return p.Value;
                }
            }
        }

        public int GetValue(string configName, int defaultValue)
        {
            var value = GetValue(configName, defaultValue.ToString());
            return Convert.ToInt32(value);
        }

        public bool GetValue(string configName, bool defaultValue)
        {
            var value = GetValue(configName, defaultValue.ToString());
            return Convert.ToBoolean(value);
        }

        public void SetValue(string configName, string value)
        {
            GetValue(configName, value);
            using (var dal = new BaseDal())
            {
                var p = dal.Config.Find(configName);
                p.Value = value;
                dal.Entry(p).State = EntityState.Modified;
                dal.SaveChanges();
            }
        }

    }
}
