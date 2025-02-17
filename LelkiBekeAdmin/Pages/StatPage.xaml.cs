using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class StatPage : ContentPage
{
	public StatPage()
	{
		InitializeComponent();
        BindingContext = new StatViewModel();

        // Create a ChartDrawable and pass the SalesData to it
        var chartDrawable = new ChartDrawable(((StatViewModel)BindingContext).SalesData);

        // Assign the chartDrawable to the GraphicsView
        chartGraphicsView.Drawable = chartDrawable;
    }
}