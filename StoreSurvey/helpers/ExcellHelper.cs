using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.Util;
using StoreSurvey.Models;
using StoreSurvey;


namespace StoreSurvey.Helpers
{
    public class ExcellHelper
    {
       public static List<Shop> ReadFile(string fileName)
        {
            var Shops = new List<Shop>();

            if (String.IsNullOrEmpty(fileName))
            {
                throw new RuntimeException("File name is empty");
            }

            var file = File.Exists(fileName);
            if (!file)
            {
                throw new RuntimeException("No file found in the specified locaiton");
            }

            string extention = Path.GetExtension(fileName);
            if (extention != ".xls")
            {
                throw new RuntimeException("File is not valid excel format");
            }

            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            var workbook = new HSSFWorkbook(fileStream);
            var sheetCount = workbook.NumberOfSheets;
            if (sheetCount < 1)
            {
                throw new RuntimeException("No Sheet found in the given file");
            }
            var sheet = workbook.GetSheetAt(0);

            var currentTime = DateTime.Now;

            var rowEnumerator = sheet.GetEnumerator() as IEnumerator<IRow>;

            while (rowEnumerator != null && rowEnumerator.MoveNext())
            {
                var row = rowEnumerator.Current;
                var Shop = new Shop();

                var slno = row.GetCell(0);
                Shop.SLNO = GetValue(slno);

                var region = row.GetCell(1);
                Shop.Region = GetValue(region);

                var teritorry = row.GetCell(2);
                Shop.Territory = GetValue(teritorry);

                var town = row.GetCell(3);
                Shop.Town = GetValue(town);

                var shopName = row.GetCell(4);
                Shop.ShopName = GetValue(shopName);

                var address = row.GetCell(5);
                Shop.ShopAddress = GetValue(address);

                var shopType = row.GetCell(6);
                Shop.ShopType = GetValue(shopType);

                var slab = row.GetCell(7);
                Shop.SLAB = GetValue(slab);

                var phone = row.GetCell(8);
                Shop.Phon = GetValue(phone);

                var dmsCode = row.GetCell(9);
                Shop.DMS_CODE = GetValue(dmsCode);

                Shops.Add(Shop);
            }
            return Shops;
        }

        private static string GetValue(ICell cell)
        {
            var value = "";
            switch (cell.CellType)
            {
                case CellType.NUMERIC:
                    value += cell.NumericCellValue;
                    break;
                case CellType.BOOLEAN:
                    value += cell.BooleanCellValue;
                    break;
                case CellType.STRING:
                    value += cell.StringCellValue;
                    break;
                case CellType.BLANK:
                    break;
                case CellType.Unknown:
                    break;
            }
            return value;
        }
    }
}