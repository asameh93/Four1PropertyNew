using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Four1Property.Renders
{
    public class RoundedLabel:Label
    {
        public static readonly BindableProperty CurvedCornerRadiusProperty =
         BindableProperty.Create(nameof(CurvedCornerRadius), typeof(double),
                                 typeof(RoundedLabel), 15.0);
        public double CurvedCornerRadius
        {
            get { return (double)GetValue(CurvedCornerRadiusProperty); }
            set { SetValue(CurvedCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CurvedBackgroundColorProperty =
            BindableProperty.Create(
                nameof(CurvedBackgroundColor),
                typeof(Color),
                typeof(RoundedLabel),
                Color.Default);
        public Color CurvedBackgroundColor
        {
            get { return (Color)GetValue(CurvedBackgroundColorProperty); }
            set { SetValue(CurvedBackgroundColorProperty, value); }
        }
    }
}
