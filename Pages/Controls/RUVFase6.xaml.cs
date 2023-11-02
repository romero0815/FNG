using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Views;
using FirmaMAUI.Models;
using FirmaMAUI.ViewModels.Base;
using FirmaMAUI.ViewModels.Client;
using Newtonsoft.Json.Linq;

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
                foreach(var items in tiposVacunacionEtareas.OrderBy(x => x.IdCategoriaEtarea))
                {
                    Frame frameCard = new()
                    {
                        Margin = new Thickness(25, 25, 25, 15),
                        CornerRadius = 10,
                        BorderColor = Colors.LightGray,
                        BackgroundColor = Colors.White,
                    };
                    StackLayout layout = new() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = new Thickness(10, 10, 10, 10) };

                    if (tiposVacunacionEtareas.Count(x => x.IdCategoriaEtarea == items.IdCategoriaEtarea) > 1)
                    {
                        // se agrega frame con 2 items 
                    }
                    else
                    {
                        layout.Children.Add(new Label { Text = items.Categoria });
                        layout.Children.Add(new Label { Text = items.NombreVacuna });
                        StackLayout layoutButtons = new() { Orientation = StackOrientation.Horizontal ,VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand };
                        layoutButtons.Children.Add(new Entry { Text = "0", HeightRequest = 20, WidthRequest = 20, BackgroundColor = Colors.Violet });
                        layoutButtons.Children.Add(new Label { Text = "vacunados" });
                        layoutButtons.Children.Add(new Entry { Text = "0", HeightRequest = 20, WidthRequest = 20, BackgroundColor = Colors.Violet });
                        layoutButtons.Children.Add(new Label { Text = "No vacunados" });
                        layout.Children.Add(layoutButtons);
                    }
                }

                //Content = views;
            }
        }
        catch (Exception ex)
        {
           Toast.Make($"Error {ex.Message}",ToastDuration.Long);
        }
       
    }

  

}