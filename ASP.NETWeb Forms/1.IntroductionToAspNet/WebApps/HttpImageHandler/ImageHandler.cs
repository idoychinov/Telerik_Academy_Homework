using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace HttpImageHandler
{
    /// <summary>
    /// Currently makes the request string between the host and .img as image.
    /// </summary>
    public class ImageHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            using(var bitmap = new System.Drawing.Bitmap(context.Server.MapPath("images/image.png")))
            using(var graphics = Graphics.FromImage(bitmap))
            {
                var imageName = context.Request.RawUrl.ToString();
                imageName = imageName.Substring(1, imageName.Length - 5);
                graphics.DrawString(imageName,new Font("Arial",18),new SolidBrush(Color.BlueViolet),new PointF());
                context.Response.ContentType = "image/png";
                bitmap.Save(context.Response.OutputStream, ImageFormat.Png);
            }

            //context.Request.ContentType = "text/plain";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}