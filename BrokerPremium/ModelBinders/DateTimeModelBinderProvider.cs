using BrokerPremium.Core.Constants;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BrokerPremium.ModelBinders
{
    public class DateTimeModelBinderProvider : IModelBinderProvider
    {
        private readonly string dateTime;
        public DateTimeModelBinderProvider(string _dateTime)
        {
            dateTime = _dateTime;
        }

        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(DateTime) || context.Metadata.ModelType == typeof(DateTime?))
            {
                return new DateTimeModelBinder(dateTime);
            }

            return null;
        }
    }
}
