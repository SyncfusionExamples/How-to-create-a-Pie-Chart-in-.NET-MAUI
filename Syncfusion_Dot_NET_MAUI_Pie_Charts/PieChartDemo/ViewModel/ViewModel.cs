using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charts.ViewModel
{
    public class ViewModel
    {
        public ObservableCollection<Model> Data { get; set; }
        public ObservableCollection<Brush> CustomBrushes { get; set; }
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

            CustomBrushes = new ObservableCollection<Brush>()
            {
               new SolidColorBrush(Color.FromArgb("#314A6E")),
                 new SolidColorBrush(Color.FromArgb("#48988B")),
                 new SolidColorBrush(Color.FromArgb("#5E498C")),
                 new SolidColorBrush(Color.FromArgb("#74BD6F")),
                 new SolidColorBrush(Color.FromArgb("#597FCA"))
            };
        }
    }


    public class Model
    {
        public string Country { get; set; }

        public double Counts { get; set; }

        public Model(string name , double count)
        {
            Country = name;
            Counts = count;
        }
    }

}
