using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmaMAUI.Renders
{
    public class MyEntry : Entry
    {
        public static readonly BindableProperty BorderColorProperty = 
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(Entry),
                Colors.Gray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty =
        BindableProperty.Create(
            nameof(BorderWidth),
            typeof(int),
            typeof(MyEntry));

        // Gets or sets BorderWidth value
        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(
            nameof(CornerRadius),
            typeof(double),
            typeof(MyEntry));

        // Gets or sets CornerRadius value
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IsCurvedCornersEnabledProperty =
        BindableProperty.Create(
            nameof(IsCurvedCornersEnabled),
            typeof(bool),
            typeof(MyEntry),
            true);

        // Gets or sets IsCurvedCornersEnabled value
        public bool IsCurvedCornersEnabled
        {
            get { return (bool)GetValue(IsCurvedCornersEnabledProperty); }
            set { SetValue(IsCurvedCornersEnabledProperty, value); }
        }

        public static readonly BindableProperty EnabledColorProperty = BindableProperty.Create(nameof(EnabledColor), typeof(bool), typeof(MyEntry), false);

        public static readonly BindableProperty IsAlertActivoProperty = BindableProperty.Create(nameof(IsAlertActivo), typeof(bool), typeof(MyEntry), false);
        public static readonly BindableProperty NombreProperty = BindableProperty.Create(nameof(IsAlertActivo), typeof(String), typeof(MyEntry), default);

        public bool IsAlertActivo
        {
            get { return (bool)GetValue(IsCurvedCornersEnabledProperty); }
            set { SetValue(IsCurvedCornersEnabledProperty, value); }
        }

        public bool EnabledColor
        {
            get 
            {
               
                return (bool)GetValue(EnabledColorProperty); 
            }
            set { SetValue(EnabledColorProperty, value); }
        }

        public String Nombre
        {
            get { return (String)GetValue(NombreProperty); }
            set { SetValue(NombreProperty, value); }
        }

        public MyEntry()
        {
          
//                Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(MyEntry), (handler, view) =>
//                {
//#if __ANDROID__
//                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
//#elif __IOS__
//                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
//                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

//#endif
//                });
            
        }
    }
}
