using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Collections;

namespace System.WebX
{
    /// <summary>
    /// Credit here goes to Drew Noakes;
    /// http://stackoverflow.com/questions/3142495/deserialize-json-into-c-sharp-dynamic-object/3806407#3806407
    /// </summary>
    sealed class DynamicJsonConverter : JavaScriptConverter
    {
        static JavaScriptSerializer instance;

        /// <summary>
        /// Gets the instance of a JavaScriptSerializer using the DynamicJsonConverter.
        /// </summary>
        public static JavaScriptSerializer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaScriptSerializer();
                    instance.RegisterConverters(new[] { new DynamicJsonConverter() });
                }

                return instance;
            }
        }

        /// <summary>
        /// Deserializes the given dictionary.
        /// </summary>
        /// <param name="dictionary">The string object dictionary to use.</param>
        /// <param name="type">The type that is used as the target pattern.</param>
        /// <param name="serializer">The serializer instance.</param>
        /// <returns>The produced object.</returns>
        public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");

            return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
        }

        /// <summary>
        /// Serializes the given object to a list of key - value pairs.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="serializer">The serializer instance.</param>
        /// <returns>The produced key - value list.</returns>
        public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
        {
            var dic = new Dictionary<string, object>();
            var props = obj.GetType().GetProperties();

            foreach (var prop in props)
            {
                dic.Add(prop.Name, prop.GetValue(obj, null));
            }

            return dic;
        }

        /// <summary>
        /// Gets the list of supported types. This list does only contain the object Object.
        /// </summary>
        public override IEnumerable<Type> SupportedTypes
        {
            get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
        }

        #region Nested type: DynamicJsonObject

        private sealed class DynamicJsonObject : DynamicObject
        {
            readonly IDictionary<string, object> _dictionary;

            public DynamicJsonObject(IDictionary<string, object> dictionary)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");

                _dictionary = dictionary;
            }

            public override string ToString()
            {
                var sb = new StringBuilder("{");
                ToString(sb);
                return sb.ToString();
            }

            void ToString(StringBuilder sb)
            {
                var firstInDictionary = true;

                foreach (var pair in _dictionary)
                {
                    if (!firstInDictionary)
                        sb.Append(",");

                    firstInDictionary = false;
                    var value = pair.Value;
                    var name = pair.Key;

                    if (value is string)
                        sb.AppendFormat("{0}:\"{1}\"", name, value);
                    else if (value is IDictionary<string, object>)
                        new DynamicJsonObject((IDictionary<string, object>)value).ToString(sb);
                    else if (value is ArrayList)
                    {
                        sb.Append(name + ":[");
                        var firstInArray = true;

                        foreach (var arrayValue in value as ArrayList)
                        {
                            if (!firstInArray)
                                sb.Append(",");
                            firstInArray = false;

                            if (arrayValue is IDictionary<string, object>)
                                new DynamicJsonObject(arrayValue as IDictionary<string, object>).ToString(sb);
                            else if (arrayValue is string)
                                sb.AppendFormat("\"{0}\"", arrayValue);
                            else
                                sb.AppendFormat("{0}", arrayValue);

                        }

                        sb.Append("]");
                    }
                    else
                        sb.AppendFormat("{0}:{1}", name, value);
                }

                sb.Append("}");
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                if (!_dictionary.TryGetValue(binder.Name, out result))
                {
                    result = null;
                    return true;
                }

                var dictionary = result as IDictionary<string, object>;

                if (dictionary != null)
                {
                    result = new DynamicJsonObject(dictionary);
                    return true;
                }

                var arrayList = result as ArrayList;

                if (arrayList != null && arrayList.Count > 0)
                {
                    if (arrayList[0] is IDictionary<string, object>)
                        result = new List<object>(arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)));
                    else
                        result = new List<object>(arrayList.Cast<object>());
                }

                return true;
            }
        }

        #endregion
    }
}
