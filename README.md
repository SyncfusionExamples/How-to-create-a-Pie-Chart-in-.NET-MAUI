# How to create a Pie Chart in .NET MAUI (SfCircularChart)

A .NET MAUI Pie charts visual representation of percentages at a certain point in time and it can be used to show percentages of a whole. This section explains how to create a beautiful .NET MAUI Pie Charts.

## Register the handler.
Syncfusion.Maui.Core nuget is a dependent package for all Syncfusion controls of .NET MAUI. In the MauiProgram.cs file, register the handler for Syncfusion core. For more details refer this [link](https://help.syncfusion.com/maui/cartesian-charts/getting-started#register-the-handler).

## Initialize Chart
Import the [SfCircularChart](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCircularChart.html?tabs=tabid-1) namespace as shown below.

**[XAML]**

```
xmlns:chart="clr-namespace:Syncfusion.Maui.Charts;assembly=Syncfusion.Maui.Charts"
```

**[C#]**

```
using Syncfusion.Maui.Charts;
```
Initialize an empty chart and set as content,

**[XAML]**

```
<chart:SfCircularChart>
. . . 
</chart:SfCircularChart>
```
**[C#]**

```
SfCircularChart chart = new SfCircularChart();
. . .
this.Content = chart;
```
## Initialize view model

Now, let define a simple data model that represents a data point for .NET MAUI Pie Chart.
```
public class Model
{
    public string Country{ get; set; }

    public double Counts { get; set; }

    public Model(string name , double count)
    {
        Country= name;
        Counts = count;
    }
}
```
Create a view model class and initialize a list of objects as shown below,
```
public class ViewModel
{
    public ObservableCollection<Model> Data { get; set; }

    public ViewModel()
    {
        Data = new ObservableCollection<Model>()
            {
                new Model("Algeria", 28),
                new Model("Australia", 14),
                new Model("Bolivia", 31),
                new Model("Cambodia", 77),
                new Model("Canada", 19),
            };
    }
}
```
Set the **ViewModel** instance as the **BindingContext** of chart; this is done to bind properties of **ViewModel** to SfCircularChart.

> **Note:** Add namespace of ViewModel class in your XAML page if you prefer to set BindingContext in XAML.

**[XAML]**

```
xmlns:viewModel ="clr-namespace:MauiApp"
. . .
<chart:SfCircularChart>
    <chart:SfCircularChart.BindingContext>
        <viewModel:ViewModel/>
    </chart:SfCircularChart.BindingContext>
</chart:SfCircularChart>
```
**[C#]**

```
SfCircularChart chart = new SfCircularChart();
chart.BindingContext = new ViewModel();
```

## How to populate data in .NET MAUI Pie Charts

As we are going to visualize the comparison of annual population of various countries in the data model, add [PieSeries](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.PieSeries.html?tabs=tabid-1) to [SfCircularChart.Series](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.SfCircularChart.html#Syncfusion_Maui_Charts_SfCircularChart_Series) property, and then bind the Data property of the above ViewModel to the [PieSeries.ItemsSource](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html?&_ga=2.202111828.471182244.1634019879-255829655.1613129491#Syncfusion_Maui_Charts_ChartSeries_ItemsSource) property as shown below.

> **Note:** Need to set [XBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.ChartSeries.html#Syncfusion_Maui_Charts_ChartSeries_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.Charts.XYDataSeries.html#Syncfusion_Maui_Charts_XYDataSeries_YBindingPath) properties, so that series would fetch values from the respective properties in the data model to plot the series.

**[XAML]**

```
<chart:SfCircularChart>
…
    <chart:SfCircularChart.BindingContext>
        <viewModel:ViewModel/>
    </chart:SfCircularChart.BindingContext>

    <chart:SfCircularChart.Series>
        <chart:PieSeries ItemsSource="{Binding Data}"
                        XBindingPath="Country" 
                        YBindingPath="Counts"
                       ShowDataLabels="True">
        </chart:PieSeries>
    </chart:SfCircularChart.Series>
…
</chart:SfCircularChart>
```
**[C#]**

```
SfCircularChart chart = new SfCircularChart ();

chart.BindingContext = new ViewModel();
. . .
var binding = new Binding() { Path = "Data" };
var series = new PieSeries()
{
XBindingPath = " Country",
YBindingPath = "Counts",
ShowDataLabels = true
};

series.SetBinding(ChartSeries.ItemsSourceProperty, binding);
chart.Series.Add(series);
```

## Output:

![.NET MAUI Pie Chart](https://user-images.githubusercontent.com/53489303/200564967-33279027-a98b-4210-9914-fa2ef07103d3.png)

KB article - [How to create a Pie Chart in .NET MAUI](https://www.syncfusion.com/kb/12873/how-to-create-a-pie-chart-in-net-maui)
