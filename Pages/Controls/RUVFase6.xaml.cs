using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using FirmaMAUI.Models;
using FirmaMAUI.Renders;
using FirmaMAUI.ViewModels.Base;
using FirmaMAUI.ViewModels.Client;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace FirmaMAUI.Pages.Controls;

public partial class RUVFase6 : ContentView
{

    private List<VisualElement> _visualElement;
    public RUVFase6()
	{
		InitializeComponent();
        ViewModelBase viewModel = BindingContext as ViewModelBase;
        _ = viewModel.InitializeAsync(null);
        GenerarCampos();
    }


    private void GenerarCampos()
    {
        try
        {
            _visualElement = new List<VisualElement>();
            List<TiposVacunacionEtareas> tiposVacunacionEtareas = new();
            ViewModelLocator.Resolve<RuvViewModel>().LoadJson6();
            string json = ViewModelLocator.Resolve<RuvViewModel>().JsonFase6;
            if (json != null)
            {
                var obj = JObject.Parse(json);
                var vacunas = JArray.Parse(obj["Vacunas"].ToString());
                var etareas = JArray.Parse(obj["Etaria"].ToString());
                foreach (var vacuna in vacunas)
                {
                    var categoriaEtareas = JArray.Parse(vacuna["IdCategoriaEtaria"].ToString());
                    foreach (var itemCategoria in categoriaEtareas)
                    {
                        var etarea = etareas.FirstOrDefault(x => x["Id"].ToString() == itemCategoria.ToString());
                        if(etarea != null)
                        {
                            tiposVacunacionEtareas.Add(new TiposVacunacionEtareas()
                            {
                                IdCategoriaEtarea = Convert.ToInt32(etarea["Id"]),
                                NombreVacuna = vacuna["Nombre"].ToString(),
                                Categoria = etarea["Categoria"].ToString()
                            });
                        }
                    }
                }

                // recorremos el listado creado
                List<int> listadoIdRepetido = new();
                StackLayout layoutFinal = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 5, 10, 5) };
                foreach (var items in tiposVacunacionEtareas.OrderBy(x => x.IdCategoriaEtarea))
                {
                    Frame frameCard = new()
                    {
                        Margin = new Thickness(15, 5, 15, 5),
                        CornerRadius = 10,
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.White,
                    };
                    StackLayout layout = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 10, 10, 10) };

