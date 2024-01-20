using System.Globalization;
using System.ComponentModel;
using System.Windows.Forms;
using Конвертор;

namespace Work1
{
    public partial class Form1 : Form
    {

        private bool isClosing = false;


        public Form1()
        {
            InitializeComponent();
            LoadHistory();
            // Подписываемся на событие FormClosing
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }


        // ---------- Загрузка истории с текстового файла ----------------
        private void LoadHistory()
        {
            if (File.Exists("ConversionHistory.txt"))
            {
                conversionHistory = File.ReadAllLines("ConversionHistory.txt").ToList();
            }
        }



        // Обработчик события FormClosing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
        }



        // История отслеживание результатов
        private List<string> conversionHistory = new List<string>();


        // Используем Timer из пространства имен System.Windows.Forms
        private System.Windows.Forms.Timer resetButtonTextTimer = new System.Windows.Forms.Timer();



        // ================================================================
        // -------- Программирование кнопки "Конвертировать" --------
        // ================================================================
        private void buttonConvert_Click(object sender, EventArgs e)
        {
            try
            {
                // Используем CultureInfo.InvariantCulture для обработки строки как числа с плавающей точкой в формате, использующем точку.
                double numberToConvert = double.Parse(textBoxNumber.Text, CultureInfo.InvariantCulture);
                int baseOfSystem = int.Parse(textBoxBase.Text, CultureInfo.InvariantCulture);
                int precision = int.Parse(textBoxPrecision.Text, CultureInfo.InvariantCulture);

                // Вызов метода конвертации
                string conversionResult = Conver_10_P.Do(numberToConvert, baseOfSystem, precision);

                // Отображение результата
                labelResult.Text = conversionResult;

                // Добавление результата в историю конвертаций
                string newEntry = $"{DateTime.Now}: {numberToConvert} в системе с основанием {baseOfSystem} равно {conversionResult} с точностью {precision}";
                conversionHistory.Add(newEntry);

                // Сохранение новой записи в файл
                File.AppendAllText("ConversionHistory.txt", newEntry + Environment.NewLine);
            
            }
            catch (Exception ex)
            {
                // В случае ошибки показать сообщение
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // ---------- Валидация функции программы -----------
        private void textBoxBase_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing || !this.Visible)
            {
                e.Cancel = false;
                return;
            }


            if (!int.TryParse(textBoxBase.Text, out int baseValue) || baseValue < 2 || baseValue > 16)
            {
                MessageBox.Show("Основание системы счисления должно быть числом от 2 до 16.");
                e.Cancel = true;
            }
        }

        private void textBoxNumber_Validating(object sender, CancelEventArgs e)
        {
            if (isClosing)
            {
                // Отменяем валидацию и позволяем форме закрыться
                e.Cancel = false;
                return;
            }

            if (!double.TryParse(textBoxNumber.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out _))
            {
                MessageBox.Show("Введите корректное число.");
                e.Cancel = true;
            }
        }





        // ------------ Кнопка "Копировать результат" --------------
        private void buttonCopy_Click_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(labelResult.Text);

            // Проверка sender на null и на то, что это Button
            if (sender is Button btn)
            {
                btn.Text = "Скопировано";

                // Устанавливаем таймер для сброса текста кнопки
                resetButtonTextTimer.Interval = 2000; // Задержка в 2 секунды
                resetButtonTextTimer.Tick += (sender, e) =>
                {
                    btn.Text = "Копировать результат";
                    resetButtonTextTimer.Stop();
                };
                resetButtonTextTimer.Start();
            }
        }


        // ----------------- ВЕРХНЕЕ МЕНЮ ФОРМЫ -------------------
        private void exitMenuItem_Click_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void historyMenuItem_Click_Click(object sender, EventArgs e)
        {
            string historyText = string.Join(Environment.NewLine, conversionHistory);
            MessageBox.Show(historyText, "История конвертаций");
        }

        private void helpMenuItem_Click_Click(object sender, EventArgs e)
        {
            string helpText = "Введите число для конвертации, выберите основание системы счисления и " +
                  "точность результата. Нажмите 'Конвертировать', чтобы увидеть результат. " +
                  "Используйте кнопку 'Копировать', чтобы скопировать результат в буфер обмена.";
            MessageBox.Show(helpText, "Справка по использованию программы");
        }

        // Будущие обновления кода....
    }
}
