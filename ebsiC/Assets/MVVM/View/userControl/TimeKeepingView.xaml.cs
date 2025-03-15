using Microsoft.Win32;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ebsiC.Assets.MVVM.View.userControl
{
    public partial class TimeKeepingView : UserControl
    {
        private string importedFilePath = "";

        public TimeKeepingView()
        {
            InitializeComponent();
        }

        private void browseExcel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            };

            if (opf.ShowDialog() == true)
            {
                importedFilePath = opf.FileName;
                DataTable dt = ReadExcel(importedFilePath);
                DataGridExcel.ItemsSource = dt.DefaultView;
            }
        }

        private void exportExcel_Click(object sender, RoutedEventArgs e)
        {
            DataView? dv = DataGridExcel.ItemsSource as DataView;
            if (dv != null)
            {
                DataTable dt = dv.ToTable();
                ExportToExcel(dt);
            }
            else
            {
                MessageBox.Show("No data to export!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private DataTable ReadExcel(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EmployeeNo");
            dt.Columns.Add("Name");
            dt.Columns.Add("Date");
            dt.Columns.Add("IN");
            dt.Columns.Add("OUT");
            dt.Columns.Add("HoursRendered");

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                int rowStart = 6;

                DateTime? lastValidDate = null;
                string? lastEmpNo = null;
                string? lastName = null;
                DateTime? lastIn = null;
                DateTime? lastOut = null;
                DataRow? lastRow = null;

                for (int i = rowStart; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;

                    string? empNo = row.GetCell(0)?.ToString();
                    string? name = row.GetCell(1)?.ToString();
                    DateTime? date = ParseDate(row.GetCell(2));

                    DateTime? in1 = ParseTime(row.GetCell(3));
                    DateTime? out1 = ParseTime(row.GetCell(4));
                    DateTime? in2 = ParseTime(row.GetCell(5));
                    DateTime? out2 = ParseTime(row.GetCell(6));
                    DateTime? in3 = ParseTime(row.GetCell(7));
                    DateTime? out3 = ParseTime(row.GetCell(8));

                    List<DateTime?> inTimes = new List<DateTime?> { in1, in2, in3 };
                    List<DateTime?> outTimes = new List<DateTime?> { out1, out2, out3 };

                    DateTime? firstIn = inTimes.Where(t => t.HasValue).Min();
                    DateTime? lastRowOut = outTimes.Where(t => t.HasValue).Max();

                    if (!date.HasValue && lastValidDate.HasValue)
                    {
                        date = lastValidDate;
                        empNo = empNo ?? lastEmpNo;
                        name = name ?? lastName;

                        if (firstIn.HasValue) lastIn = firstIn;
                        if (lastRowOut.HasValue) lastOut = lastRowOut;
                        continue;
                    }

                    if (lastRow != null && lastEmpNo == empNo)
                    {
                        if (lastIn.HasValue && string.IsNullOrEmpty(lastRow["IN"].ToString()))
                            lastRow["IN"] = lastIn.Value.ToString("hh:mm tt");

                        if (lastOut.HasValue && string.IsNullOrEmpty(lastRow["OUT"].ToString()))
                            lastRow["OUT"] = lastOut.Value.ToString("hh:mm tt");

                        DateTime? finalIn = ParseTimeString(lastRow["IN"].ToString());
                        DateTime? finalOut = ParseTimeString(lastRow["OUT"].ToString());
                        lastRow["HoursRendered"] = CalculateHoursRendered(finalIn, finalOut);
                    }

                    string hoursRendered = CalculateHoursRendered(firstIn, lastRowOut);

                    DataRow newRow = dt.NewRow();
                    newRow["EmployeeNo"] = empNo;
                    newRow["Name"] = name;
                    newRow["Date"] = date?.ToString("MM/dd/yyyy");
                    newRow["IN"] = firstIn?.ToString("hh:mm tt");
                    newRow["OUT"] = lastRowOut?.ToString("hh:mm tt");
                    newRow["HoursRendered"] = hoursRendered;
                    dt.Rows.Add(newRow);

                    lastRow = newRow;
                    lastValidDate = date;
                    lastEmpNo = empNo;
                    lastName = name;
                    lastIn = firstIn;
                    lastOut = lastRowOut;
                }
            }

            return dt;
        }

        private DateTime? ParseDate(ICell cell)
        {
            if (cell == null) return null;
            if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell)) return cell.DateCellValue;
            if (cell.CellType == CellType.String && DateTime.TryParse(cell.StringCellValue, out DateTime date)) return date.Date;
            return null;
        }

        private DateTime? ParseTime(ICell cell)
        {
            if (cell == null) return null;
            if (cell.CellType == CellType.Numeric && DateUtil.IsCellDateFormatted(cell)) return cell.DateCellValue;
            if (cell.CellType == CellType.String && DateTime.TryParse(cell.StringCellValue, out DateTime time)) return time;
            return null;
        }

        private DateTime? ParseTimeString(string? timeString)
        {
            if (string.IsNullOrEmpty(timeString)) return null;
            if (DateTime.TryParse(timeString, out DateTime result)) return result;
            return null;
        }

        private string CalculateHoursRendered(DateTime? firstIn, DateTime? lastOut)
        {
            if (firstIn.HasValue && lastOut.HasValue)
            {
                if (lastOut.Value < firstIn.Value) lastOut = lastOut.Value.AddDays(1);
                TimeSpan duration = lastOut.Value - firstIn.Value;
                return $"{(int)duration.TotalHours} hrs {duration.Minutes} mins";
            }
            else if (firstIn.HasValue) return "No Time OUT";
            else if (lastOut.HasValue) return "No Time IN";
            return "No Time IN and OUT";
        }
        private void ExportToExcel(DataTable dt)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FileName = "ExportedData.xlsx"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string exportFilePath = saveFileDialog.FileName;
                IWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Attendance Report");

                //Header Style
                ICellStyle headerStyle = workbook.CreateCellStyle();
                IFont headerFont = workbook.CreateFont();
                headerFont.IsBold = true;
                headerFont.FontHeightInPoints = 11;
                headerFont.FontName = "Arial";
                headerStyle.SetFont(headerFont);
                headerStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                headerStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
                headerStyle.FillForegroundColor = IndexedColors.Grey25Percent.Index;
                headerStyle.FillPattern = FillPattern.SolidForeground;
                headerStyle.BorderBottom = BorderStyle.Thin;
                headerStyle.BorderTop = BorderStyle.Thin;
                headerStyle.BorderLeft = BorderStyle.Thin;
                headerStyle.BorderRight = BorderStyle.Thin;

                // Regular Cell Style
                ICellStyle cellStyle = workbook.CreateCellStyle();
                cellStyle.BorderBottom = BorderStyle.Thin;
                cellStyle.BorderTop = BorderStyle.Thin;
                cellStyle.BorderLeft = BorderStyle.Thin;
                cellStyle.BorderRight = BorderStyle.Thin;
                cellStyle.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;

                // Date Style
                ICellStyle dateStyle = workbook.CreateCellStyle();
                dateStyle.CloneStyleFrom(cellStyle);
                dateStyle.DataFormat = workbook.CreateDataFormat().GetFormat("MM/dd/yyyy");

                // Time Style
                ICellStyle timeStyle = workbook.CreateCellStyle();
                timeStyle.CloneStyleFrom(cellStyle);
                timeStyle.DataFormat = workbook.CreateDataFormat().GetFormat("hh:mm AM/PM");

                // Highlighted Data Styles
                ICellStyle lateCellStyle = workbook.CreateCellStyle();
                lateCellStyle.CloneStyleFrom(cellStyle);
                lateCellStyle.FillForegroundColor = IndexedColors.Red.Index;
                lateCellStyle.FillPattern = FillPattern.SolidForeground;

                ICellStyle lateDateStyle = workbook.CreateCellStyle();
                lateDateStyle.CloneStyleFrom(dateStyle);
                lateDateStyle.FillForegroundColor = IndexedColors.Red.Index;
                lateDateStyle.FillPattern = FillPattern.SolidForeground;

                ICellStyle lateTimeStyle = workbook.CreateCellStyle();
                lateTimeStyle.CloneStyleFrom(timeStyle);
                lateTimeStyle.FillForegroundColor = IndexedColors.Red.Index;
                lateTimeStyle.FillPattern = FillPattern.SolidForeground;

                IRow headerRow = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = headerRow.CreateCell(i);
                    cell.SetCellValue(dt.Columns[i].ColumnName);
                    cell.CellStyle = headerStyle;
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);
                    bool isLate = false;

                    string? inTimeStr = dt.Rows[i]["IN"]?.ToString();
                    if (DateTime.TryParse(inTimeStr, out DateTime inTime))
                    {
                        if (inTime.TimeOfDay > new TimeSpan(8, 0, 0))
                        {
                            isLate = true;
                        }
                    }

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        var cellValue = dt.Rows[i][j]?.ToString();
                        string columnName = dt.Columns[j].ColumnName;

                        if (columnName == "Date" && DateTime.TryParse(cellValue, out DateTime dateVal))
                        {
                            cell.SetCellValue(dateVal);
                            cell.CellStyle = isLate ? lateDateStyle : dateStyle;
                        }
                        else if ((columnName == "IN" || columnName == "OUT") && DateTime.TryParse(cellValue, out DateTime timeVal))
                        {
                            cell.SetCellValue(timeVal);
                            cell.CellStyle = isLate ? lateTimeStyle : timeStyle;
                        }
                        else
                        {
                            cell.SetCellValue(cellValue);
                            cell.CellStyle = isLate ? lateCellStyle : cellStyle;
                        }
                    }
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sheet.AutoSizeColumn(i);
                }

                using (FileStream fs = new FileStream(exportFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(fs);
                }

                MessageBox.Show("Data exported successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}