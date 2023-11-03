using FirmaMAUI.ViewModels.Base;
using FirmaMAUI.ViewModels.Client;
using Newtonsoft.Json.Linq;

namespace FirmaMAUI.Pages.Controls;

public partial class RUVFase2 : ContentView
{

    private List<VisualElement> _visualElement;
    public RUVFase2()
	{
		InitializeComponent();
        ViewModelBase viewModel = BindingContext as ViewModelBase;
        _ = viewModel.InitializeAsync(null);
        GenerarCampos();
    }

    private void GenerarCampos()
    {
        ViewModelLocator.Resolve<RuvViewModel>().LoadJsonFase2();
        string json = ViewModelLocator.Resolve<RuvViewModel>().JsonFase2;
        if(json != null)
        {
            Frame frameFinal = new()
            {
                Margin = new Thickness(25, 25, 25, 15),
                CornerRadius = 10,
                BorderColor = Colors.LightGray,
                BackgroundColor = Colors.White,
            };

            StackLayout layoutFinal = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 10, 10, 10) };

            foreach (var items in JArray.Parse(json))
            {
                layoutFinal.Children.Add(new Label { Text = (string)items["label"] });
                switch ((string)items["type"])
                {
                    case "DatePiker":
                        layoutFinal.Children.Add(new DatePicker { Format = "d", Date = DateTime.Now });
                        break;
                    case "Entry":
                        Frame frame3 = new()
                        {
                            Margin = new Thickness(0, 10, 0, 10),
                            Padding = new Thickness(0, 0, 0, 0),
                            CornerRadius = 5,
                            BorderColor = Colors.LightGray,
                            BackgroundColor = Colors.LightGray,
                            HeightRequest = 50,
                            IsClippedToBounds = true,
                        };

                        StackLayout layout3 = new() { Margin = new Thickness(10, 5, 10, 10) };
                        layout3.Children.Add(new Entry { Placeholder = (string)items["label"], Keyboard = Keyboard.Chat, TextColor = Colors.Black, PlaceholderColor = Colors.Gray });
                        frame3.Content = layout3;
                        layoutFinal.Children.Add(frame3);
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
                        layoutFinal.Children.Add(radioButton1);
                        layoutFinal.Children.Add(radioButton2);
                      
                        break;

                }
            }

            frameFinal.Content = layoutFinal;
            Content = frameFinal;
        }
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && e.Value)
        {
            // Manejar el evento aquí
          
        }
    }
}