﻿using System;
using System.IO;
using NPOI.XSSF.UserModel;

namespace CopySheet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Please Wait while processing...");
            //Excel worksheet combine example
            //Note: This example does not check for duplicate sheet names. Your test files should have different sheet names.
            
            XSSFWorkbook book1 = new XSSFWorkbook(new FileStream("file1.xlsx", FileMode.Open));
            XSSFWorkbook book2 = new XSSFWorkbook(new FileStream("file2.xlsx", FileMode.Open));
            XSSFWorkbook product = new XSSFWorkbook();

            for (int i = 0; i < book1.NumberOfSheets; i++)
            {
                XSSFSheet sheet1 = book1.GetSheetAt(i) as XSSFSheet;
                sheet1.CopyTo(product, sheet1.SheetName, true, true);
            }
            for (int j = 0; j < book2.NumberOfSheets; j++)
            {
                XSSFSheet sheet2 = book2.GetSheetAt(j) as XSSFSheet;
                sheet2.CopyTo(product, sheet2.SheetName, true, true);
            }
            product.Write(new FileStream("test.xlsx", FileMode.Create, FileAccess.ReadWrite));
        }

    }
}
