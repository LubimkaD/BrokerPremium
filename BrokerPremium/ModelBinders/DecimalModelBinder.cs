using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace BrokerPremium.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName);
            if (value != ValueProviderResult.None && !String.IsNullOrEmpty(value.FirstValue))
            {
                decimal actualValue = 0;
                bool success = false;
                try
                {
                    string decValue = value.FirstValue;
                    decValue = decValue.Replace(".",
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",",
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    actualValue = Convert.ToDecimal(decValue, CultureInfo.CurrentCulture);
                    success = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);

                }
                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
