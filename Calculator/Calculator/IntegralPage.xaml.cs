using System;

namespace Calculator;

public partial class IntegralPage : ContentPage
{
	double Answer { get; set; }

    public CancellationTokenSource CancellationTokenSource { get; set; }

    public string Progress { get; set; }
    public string ProgressPercents { get; set; }

    public IntegralPage()
	{
        CancellationTokenSource = new CancellationTokenSource();
        InitializeComponent();
        Progress = "0";
        ProgressPercents = "0%";
    }

    private async void StartBtn_ClickedAsync(object sender, EventArgs e)
    {
        this.MainLabel.Text = "Вычисление";
		Answer = await SolveIntegralAsync();
		this.MainLabel.Text = Answer.ToString();
    }

    double SolveIntegral()
    {
        double result = 0;
        double step = 1e-6;
        double x = 0;

        for (int i = 0; i < (int)(1 / step); ++i)
        {
            if (CancellationTokenSource.IsCancellationRequested)
            {
                return 0.0;
            }
            result += Math.Sin(x) * step;
            x += step;

            double a = 1;
            for (int m = 0; m < 100; m++)
            {
                a /= m;
            }

            if (i % 1e4 == 0)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ProgressBarItem.Progress = (i / (1 / step));
                    ProgressLabel.Text = Math.Round((Convert.ToDouble(ProgressBarItem.Progress) * 100), 2).ToString() + '%';
                });
            }
            
        }
        MainThread.BeginInvokeOnMainThread(() =>
        {
            ProgressBarItem.Progress = 1;
            ProgressLabel.Text = "100%";
        });

        return result;
    }

    public async Task<double> SolveIntegralAsync()
    {
        double answer = 0;
        await Task.Run(() => { answer = SolveIntegral(); });
        return answer;
    }
}