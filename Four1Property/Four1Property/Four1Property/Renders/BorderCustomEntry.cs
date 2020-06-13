using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Four1Property.Renders
{
    public class BorderCustomEntry : Entry
    {
        public BorderCustomEntry()
        {
        }

        public static readonly BindableProperty BorderColorProperty =
        BindableProperty.Create(nameof(BorderColor),
          typeof(Color), typeof(CustomEntry), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(nameof(BorderWidth), typeof(int),
            typeof(CustomEntry), null);
        // Gets or sets BorderWidth value  
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty RProperty =
        BindableProperty.Create(nameof(red),
            typeof(int), typeof(CustomEntry), null);
        // Gets or sets CornerRadius value  
        public int red
        {
            get => (int)GetValue(RProperty);
            set => SetValue(RProperty, value);
        }

        public static readonly BindableProperty GProperty =
        BindableProperty.Create(nameof(green),
            typeof(int), typeof(CustomEntry), null);
        // Gets or sets CornerRadius value  
        public int green
        {
            get => (int)GetValue(GProperty);
            set => SetValue(GProperty, value);
        }


        public static readonly BindableProperty BProperty =
        BindableProperty.Create(nameof(blue),
            typeof(int), typeof(CustomEntry), null);
        // Gets or sets CornerRadius value  
        public int blue
        {
            get => (int)GetValue(BProperty);
            set => SetValue(BProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius),
            typeof(float), typeof(CustomEntry), null);
        // Gets or sets CornerRadius value  
        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
        BindableProperty.Create(nameof(IsCurvedCornersEnabled),
            typeof(bool), typeof(CustomEntry), true);
        // Gets or sets IsCurvedCornersEnabled value  
        public bool IsCurvedCornersEnabled
        {
            get => (bool)GetValue(IsCurvedCornersEnabledProperty);
            set => SetValue(IsCurvedCornersEnabledProperty, value);
        }
    }
}
