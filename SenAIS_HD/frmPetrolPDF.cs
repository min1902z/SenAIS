using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using PdfiumViewer;

namespace SenAIS
{
    public partial class frmPetrolPDF : Form
    {
        private Form parentForm;
        private SQLHelper sqlHelper;
        private bool isReady = false;
        private string serialNumber;
        private decimal eSpeed;
        private decimal hcValue;
        private decimal coValue;
        private decimal oilTemp;
        public frmPetrolPDF(Form parent, string serialNumber)
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
                MessageBox.Show("Lỗi khi thay đổi Số Vin: " + ex.Message);
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
                MessageBox.Show("Lỗi khi thay đổi Số Vin: " + ex.Message);
            }
        }
        private void SaveDataToDatabase()
        {
            sqlHelper.SavePetrolEmissionData(this.serialNumber, hcValue, coValue, oilTemp, eSpeed);
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
                MessageBox.Show("Vui lòng chọn file PDF!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Đọc nội dung từ file PDF
                string content = ExtractTextFromPDF(pdfPath);

                // Phân tích nội dung và hiển thị dữ liệu lên các label
                ParseAndDisplayData(content);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file PDF: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveEmission_Click(object sender, EventArgs e)
        {
            try
            {
                if (isReady)
                {
                    // Lưu dữ liệu vào cơ sở dữ liệu
                    sqlHelper.SavePetrolEmissionData(serialNumber, hcValue, coValue, oilTemp, eSpeed);
                    MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string ExtractTextFromPDF(string path)
        {
            using (var pdfDocument = PdfiumViewer.PdfDocument.Load(path))
            {
                string result = "";
                for (int i = 0; i < pdfDocument.PageCount; i++)
                {
                    result += pdfDocument.GetPdfText(i);
                }
                return result;
            }
        }
        private void ParseAndDisplayData(string content)
        {
            var lines = content.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            eSpeed = 0;
            hcValue = 0;
            coValue = 0;
            oilTemp = 0;

            foreach (var line in lines)
            {
                if (line.Contains("[rpm]")) // Tìm dòng chứa tốc độ
                {
                    var value = ExtractLastValue(line);
                    eSpeed = TryParseDecimal(value); // Gán giá trị tốc độ
                    lbRPMValue.Text = value;
                }
                else if (line.Contains("[%]") && line.Contains("CO")) // Tìm dòng chứa CO
                {
                    var value = ExtractLastValue(line);
                    coValue = TryParseDecimal(value); // Gán giá trị CO
                    lbCOValue.Text = value;
                }
                else if (line.Contains("[ppm]") && line.Contains("HC")) // Tìm dòng chứa HC
                {
                    var value = ExtractLastValue(line);
                    hcValue = TryParseDecimal(value); // Gán giá trị HC
                    lbHCValue.Text = value;
                }
                else if (line.Contains("[°C]")) // Tìm dòng chứa nhiệt độ
                {
                    var value = ExtractLastValue(line);
                    oilTemp = TryParseDecimal(value); // Gán giá trị nhiệt độ
                    lbOTValue.Text = value;
                }
            }
            isReady = true;
        }

        // Hàm đọc giá trị cuối cùng trong dòng
        private string ExtractLastValue(string line)
        {
            var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.LastOrDefault();
        }
        private decimal TryParseDecimal(string value)
        {
            if (decimal.TryParse(value, out var result))
                return result;

            return 0; // Giá trị mặc định khi không đọc được
        }
    }
}
