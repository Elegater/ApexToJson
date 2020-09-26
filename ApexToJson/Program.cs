using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using Newtonsoft.Json;

namespace ApexToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "./Apexes.xlsx";
            int startRow = 2;
            int startCol = 1;

            FileInfo fi = new FileInfo(filePath);
            ExcelRange data = null;
            List<Apex> apexes = new List<Apex>();

            if (!File.Exists(fi.FullName))
            {
                Console.WriteLine("Incorrect file name");
                return;
            }
            using (ExcelPackage p = new ExcelPackage(fi))
            {
                ExcelWorkbook wb = p.Workbook;
                ExcelWorksheet ws = wb.Worksheets[1];
                data = ws.Cells;

                int endRow = 0;
                int endCol = 0;
                bool lastRowFound = false;
                bool lastColFound = false;

                for (int i = startRow; !lastRowFound; i++)
                {
                    if (String.IsNullOrEmpty(ws.Cells[i, startCol].Text))
                    {
                        lastRowFound = true;
                    }
                    else
                    {
                        endRow = i;
                    }
                }

                for (int i = startRow; !lastColFound; i++)
                {
                    if (String.IsNullOrEmpty(ws.Cells[startRow, i].Text))
                    {
                        lastColFound = true;
                    }
                    else
                    {
                        endCol = i;
                    }
                }

                for (int row = startRow; row <= endRow; row++)
                {
                    Console.WriteLine(row);
                    // if(!File.Exists("./Pics/" + data[row, startCol + 12].Text))
                    // {
                    //     Console.WriteLine(data[row, startCol + 12].Text);
                    // }
                    apexes.Add(new Apex(data[row, startCol].Text, data[row, startCol + 1].Text, data[row, startCol + 2].Text, data[row, startCol + 3].Text, data[row, startCol + 4].Text, data[row, startCol + 5].Text, data[row, startCol + 6].Text, data[row, startCol + 7].Text, data[row, startCol + 8].Text, data[row, startCol + 9].Text, data[row, startCol + 10].Text, data[row, startCol + 11].Text, data[row, startCol + 12].Text));
                }

                JsonSerializerSettings settings = new JsonSerializerSettings();
                string output = "apexes = " + JsonConvert.SerializeObject(apexes, Formatting.Indented);

                File.WriteAllText("./Apexes.jsonp", output);
            }

        }
    }
}
