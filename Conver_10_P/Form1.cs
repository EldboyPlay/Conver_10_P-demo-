using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;
using ���������;

namespace Work1
{
    public partial class Form1 : Form
    {

        private bool isClosing = false;


        public Form1()
        {
            InitializeComponent();
            LoadHistory();
            // ������������� �� ������� FormClosing
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }


        // ---------- �������� ������� � ���������� ����� ----------------
        private void LoadHistory()
        {
            if (File.Exists("ConversionHistory.txt"))
            {
                conversionHistory = File.ReadAllLines("ConversionHistory.txt").ToList();
            }
        }



        // ���������� ������� FormClosing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
        }



        // ������� ������������ �����������
        private List<string> conversionHistory = new List<string>();


        // ���������� Timer �� ������������ ���� System.Windows.Forms
        private System.Windows.Forms.Timer resetButtonTextTimer = new System.Windows.Forms.Timer();



        // ================================================================
        // -------- ���������������� ������ "��������������" --------
        // ================================================================
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                // ���������� CultureInfo.InvariantCulture ��� ��������� ������ ��� ����� � ��������� ������ � �������, ������������ �����.
                double numberToConvert = double.Parse(textBoxNumber.Text, CultureInfo.InvariantCulture);
                int baseOfSystem = int.Parse(textBoxBase.Text, CultureInfo.InvariantCulture);
                int precision = int.Parse(textBoxPrecision.Text, CultureInfo.InvariantCulture);

                // ����� ������ �����������
                string conversionResult = Conver_10_P.Do(numberToConvert, baseOfSystem, precision);

                // ����������� ����������
                labelResult.Text = conversionResult;

                // ���������� ���������� � ������� �����������
                string newEntry = $"{DateTime.Now}: {numberToConvert} � ������� � ���������� {baseOfSystem} ����� {conversionResult} � ��������� {precision}";
                conversionHistory.Add(newEntry);

                // ���������� ����� ������ � ����
                File.AppendAllText("ConversionHistory.txt", newEntry + Environment.NewLine);
            
            }
            catch (Exception ex)
            {
                // � ������ ������ �������� ���������
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ---------- ��������� ������� ��������� -----------
        private void textBoxBase_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || !this.Visible)
            {
                e.Cancel = false;
                return;
            }


            if (!int.TryParse(textBoxBase.Text, out int baseValue) || baseValue < 2 || baseValue > 16)
            {
                MessageBox.Show("��������� ������� ��������� ������ ���� ������ �� 2 �� 16.");
                e.Cancel = true;
            }
        }

        private void textBoxNumber_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing)
            {
                // �������� ��������� � ��������� ����� ���������
                e.Cancel = false;
                return;
            }

            if (!double.TryParse(textBoxNumber.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("������� ���������� �����.");
                e.Cancel = true;
            }
        }





        // ------------ ������ "���������� ���������" --------------
        private void buttonCopy_Click_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelResult.Text);

            // �������� sender �� null � �� ��, ��� ��� Button
            if (sender is Button btn)
            {
                btn.Text = "�����������";

                // ������������� ������ ��� ������ ������ ������
                resetButtonTextTimer.Interval = 2000; // �������� � 2 �������
                resetButtonTextTimer.Tick += (sender, e) =>
                {
                    btn.Text = "���������� ���������";
                    resetButtonTextTimer.Stop();
                };
                resetButtonTextTimer.Start();
            }
        }


        // ----------------- ������� ���� ����� -------------------
        private void exitMenuItem_Click_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void historyMenuItem_Click_Click(object sender, EventArgs e)
        {
            string historyText = string.Join(Environment.NewLine, conversionHistory);
            MessageBox.Show(historyText, "������� �����������");
        }

        private void helpMenuItem_Click_Click(object sender, EventArgs e)
        {
            string helpText = "������� ����� ��� �����������, �������� ��������� ������� ��������� � " +
                  "�������� ����������. ������� '��������������', ����� ������� ���������. " +
                  "����������� ������ '����������', ����� ����������� ��������� � ����� ������.";
            MessageBox.Show(helpText, "������� �� ������������� ���������");
        }

        // ������� ���������� ����....
    }
}
