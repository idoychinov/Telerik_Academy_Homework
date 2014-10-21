using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 1;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            this.LabelResult.Text += 2;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 3;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 4;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 5;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 6;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 7;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 8;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 9;
        }

        protected void Button0_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text += 0;
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.LabelResult.Text = "0";
            this.HiddenFieldSign.Value = "";
            this.HiddenFieldResult.Value = "";
        }

        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            this.HiddenFieldSign.Value = "+";
            this.HiddenFieldResult.Value = this.LabelResult.Text;
            this.LabelResult.Text = "0";
        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            this.HiddenFieldSign.Value = "-";
            this.HiddenFieldResult.Value = this.LabelResult.Text;
            this.LabelResult.Text = "0";
        }

        protected void ButtonMultiplication_Click(object sender, EventArgs e)
        {
            this.HiddenFieldSign.Value = "*";
            this.HiddenFieldResult.Value = this.LabelResult.Text;
            this.LabelResult.Text = "0";
        }

        protected void ButtonDivision_Click(object sender, EventArgs e)
        {
            this.HiddenFieldSign.Value = "/";
            this.HiddenFieldResult.Value = this.LabelResult.Text;
            this.LabelResult.Text = "0";
        }

        protected void ButtonSquareRoot_Click(object sender, EventArgs e)
        {
            try
            {
                double result = Math.Sqrt(double.Parse(this.LabelResult.Text));
                if (double.IsNaN(result))
                {
                    throw new ArgumentException();
                }

                this.LabelResult.Text = result.ToString();
                this.HiddenFieldResult.Value = "0";
            }
            catch (Exception)
            {
                this.LabelResult.Text = "invalid input";
            }
            this.HiddenFieldSign.Value = "";
            this.HiddenFieldResult.Value = "";
        }

        protected void ButtonEqual_Click(object sender, EventArgs e)
        {
            switch (this.HiddenFieldSign.Value)
            {
                case "+":
                    {
                        this.LabelResult.Text = (int.Parse(this.HiddenFieldResult.Value)
                            + int.Parse(this.LabelResult.Text)).ToString();

                        this.HiddenFieldResult.Value = "0";
                        break;
                    }
                case "-":
                    {
                        this.LabelResult.Text = (int.Parse(this.HiddenFieldResult.Value)
                            - int.Parse(this.LabelResult.Text)).ToString();

                        this.HiddenFieldResult.Value = "0";
                        break;
                    }
                case "*":
                    {
                        this.LabelResult.Text = (int.Parse(this.HiddenFieldResult.Value)
                            * int.Parse(this.LabelResult.Text)).ToString();

                        this.HiddenFieldResult.Value = "0";
                        break;
                    }
                case "/":
                    {
                        try
                        {
                            this.LabelResult.Text = (int.Parse(this.HiddenFieldResult.Value)
                                / int.Parse(this.LabelResult.Text)).ToString();

                            this.HiddenFieldResult.Value = "0";
                        }
                        catch (Exception)
                        {
                            this.LabelResult.Text = "cannot divide by zero";
                        }
                        break;
                    }
                default:
                    {
                        this.LabelResult.Text = this.HiddenFieldResult.Value;
                        this.HiddenFieldResult.Value = "0";
                        break;
                    }
            }
        }
    }
}