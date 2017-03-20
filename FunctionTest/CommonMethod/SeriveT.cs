using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace CommonMethod
{
    public class SeriveT
    {
        public T Clone<T>()
        {
            object obj = typeof(T).Assembly.CreateInstance(typeof(T).ToString());
            foreach (PropertyInfo p in this.GetType().GetProperties())
            {
                try
                {
                    PropertyInfo curProperty = obj.GetType().GetProperty(p.Name);
                    if (curProperty.CanWrite)
                    {

                        if (p.PropertyType.IsGenericType)
                        {
                            if (p.PropertyType.GetGenericTypeDefinition().Name == "IList`1" || p.PropertyType.GetGenericTypeDefinition().Name == "List`1")
                            {
                                Type ilistType = (typeof(List<>)).MakeGenericType(p.PropertyType.GetGenericArguments());
                                IList lstObj = (IList)Activator.CreateInstance(ilistType);

                                IEnumerable lst = (IEnumerable)p.GetValue(this, null);
                                if (lst != null)
                                {
                                    foreach (object item in lst)
                                    {

                                        lstObj.Add(item);

                                    }
                                }
                                curProperty.SetValue(obj, lstObj, null);
                            }
                        }
                        else
                        {
                            curProperty.SetValue(obj, p.GetValue(this, null), null);
                        }

                    }
                }
                catch (Exception exception)
                {

                }
            }
            return (T)obj;
        }
    }

}
