using FirmaMAUI.ViewModels.Base;
using FirmaMAUI.ViewModels.Client;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FirmaMAUI.Pages.Controls;

public partial class RUVFase1 : ContentView
{

    //public static readonly BindableProperty JsonProperty =
    //        BindableProperty.Create(nameof(Json), typeof(string), typeof(RUVFase1));

    //public static readonly BindableProperty IsFanProperty =
    //       BindableProperty.Create(nameof(IsFan), typeof(bool), typeof(QuantityStepper), defaultValue: false);

    //public static readonly BindableProperty MaximumProperty =
    //   BindableProperty.Create(nameof(Maximum), typeof(int), typeof(QuantityStepper), defaultValue: 99);

    //public string Json
    //{
    //    get { 
    //        return (string)GetValue(JsonProperty);
    //    }
    //    set { SetValue(JsonProperty, value); }
    //}

    private List<VisualElement> _visualElement;
    public RUVFase1()
	{
		InitializeComponent();
        ViewModelBase viewModel = BindingContext as ViewModelBase;
        _ = viewModel.InitializeAsync(null);
        GenerarCampos();
    }

    

   
    private void GenerarCampos()
    {
        _visualElement = new List<VisualElement>();
        string json = ViewModelLocator.Resolve<RuvViewModel>().JsonFase1;
        if (json != null)
        {
            Frame frame = new()
            {
                Margin = new Thickness(25, 25, 25, 15),
                CornerRadius = 10,
                BorderColor = Colors.LightGray,
                BackgroundColor = Colors.White,
            };
            Frame frame2 = new()
            {
                Margin = new Thickness(10, 0, 10, 5),
                CornerRadius = 10,
                BorderColor = Colors.Gray,
                BackgroundColor = Colors.White,
                StyleId = "frameExist"
            };
            StackLayout layout = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 10, 10, 10) };
            StackLayout layout2 = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 10, 10, 10) };
            foreach (var items in JArray.Parse(json))
            {
                layout.Children.Add(new Label { Text = (string)items["label"] });
                switch ((string)items["type"])
                {
                    case "DatePiker":
                        layout.Children.Add(new DatePicker { Format = "d", Date = DateTime.Now });
                        break;
                    case "Entry":
                        Frame frame3 = new()
                        {
                            Margin = new Thickness(0, 10, 0, 10),
                            Padding = new Thickness(0, 0,0,0),
                            CornerRadius = 5,
                            BorderColor = Colors.LightGray,
                            BackgroundColor = Colors.LightGray,
                            HeightRequest = 50,
                            IsClippedToBounds = true,
                        };

                        StackLayout layout3 = new() { Margin = new Thickness(10,5,10,10)};
                        layout3.Children.Add(new Entry { Placeholder = (string)items["label"], Keyboard = Keyboard.Chat, TextColor = Colors.Black, PlaceholderColor = Colors.Gray });
                        frame3.Content = layout3;
                        layout.Children.Add(frame3);
                        break;
                    case "radioButtom":
                        RadioButton radioButton1 = new RadioButton
                        {
                            Content = "Si",
                            GroupName = "group1",
                        };

                        RadioButton radioButton2 = new RadioButton
                        {
                            Content = "No",
                            GroupName = "group1",
                        };

                        var isTrue = (string)items["isTrue"] != null && (string)items["isTrue"] == "true";
                        radioButton1.IsChecked = isTrue;
                        radioButton2.IsChecked = !isTrue;
                        radioButton1.CheckedChanged += RadioButton_CheckedChanged;
                        radioButton2.CheckedChanged += RadioButton_CheckedChanged;
                        layout.Children.Add(radioButton1);
                        layout.Children.Add(radioButton2);
                        if (isTrue)
                        {
                            layout2.Children.Add(new Label { Text = "Si Existe" });
                            layout2.Children.Add(new Entry { Placeholder = "Campo", Keyboard = Keyboard.Chat });

                        }
                        break;

                }
            }
            frame.Content = layout;
            StackLayout views = new()
            {
                Children = { frame }
            };
            if (layout2.Children.Count() > 0)
            {
                _visualElement.Add(frame2);
                frame2.Content = layout2;
                views.Children.Add(frame2);
            }
            Content = views;
        }
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && e.Value)
        {
            // Manejar el evento aquí
            var selectedOption = radioButton.Content.ToString();
            if (selectedOption.ToLower() == "no")
            {
                var frame = (Frame)_visualElement.FirstOrDefault(x => x.StyleId == "frameExist");
                if(frame != null)
                {
                    frame.IsVisible = false;
                }
            }
            else
            {
                var frame = (Frame)_visualElement.FirstOrDefault(x => x.StyleId == "frameExist");
                if (frame != null)
                {
                    frame.IsVisible = true;
                }
            }
        }
    }
}