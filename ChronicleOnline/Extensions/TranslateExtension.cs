using ChronicleOnline.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace ChronicleOnline.Extensions
{
    [ContentProperty(nameof(Key))]
    public class TranslateExtension:IMarkupExtension<BindingBase>
    {
        public string Key { get; set; } = string.Empty;

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Key))
                return new Binding();

            return new Binding(
                path: $"[{Key}]",
                mode: BindingMode.OneWay,
                source: LocalizationResouceManager.Instance);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider) =>
            ProvideValue(serviceProvider);
    }
}
