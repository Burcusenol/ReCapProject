using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        //public static string Add(IFormFile file)
        //{
        //    var result = newPath(file);

        //    var sourcepath = Path.GetTempFileName();

        //    using (var stream = new FileStream(sourcepath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    File.Move(sourcepath, result.newPath);

        //    return result.Path2;
        //}

        //public static string Update(string sourcePath, IFormFile file)
        //{
        //    var result = newPath(file);
        //    using (var stream = new FileStream(result.newPath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    File.Delete(sourcePath);

        //    return result.Path2;
        //}

        //public static IResult Delete(string path)
        //{
        //    File.Delete(path);
        //    return new SuccessResult();
        //}

        //public static (string newPath, string Path2) newPath(IFormFile file)
        //{
        //    FileInfo ff = new FileInfo(file.FileName);
        //    string fileExtension = ff.Extension;
        //    var newFileName = Guid.NewGuid().ToString("N") + fileExtension;
        //    string path12 = @"\wwwroot\CarImages\";
        //    string result = Environment.CurrentDirectory + path12 + newFileName;
        //    return (result, $"\\CarImages\\{newFileName}");
        //}
    

    public static string AddAsync(IFormFile file)
    {
        var result = newPath(file);
        try
        {
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                    file.CopyTo(stream);

            File.Move(sourcepath, result.newPath);
        }
        catch (Exception exception)
        {

            return exception.Message;
        }

        return result.Path2;
    }

    public static string UpdateAsync(string sourcePath, IFormFile fromfile)
    {
        var result = newPath(fromfile);

        try
        {
            //File.Copy(sourcePath,result);

            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result.newPath, FileMode.Create))
                {
                    fromfile.CopyTo(stream);
                }
            }

            File.Delete(sourcePath);
        }
        catch (Exception excepiton)
        {
            return excepiton.Message;
        }

        return result.Path2;
    }

    public static IResult DeleteAsync(string path)
    {
        File.Delete(path);
        return new SuccessResult();
    }



        //public static (string newPath, string Path2) newPath(IFormFile file)
        //{
        //    FileInfo ff = new FileInfo(file.FileName);
        //    string fileExtension = ff.Extension;
        //    var newFileName = Guid.NewGuid().ToString("N") + fileExtension;
        //    string path12 = @"\wwwroot\CarImages\";
        //    string result = Environment.CurrentDirectory + path12 + newFileName;
        //    return (result, $"\\CarImages\\{newFileName}");
        //}
        public static (string newPath, string Path2) newPath(IFormFile fromfile)
        {
            FileInfo ff = new FileInfo(fromfile.FileName);
            string fileExtension = ff.Extension;

            var newFileName = Guid.NewGuid().ToString("N")
               + "_" + DateTime.Now.Month + "_"
               + DateTime.Now.Day + "_"
               + DateTime.Now.Year + fileExtension;


            string path12 = @"\wwwroot\CarImages\";
            string result = Environment.CurrentDirectory + path12 + newFileName;
            return (result, $"\\CarImages\\{newFileName}");

        }
    }
}


