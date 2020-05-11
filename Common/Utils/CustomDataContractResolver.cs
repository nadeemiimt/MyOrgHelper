using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Common.Utils
{
    public class CustomDataContractResolver : DefaultContractResolver
    {
        private readonly string propertyNewName;
        private readonly string propertyOldName;
        private readonly Type objectType;
        public CustomDataContractResolver()
        {
            this.propertyNewName = string.Empty;
            this.propertyOldName = string.Empty;
            this.objectType = typeof(CustomDataContractResolver);
        }

        public CustomDataContractResolver(Type type,  string propertyOldName, string propertyNewName)
        {
            this.propertyNewName = propertyNewName;
            this.propertyOldName = propertyOldName;
            this.objectType = type;
        }
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (!string.IsNullOrWhiteSpace(propertyOldName) && !string.IsNullOrWhiteSpace(propertyNewName))
            {
                if (property.DeclaringType == objectType)
                {
                    if (property.PropertyName.Equals(propertyOldName, StringComparison.OrdinalIgnoreCase))
                    {
                        property.PropertyName = propertyNewName;
                    }
                }
            }

            return property;
        }
    }
}
