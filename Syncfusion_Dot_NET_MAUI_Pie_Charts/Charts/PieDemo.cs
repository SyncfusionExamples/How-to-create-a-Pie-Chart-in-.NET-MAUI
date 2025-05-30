using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Syncfusion.Maui.Charts;


namespace Charts
{
    public class PieDemo : ContentPage
    {
        public PieDemo()
        {
			SfCircularChart chart = new SfCircularChart();
			var viewModel = new ViewModel();
            chart.BindingContext= viewModel;
            //Legend
            chart.Legend = new ChartLegend() { Placement = Syncfusion.Maui.Core.LegendPlacement.Right };

			//Initialize series
			var binding = new Binding() { Path = "Data" };
			var series = new PieSeries()
			{
				XBindingPath = "Country",
				YBindingPath = "Counts",
				ShowDataLabels = true,
				PaletteBrushes = viewModel.CustomBrushes,
			};

			series.SetBinding(ChartSeries.ItemsSourceProperty, binding); 

			chart.Series.Add(series);

			//Chart title
			var title = new Label()
			{
				HorizontalOptions = LayoutOptions.Fill,
				HorizontalTextAlignment = Microsoft.Maui.TextAlignment.Center,
				Text = "Rural population of various countries",
				FontSize = 16,
				Margin = new Microsoft.Maui.Thickness(5, 10, 5, 10),
			};
			chart.Title = title;

			var grid = new Grid() 
			{ 
				HorizontalOptions = LayoutOptions.Fill,
				VerticalOptions = LayoutOptions.Fill,
				Padding = new Microsoft.Maui.Thickness(20),
			};

			grid.Children.Add(chart);

			this.Content = grid;
		}
	}
}