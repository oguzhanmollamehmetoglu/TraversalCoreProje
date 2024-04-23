using BusinessLayer.Abstract;
using OfficeOpenXml;

namespace BusinessLayer.Concrete
{
    public class ExelManager : IExelService
    {
        public byte[] ExelList<T>(List<T> t) where T : class
        {
            ExcelPackage exel = new ExcelPackage();
            var worksheet = exel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells["A1"].LoadFromCollection(t, true, OfficeOpenXml.Table.TableStyles.Light10);
            return exel.GetAsByteArray();
        }
    }
}