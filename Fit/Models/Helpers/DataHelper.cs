using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Fit.Models.Helpers
{
    public class DataHelper
    {
        public static String SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            String ImagePath = "";
            if (image != null)
            {
                string guid = Guid.NewGuid().ToString();
                ImagePath = pathToFile + guid + ".jpg";
                var tempA = Image.FromStream(image.InputStream);
                var tempB = new Bitmap(tempA);
                if (!Directory.Exists(serverPath + "/Images/")) Directory.CreateDirectory(serverPath + "/Images/");
                if (!Directory.Exists(serverPath + "/Images/")) Directory.CreateDirectory(serverPath + "/Images/");
                tempB.Save(serverPath + ImagePath, ImageFormat.Jpeg);
                tempA.Dispose();
                tempB.Dispose();
            }
            return ImagePath;
        }

        public static bool DeleteImage(String serverPath, String filePath)
        {
            var temp = serverPath + filePath;
            if (!String.IsNullOrEmpty(temp))
            {
                if (File.Exists(temp))
                {
                    File.Delete(temp);
                    return true;
                }
            }
            return false;
        }

        public static List<string> GetTagList()
        {
            var db = new FitContext();
            var allTags = db.Exercises.ToList();
            var usedTags = (from m in allTags
                            orderby m.Tag
                            select m.Tag).Distinct().ToList();
            return usedTags;

        } 
    }
}