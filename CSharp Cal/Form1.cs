namespace CSharp_Cal
{
    public partial class Calculator : Form
    {

        string operation = "";
        double result_Value = 0;
        bool isOperationPerformed = false;

        public Calculator()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, EventArgs e)
        {
            if (tb_result.Text == "0" || isOperationPerformed)
            {
                tb_result.Clear();
            }
            Button btn = (Button)sender;

            if (btn.Text == ".")
            {
                if (!tb_result.Text.Contains("."))
                {
                    tb_result.Text = tb_result.Text + btn.Text;
                }
            }
            else

                tb_result.Text = tb_result.Text + btn.Text;
            isOperationPerformed = false;

        }

        private void operation_performed(object sender, EventArgs e)
        {

            if (result_Value != 0)
            {
                button18.PerformClick();

                Button btn = (Button)sender;
                operation = btn.Text;
                result_Value = double.Parse(tb_result.Text);
                lb_result.Text = result_Value + " " + operation;
                isOperationPerformed = true;
            }
            else
            {

                Button btn = (Button)sender;
                operation = btn.Text;
                result_Value = double.Parse(tb_result.Text);
                lb_result.Text = result_Value + " " + operation;
                isOperationPerformed = true;
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            tb_result.Text = "0";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tb_result.Text = "0";
            lb_result.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            switch (operation)
            {
                case "+":
                    tb_result.Text = (result_Value + double.Parse(tb_result.Text)).ToString();
                    break;
                case "-":
                    tb_result.Text = (result_Value - double.Parse(tb_result.Text)).ToString();
                    break;
                case "*":
                    tb_result.Text = (result_Value * double.Parse(tb_result.Text)).ToString();
                    break;
                case "/":
                    tb_result.Text = (result_Value / double.Parse(tb_result.Text)).ToString();
                    break;
                default:
                    break;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
