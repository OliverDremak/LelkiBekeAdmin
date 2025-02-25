using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class StatPage : ContentPage
{
	public StatPage()
	{
		InitializeComponent();
        BindingContext = new StatViewModel();

        // Create a ChartDrawable
        var chartDrawable = new ChartDrawable(((StatViewModel)BindingContext).SalesData);
        chartGraphicsView.Drawable = chartDrawable;

    }
}