                    if (tiposVacunacionEtareas.Count(x => x.IdCategoriaEtarea == items.IdCategoriaEtarea) > 1)
                    {
                        // se agrega frame con 2 items o más
                        if(!listadoIdRepetido.Any(x => x == items.IdCategoriaEtarea))
                            listadoIdRepetido.Add(items.IdCategoriaEtarea);
                    }
                    else
                    {
                        layout.Children.Add(new Label { Text = items.Categoria, Margin = new Thickness(0,5,0,5), FontSize = 15, TextColor = Colors.Black });
                        layout.Children.Add(new Label { Text = items.NombreVacuna, Margin = new Thickness(0,5,0,5), FontSize = 12, TextColor = Colors.Black });

                        var nameEntryVacunado = items.Categoria + items.NombreVacuna + items.IdCategoriaEtarea + "SI";
                        var nameEntryNoVacunado = items.Categoria + items.NombreVacuna + items.IdCategoriaEtarea + "NO";

                        StackLayout layoutButtons = new() { Orientation = StackOrientation.Horizontal ,VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.StartAndExpand };

                        // caja de botones 
                        Frame frameBoton1 = new()
                        {
                            Margin = new Thickness(0, 0, 0, 0),
                            Padding = new Thickness(0, 0, 0, 0),
                            CornerRadius = 5,
                            BorderColor = Color.FromArgb("#aa5ee5"),
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            HeightRequest = 35,
                            WidthRequest = 50,
                            IsClippedToBounds = true,
                        };

                        StackLayout layoutContBoton1 = new() { Margin = new Thickness(0, 0, 0, 0) };

                        Frame frameBoton2 = new()
                        {
                            Margin = new Thickness(50, 0, 0, 0),
                            Padding = new Thickness(0, 0, 0, 0),
                            CornerRadius = 5,
                            BorderColor = Color.FromArgb("#aa5ee5"),
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            HeightRequest = 35,
                            WidthRequest = 50,
                            IsClippedToBounds = true,
                        };

                        StackLayout layoutContBoton2 = new() { Margin = new Thickness(0, 0, 0, 0) };



                        var entryCount1 = new MyEntry
                        {
                            Text = "0",
                            HeightRequest = 40,
                            WidthRequest = 50,
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Colors.White,
                            CornerRadius = 5,
                            Margin = new Thickness(0), 
                            Keyboard = Keyboard.Numeric,
                            Nombre = items.NombreVacuna+"SI",
                            StyleId = nameEntryVacunado
                        };

                        entryCount1.Completed += SumarValores;

                        _visualElement.Add(entryCount1);

                        layoutContBoton1.Children.Add(entryCount1);
                        frameBoton1.Content = layoutContBoton1;
                        layoutButtons.Children.Add(frameBoton1);

                        layoutButtons.Children.Add(new Label { Text = "vacunados", Margin = new Thickness(5, 10, 0, 0), FontSize = 10 });


                        var entryCount2 = new MyEntry
                        {
                            Text = "0",
                            HeightRequest = 40,
                            WidthRequest = 50,
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Colors.White,
                            CornerRadius = 5,
                            Keyboard = Keyboard.Numeric,
                            Nombre = items.NombreVacuna + "NO",
                            StyleId = nameEntryNoVacunado
                        };

                        entryCount2.Completed += SumarValores;
                        _visualElement.Add(entryCount2);

                        layoutContBoton2.Children.Add(entryCount2);
                        frameBoton2.Content = layoutContBoton2;
                        layoutButtons.Children.Add(frameBoton2);

                        layoutButtons.Children.Add(new Label { Text = "No vacunados", Margin = new Thickness(5, 10, 0, 0), FontSize = 10 });
                        layout.Children.Add(layoutButtons);
                        frameCard.Content = layout;
                        layoutFinal.Children.Add(frameCard);
                    }
                }

                // realiza el frame en conjunto 
                StackLayout layoutRepetido = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(0) };
                foreach (var rep in listadoIdRepetido)
                {
                    Frame frameCard = new()
                    {
                        Margin = new Thickness(15, 5, 15, 5),
                        CornerRadius = 10,
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.White,
                    };
                    StackLayout layout = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 10, 10, 10) };
                    int count = 0;
                    foreach (var item in tiposVacunacionEtareas.Where(x => x.IdCategoriaEtarea == rep)) {
                        
                        if(count == 0) {
                            layout.Children.Add(new Label { Text = item.Categoria, Margin = new Thickness(0, 5, 0, 5), FontSize = 15, TextColor = Colors.Black });
                            count++;
                        }

                        layout.Children.Add(new Label { Text = item.NombreVacuna, Margin = new Thickness(0, 5, 0, 5), FontSize = 12, TextColor = Colors.Black });

                        var nameEntryVacunado = item.Categoria + item.NombreVacuna + item.IdCategoriaEtarea + "SI";
                        var nameEntryNoVacunado = item.Categoria + item.NombreVacuna + item.IdCategoriaEtarea + "NO";

                        StackLayout layoutButtons = new() { Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.StartAndExpand };

                        // caja de botones 
                        Frame frameBoton1 = new()
                        {
                            Margin = new Thickness(0, 0, 0, 0),
                            Padding = new Thickness(0, 0, 0, 0),
                            CornerRadius = 5,
                            BorderColor = Color.FromArgb("#aa5ee5"),
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            HeightRequest = 35,
                            WidthRequest = 50,
                            IsClippedToBounds = true,
                        };

                        StackLayout layoutContBoton1 = new() { Margin = new Thickness(0, 0, 0, 0) };

                        Frame frameBoton2 = new()
                        {
                            Margin = new Thickness(50, 0, 0, 0),
                            Padding = new Thickness(0, 0, 0, 0),
                            CornerRadius = 5,
                            BorderColor = Color.FromArgb("#aa5ee5"),
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            HeightRequest = 35,
                            WidthRequest = 50,
                            IsClippedToBounds = true,
                        };

                        StackLayout layoutContBoton2 = new() { Margin = new Thickness(0, 0, 0, 0) };

                        var entryCount1 = new MyEntry
                        {
                            Text = "0",
                            HeightRequest = 40,
                            WidthRequest = 50,
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Colors.White,
                            CornerRadius = 5,
                            Margin = new Thickness(0),
                            Keyboard = Keyboard.Numeric,
                            Nombre = item.NombreVacuna + "SI", 
                            StyleId = nameEntryVacunado
                        };

                        entryCount1.Completed += SumarValores;

                        _visualElement.Add(entryCount1);

                        layoutContBoton1.Children.Add(entryCount1);
                        frameBoton1.Content = layoutContBoton1;
                        layoutButtons.Children.Add(frameBoton1);

                        layoutButtons.Children.Add(new Label { Text = "vacunados", Margin = new Thickness(5, 10, 0, 0), FontSize = 10 });

                        var entryCount2 = new MyEntry
                        {
                            Text = "0",
                            HeightRequest = 40,
                            WidthRequest = 50,
                            BackgroundColor = Color.FromArgb("#aa5ee5"),
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Colors.White,
                            CornerRadius = 5,
                            Keyboard = Keyboard.Numeric,
                            Nombre = item.NombreVacuna + "NO",
                            StyleId = nameEntryNoVacunado
                        };

                        entryCount2.Completed += SumarValores;

                        _visualElement.Add(entryCount2);

                        layoutContBoton2.Children.Add(entryCount2);
                        frameBoton2.Content = layoutContBoton2;
                        layoutButtons.Children.Add(frameBoton2);

                        layoutButtons.Children.Add(new Label { Text = "No vacunados", Margin = new Thickness(5, 10, 0, 0), FontSize = 10 });
                        layout.Children.Add(layoutButtons);
                        
                        //layoutRepetido.Children.Add(frameCard);

                    }
                    frameCard.Content = layout;
                    layoutFinal.Children.Add(frameCard);
                    
                }

                Content = layoutFinal;
            }
        }
        catch (Exception ex)
        {
           Toast.Make($"Error {ex.Message}",ToastDuration.Long);
        }
       
    }

    private void SumarValores(object sender, EventArgs e)
    {
        MyEntry entry = (MyEntry)sender;
        var entryVisualElement = (MyEntry)_visualElement.FirstOrDefault(x => x.StyleId == entry.StyleId);

        if (entryVisualElement != null)
        {
            if(entry.Nombre == "BRUCELOSISSI")
            {
                ViewModelLocator.Resolve<RuvViewModel>().TotalVacunadosBrucelosis += Convert.ToInt32(entry.Text);
            }
            else if (entry.Nombre == "BRUCELOSISNO")
            {
                ViewModelLocator.Resolve<RuvViewModel>().TotalNoVacunadosBrucelosis += Convert.ToInt32(entry.Text);
            }
            else if (entry.Nombre == "AFTOSASI")
            {
                ViewModelLocator.Resolve<RuvViewModel>().TotalVacunadosAftosa += Convert.ToInt32(entry.Text);
            }
            else
            {
                ViewModelLocator.Resolve<RuvViewModel>().TotalNoVacunadosAftosa += Convert.ToInt32(entry.Text);
            }
        }

        
    }




}