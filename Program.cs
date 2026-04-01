using FastReport;
using FastReport.Data;
using FastReport.Export.Image;

namespace FastReportTest;

public class Program
{
    public static void Main(string[] args)
    {
        /* STEPS
        Create registration object connection
        Create report object
        load file into report and prep

        create out directory
        save prepared file

        create image export and export jpeg format
        disport
        */
        FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

        Report report = new();
        report.Load(Path.Combine("safezone.frx"));
        report.Prepare();

        string outFolder = "Reports";
        if (!Directory.Exists(outFolder))
        {
            Directory.CreateDirectory(outFolder);
        }
        report.SavePrepared(Path.Combine(outFolder, "Prepared Report.fpx"));

        ImageExport image = new()
        {
            ImageFormat = ImageExportFormat.Jpeg
        };
        report.Export(image, Path.Combine(outFolder, "report.jpg"));

        report.Dispose();
    }
}