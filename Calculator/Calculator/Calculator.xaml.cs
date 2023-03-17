using System.Data;

namespace Calculator;

public partial class Calculator : ContentPage
{
	public Calculator()
	{
		InitializeComponent();
	}

    private string m_expr = string.Empty;
    private bool m_comma_is_used = false;

    private static DataTable Table { get; } = new DataTable();

    public static double Calc(string Expression) => Convert.ToDouble(Table.Compute(Expression, string.Empty));

    private void ButtonNumber_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (btn.Text == "0" && m_expr == "0")
        {
            return;
        }    
        int number = Convert.ToInt32(btn.Text);
        this.Label.UpdateText(this.Label.Text + number.ToString());
        m_expr += btn.Text;
        Solve();
    }

    private void ButtonComma_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (m_expr.Length == 0 || m_comma_is_used || m_expr[m_expr.Length - 1] == '+' || m_expr[m_expr.Length - 1] == '-' ||
            m_expr[m_expr.Length - 1] == '*' || m_expr[m_expr.Length - 1] == '/')
        {
            return;
        }
        else
        {
            m_expr += '.';
            this.Label.UpdateText(this.Label.Text + btn.Text);
            m_comma_is_used = true;
        }
    }

    private void ButtonBackspace_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;
        if (m_expr.Length == 0)
        {
            return;
        }

        if (m_expr[m_expr.Length - 1] == '.')
        {
            m_expr = m_expr.Remove(m_expr.Length - 1);
            m_comma_is_used = false;
            this.Label.UpdateText(Label.Text.Remove(Label.Text.Length - 1));
        }
        else
        {
            this.Label.UpdateText(Label.Text.Remove(Label.Text.Length - 1));
            m_expr = m_expr.Remove(m_expr.Length - 1);
        }
    }

    private void Solve()
    {
        if (m_expr.Contains("/0"))
        {
            ResultLabel.UpdateText("Division by 0");
            Label.UpdateText("");
            m_expr = string.Empty;
        }

        if (m_expr.Length != 0 && m_expr[m_expr.Length - 1] != '+' && m_expr[m_expr.Length - 1] != '-' &&
             m_expr[m_expr.Length - 1] != '*' && m_expr[m_expr.Length - 1] != '/' && m_expr[m_expr.Length - 1] != ',')
        {
            string result = Calc(m_expr).ToString();
            this.ResultLabel.Text = result;
        }
    }

    private void ButtonEqual_Clicked(object sender, EventArgs e)
    {
        Solve();
        m_expr = ResultLabel.Text.Replace(',', '.');
        string result = ResultLabel.Text;
        Label.UpdateText(result);

    }

    private void ButtonOper_Clicked(object sender, EventArgs e)
    {
        var btn = (Button)sender;

        if (m_expr.Length != 0 && m_expr[m_expr.Length - 1] != '+' && m_expr[m_expr.Length - 1] != '-' &&
             m_expr[m_expr.Length - 1] != '*' && m_expr[m_expr.Length - 1] != '/' && m_expr[m_expr.Length - 1] != '%')
        {
            this.m_comma_is_used = false;
            if (btn.Text == "+")
            {
                m_expr += "+";
            }
            if (btn.Text == "-")
            {
                m_expr += "-";
            }
            if (btn.Text == "×")
            {
                m_expr += "*";
            }
            if (btn.Text == "÷")
            {
                m_expr += "/";
            }
            if (btn.Text == "%")
            {
                m_expr += "*0.01";
            }
            this.Label.UpdateText(this.Label.Text + btn.Text);
        }


    }

    private void ButtonMPlus_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonMMinus_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonMS_Clicked(object sender, EventArgs e)
    {

    }

    private void ButtonC_Clicked(object sender, EventArgs e)
    {
        m_expr = string.Empty;
        Label.UpdateText("");
        ResultLabel.UpdateText("");
    }

    private void ButtonMC_Clicked(object sender, EventArgs e)
    {

    }
}