using System;
using System.Linq;
using System.Text;

namespace LeadX.NET.Helpers
{
    /// <summary>
    /// Contain the Helper method related to Http Request.
    /// </summary>
    public static class RequestHelper
    {
        /// <summary>
        /// Get the Query string from a Query Object.
        /// </summary>
        /// <param name="param">Instance of Query Object.</param>
        /// <returns>Returns a query string.</returns>
        public static string PrepareQueryParams(object param)
        {
            var properties = param.GetType().GetProperties();

            // Check if Object contain any Properties
            if (!properties.Any()) return "";

            var queryString = new StringBuilder("?");

            // Only Read the Property which has implement getter { get; }
            foreach (var property in properties.Where(p => p.CanRead))
            {
                var propValue = property.GetValue(param);
                var valueType = propValue?.GetType();

                // Skip if Value of Property is NULL
                if (valueType is null) continue;

                var defaultInstance = GetDefault(valueType);

                // Skip if Value Type has default value
                if (Equals(propValue, defaultInstance)) continue;

                queryString.Append($"{property.Name}={property.GetValue(param)}&");
            }

            // Remove the last '&' from the queryString
            queryString.Remove(queryString.Length - 1, 1);
            
            return queryString.ToString();
        }

        private static object GetDefault(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }
    }
}
