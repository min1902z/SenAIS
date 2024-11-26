using System;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using PdfiumViewer;

namespace SenAIS
{
    public partial class frmDieselPDF : Form
    {
        private Form parentForm;
        private SQLHelper sqlHelper;
        private bool isReady = false;
        private string serialNumber;
        private decimal minSpeed1;
        private decimal minSpeed2;
        private decimal minSpeed3;
        private decimal maxSpeed1;
        private decimal maxSpeed2;
        private decimal maxSpeed3;
        private decimal hsu1;
        private decimal hsu2;
        private decimal hsu3;
        private decimal avgHsu;
        public frmDieselPDF(Form parent, string serialNumber)
        {
            InitializeComponent();
            this.parentForm = parent;
            this.serialNumber = serialNumber;
            sqlHelper = new SQLHelper();
            lbEngineNumber.Text = this.serialNumber;
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                    SaveDataToDatabase();
                // Lấy SerialNumber trước đó
                string previousSerialNumber = sqlHelper.GetPreviousSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(previousSerialNumber))
                {
                    // Cập nhật serialNumber mới
                    this.serialNumber = previousSerialNumber;
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                }
                else
                {
                    MessageBox.Show("Không có xe trước đó.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                    SaveDataToDatabase();
                string nextSerialNumber = sqlHelper.GetNextSerialNumber(this.serialNumber);
                if (!string.IsNullOrEmpty(nextSerialNumber))
                {
                    this.serialNumber = nextSerialNumber; // Cập nhật serial number
                    lbEngineNumber.Text = this.serialNumber; // Hiển thị serial number mới
                }
                else
                {
                    MessageBox.Show("Không có xe tiếp theo.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thay đổi Số Máy: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SaveDieselEmissionData(this.serialNumber, minSpeed1, maxSpeed1, hsu1, minSpeed2, maxSpeed2, hsu2, minSpeed3, maxSpeed3, hsu3);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void btnReadPDF_Click(object sender, EventArgs e)
        {
            string pdfPath = txtFilePath.Text; // Đường dẫn file PDF từ TextBox
            if (string.IsNullOrEmpty(pdfPath))
            {
                MessageBox.Show("Hãy chọn file trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Đọc nội dung PDF
                string pdfContent = ExtractTextFromPdf(pdfPath);

                // Phân tích nội dung để lấy dữ liệu
                var measurements = ExtractMeasurementData(pdfContent);

                if (measurements == null || measurements.Length != 9)
                {
                    MessageBox.Show("Không thể đọc đủ dữ liệu từ file PDF, sử dụng giá trị mặc định.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    minSpeed1 = maxSpeed1 = hsu1 = 0;
                    minSpeed2 = maxSpeed2 = hsu2 = 0;
                    minSpeed3 = maxSpeed3 = hsu3 = 0;
                }
                else
                {
                    minSpeed1 = TryParseDecimal(measurements[0]);
                    maxSpeed1 = TryParseDecimal(measurements[1]);
                    hsu1 = TryParseDecimal(measurements[2]);

                    minSpeed2 = TryParseDecimal(measurements[3]);
                    maxSpeed2 = TryParseDecimal(measurements[4]);
                    hsu2 = TryParseDecimal(measurements[5]);

                    minSpeed3 = TryParseDecimal(measurements[6]);
                    maxSpeed3 = TryParseDecimal(measurements[7]);
                    hsu3 = TryParseDecimal(measurements[8]);
                }
                lbMinSpeed1.Text = minSpeed1.ToString();
                lbMaxSpeed1.Text = maxSpeed1.ToString();
                lbHSU1.Text = hsu1.ToString();

                lbMinSpeed2.Text = minSpeed2.ToString();
                lbMaxSpeed2.Text = maxSpeed2.ToString();
                lbHSU2.Text = hsu2.ToString();

                lbMinSpeed3.Text = minSpeed3.ToString();
                lbMaxSpeed3.Text = maxSpeed3.ToString();
                lbHSU3.Text = hsu3.ToString();

                // Tính trung bình
                avgHsu = (hsu1 + hsu2 + hsu3) / 3;
                decimal avgMinSpeed = (minSpeed1 + minSpeed2 + minSpeed3) / 3;
                decimal avgMaxSpeed = (maxSpeed1 + maxSpeed2 + maxSpeed3) / 3;

                lbMinAvg.Text = avgMinSpeed.ToString("F1");
                lbMaxAvg.Text = avgMaxSpeed.ToString("F1");
                lbHsuAvg.Text = avgHsu.ToString("F1");
                isReady = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đọc file PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ExtractTextFromPdf(string filePath)
        {
            using (var pdfDocument = PdfiumViewer.PdfDocument.Load(filePath))
            {
                int pageCount = pdfDocument.PageCount;
                string result = "";

                for (int i = 0; i < pageCount; i++)
                {
                    result += pdfDocument.GetPdfText(i);
                }

                return result;
            }
        }
        private string[] ExtractMeasurementData(string content)
        {
            // Tìm bảng đo 3 lần
            var lines = content.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] results = new string[9];
            int index = 0;

            foreach (var line in lines)
            {
                if (line.StartsWith("1.") || line.StartsWith("2.") || line.StartsWith("3."))
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    if (parts.Length >= 5 && index < 9)
                    {
                        results[index++] = parts[1]; // nmin
                        results[index++] = parts[2]; // nmax
                        results[index++] = parts[4]; // HSU
                    }
                }
            }

            return index == 9 ? results : null;
        }

        private void btnSaveEmission_Click(object sender, EventArgs e)
        {
            try
            {
                if(isReady == true)
                {
                    // Lưu vào cơ sở dữ liệu
                    SaveDataToDatabase();
                    MessageBox.Show("Dữ liệu đã được lưu vào cơ sở dữ liệu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private decimal TryParseDecimal(string value)
        {
            if (decimal.TryParse(value, out var result))
                return result;

            return 0; // Giá trị mặc định khi không đọc được
        }
    }

}
