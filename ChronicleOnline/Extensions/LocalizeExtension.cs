using System;
using System.Collections.Generic;
using System.Text;
using ChronicleOnline.Services;

namespace ChronicleOnline.Extensions
{
    [ContentProperty(nameof(Key))]
    public class LocalizeExtension: BindableObject, IMarkupExtension<BindingBase>
    {
        public string? Key { get; set; }
        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {

            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Key}]",
                Source = LocalizationManager.Instance
            };
            return binding;
        }


        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) => ProvideValue(serviceProvider);
    }
}
