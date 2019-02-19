using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace EntidadBancaria.Framework
{
    public static class ListExtensions
    {
        public static SelectList ToSelectList<T>(this T enumeration, string selected, bool isDisplay = false, IEnumerable<T> excludes = null)
        {
            var source = Enum.GetValues(typeof(T));
            var items = new Dictionary<object, string>();
            var displayAttributeType = typeof(DisplayAttribute);

            foreach (var value in source)
            {
                if (excludes != null && excludes.Contains((T)value))
                {
                    continue;
                }
                if (isDisplay)
                {
                    var field = value.GetType().GetField(value.ToString());

                    var attrs = (DisplayAttribute)field.
                                  GetCustomAttributes(displayAttributeType, false).First();
                    items.Add(Convert.ToInt32(value), attrs.Name);
                }
                else
                {
                    items.Add(Convert.ToInt32(value), value.ToString());
                }
            }
            return new SelectList(items, "Key", "Value", selected);
        }
        public static IEnumerable<SelectListItem> ToSelectListItem<T>(this T enumeration, bool isDisplay = false)
        {
            var source = Enum.GetValues(typeof(T));

            //var items = new  Dictionary<object, string>();
            var items = new List<SelectListItem>();

            var displayAttributeType = typeof(DisplayAttribute);

            foreach (var value in source)
            {
                if (isDisplay)
                {
                    var field = value.GetType().GetField(value.ToString());

                    var attrs = (DisplayAttribute)field.
                                  GetCustomAttributes(displayAttributeType, false).First();
                    items.Add(new SelectListItem
                    {
                        Value = Convert.ToInt32(value).ToString(),
                        Text = attrs.Name
                    });
                }
                else
                {
                    items.Add(new SelectListItem
                    {
                        Text = value.ToString(),
                        Value = Convert.ToInt32(value).ToString()
                    });
                }
            }
            return items;
        }

        public static string GetDisplayName<T>(this T enumeration)
        {
            var displayAttributeType = typeof(DisplayAttribute);
            var field = enumeration.GetType().GetField(enumeration.ToString());
            if (field == null) return enumeration.ToString();
            var attrs = (DisplayAttribute)field.
                          GetCustomAttributes(displayAttributeType, false).First();
            return attrs.Name;
        }
        public static void AddRange<T, TS>(this Dictionary<T, TS> source, Dictionary<T, TS> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (var item in collection.Where(item => !source.ContainsKey(item.Key)))
            {
                source.Add(item.Key, item.Value);
            }
        }
    }
}
