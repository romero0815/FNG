
namespace FirmaMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var stream = await DrawBoard.GetImageStream(300, 300);
            ImageView.Source = ImageSource.FromStream(() => stream);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DrawBoard.Lines.Clear();
        }
    }
}