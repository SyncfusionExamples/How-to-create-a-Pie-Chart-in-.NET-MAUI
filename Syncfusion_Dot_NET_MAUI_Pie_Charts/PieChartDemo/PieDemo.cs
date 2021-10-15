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
			chart.BindingContext = new ViewModel.ViewModel();

			//Legend
			chart.Legend = new ChartLegend() { Placement = Syncfusion.Maui.Core.LegendPlacement.Right };

			//Initialize series
			var binding = new Binding() { Path = "Data" };
			var series = new PieSeries()
			{
				XBindingPath = "Country",
				YBindingPath = "Counts",
				ShowDataLabels = true,
				Palette = ChartColorPalette.Custom,
			};

			series.SetBinding(ChartSeries.ItemsSourceProperty, binding);
			series.SetBinding(ChartSeries.CustomBrushesProperty, new Binding() { Path = "CustomBrushes" });

			chart.Series.Add(series);

			//Chart title
			var title = new Label()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HorizontalTextAlignment = Microsoft.Maui.TextAlignment.Center,
				Text = "Rural population of various countries",
				FontSize = 16,
				Margin = new Microsoft.Maui.Thickness(5, 10, 5, 10),
			};
			chart.Title = title;

			var grid = new Grid() 
			{ 
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = new Microsoft.Maui.Thickness(20),
			};

			grid.Children.Add(chart);

			this.Content = grid;
		}
	}
}