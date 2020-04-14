using System.Linq;
using System.Reflection;

namespace MPESACallbackDeserialization.Models
{
    /// <summary>
    /// The actual callback received from Safaricom.
    /// </summary>
    public class CallbackResponse
    {
        public Result Result { get; set; }

        /// <summary>
        /// Generates the generic type from <see cref="ResultParameters"/>
        /// </summary>
        /// <typeparam name="T">The type of object to generate from parameters.</typeparam>
        /// <returns>The object generated.</returns>
        public T FromParameters<T>() where T : new()
        {
            T concreteT = new T();
            var resultsParameters = Result.ResultParameters.ResultParameter;
            if (resultsParameters is null) return default;
            foreach (PropertyInfo prop in concreteT.GetType().GetProperties())
            {
                var sourceValue = resultsParameters.FirstOrDefault(pair => pair.Key.ToLower() == prop.Name.ToLower());
                if (sourceValue != null && prop.CanWrite)
                {
                    if (prop.PropertyType.Name == "Decimal")
                    {
                        if (decimal.TryParse(sourceValue.Value, out decimal decimalValue))
                        {
                            prop.SetValue(concreteT, decimalValue);
                        }
                        else
                        {
                            prop.SetValue(concreteT, sourceValue.Value);
                        }

                    }
                    else if (prop.PropertyType.Name == "Double")
                    {
                        if (double.TryParse(sourceValue.Value, out double doubleValue))
                        {
                            prop.SetValue(concreteT, doubleValue);
                        }
                        else
                        {
                            prop.SetValue(concreteT, sourceValue.Value);
                        }

                    }
                    else
                    {
                        prop.SetValue(concreteT, sourceValue.Value);
                    }
                }
            }
            return concreteT;
        }

        public override string ToString()
        {
            try
            {
                return $"{Result.TransactionID} ({Result.ResultDesc})";
            }
            catch (System.Exception)
            {
                return base.ToString();
            }
        }
    }
}
