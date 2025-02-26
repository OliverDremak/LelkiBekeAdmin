using LelkiBekeAdmin.Classes;
using LelkiBekeAdmin.ViewModels;

namespace LelkiBekeAdmin.Pages;

public partial class StatPage : ContentPage
{
	public StatPage()
	{
		InitializeComponent();
        var viewModel = new StatViewModel();
        BindingContext = viewModel;

        // Bind the ChartDrawable from the view model
        chartGraphicsView.Drawable = viewModel.ChartDrawable;

    }
}