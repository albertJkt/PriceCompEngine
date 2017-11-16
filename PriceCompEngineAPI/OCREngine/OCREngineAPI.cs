using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCREngine
{
    public enum ResultFormat
    {
        TEXT,
        JSON
    };

    public class OCREngineAPI
    {
        public static string GetImageText(byte[] image, string language, ResultFormat format)
        {
            if (image == null)
                return "";

            GoogleAnnotate annotate = new GoogleAnnotate();
            annotate.GetText(image, language);

            if (string.IsNullOrEmpty(annotate.Error) == false)
                return annotate.Error;
            else
            {
                if (format == ResultFormat.TEXT)
                    return annotate.TextResult;
                else if (format == ResultFormat.JSON)
                    return annotate.JsonResult;
                else return "Wrong formt selected";
            }
        }
    }
}
