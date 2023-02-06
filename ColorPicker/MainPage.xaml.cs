using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ColorPicker;

public partial class MainPage : ContentPage
{
	 bool israndom;
	string hexValue;
	public MainPage()
	{
		InitializeComponent();
	}

    private void Slide_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		if (!israndom)
		{
            var red = sldRed.Value;
            var green = sldGreen.Value;
            var blue = sldBlue.Value;

            Color color = Color.FromRgb(red, green, blue);

            SetColorValuesToComponents(color);
        }

    }

	private void SetColorValuesToComponents(Color color)
	{
		Container.BackgroundColor= color;
        btnRandom.BackgroundColor= color;
		hexValue = color.ToHex();
        lblHex.Text= "Hex Value: " + hexValue;

    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
		israndom = true;
		var random  = new Random();
		var color = Color.FromRgb(
			random.Next(0,256),
			random.Next(0, 256),
			random.Next(0, 256));

		SetColorValuesToComponents(color);

		sldRed.Value = color.Red;
		sldGreen.Value = color.Green;
		sldBlue.Value = color.Blue;

		israndom= false;
    }

    private async  void ImageButton_Clicked(object sender, EventArgs e)
    {
		await Clipboard.SetTextAsync(hexValue);
		var toast = Toast.Make("Color Copied", ToastDuration.Short,12);

		await toast.Show();
    }
}

