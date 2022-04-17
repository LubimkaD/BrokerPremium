using BrokerPremium.Core.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace BrokerPremium.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {   
        private readonly string dateFormat;

        public DateTimeModelBinder(string _dateFormat)
        {
            dateFormat = _dateFormat;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult value = bindingContext
                .ValueProvider
                .GetValue(bindingContext.ModelName);
            if (value != ValueProviderResult.None && !String.IsNullOrEmpty(value.FirstValue))
            {
                DateTime actualValue = DateTime.MinValue;
                bool success = false;
                string dateValue = value.FirstValue;

                try
                {

                    actualValue = DateTime.ParseExact(dateValue, dateFormat,
                        CultureInfo.InvariantCulture);
                    success = true;
                }
                catch (FormatException)
                {
                    try
                    {
                        actualValue = DateTime.Parse(dateValue, new CultureInfo("bg-bg"));
                    }
                    catch (Exception e)
                    {

                        bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
                    }

                }
                catch (Exception e)
                {

                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, e, bindingContext.ModelMetadata);
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
