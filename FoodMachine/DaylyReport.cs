using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FoodMachine
{
    public class DaylyReport
    {
        Product product;
        private Timer timer;
        private const int hours = 24;
        private string directoryPath = "C:\\Users\\hadas\\OneDrive\\מסמכים\\הנדסאים\\שנה ב\\desighn patterns\\FoodMachine";
        EFileType fileType;
        public DaylyReport(Product product)
        {
            int fileCreationIntervalMilliseconds = hours * 60 * 60 * 1000;
            timer = new Timer(fileCreationIntervalMilliseconds);
            timer.Elapsed += FileCreationTimer_Elapsed;
            timer.Start();
            this.product = product;  
            this.fileType = new EFileType();
        }
        private void FileCreationTimer_Elapsed(object sender, ElapsedEventArgs e) 
        {
            string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "." + fileType;
            string filePath = Path.Combine(directoryPath, fileName);
            string details = $"Product: {product.Name}, Price: {product.Price}";
            File.WriteAllText(filePath, details);

        }
    }
}
