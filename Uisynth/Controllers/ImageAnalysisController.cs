using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text.Json;
using Uisynth.Models;
using SkiaSharp;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;

namespace Uisynth.Controllers
{
    public class ImageAnalysisController : Controller
    {
        public IActionResult Index()
        {
            string Mainpath = Directory.GetCurrentDirectory();
            string SecPath = @"wwwroot\Json\imageUI.json";
            string filePath = Path.Combine(Mainpath, SecPath);
            string jsonContent = System.IO.File.ReadAllText(filePath);

            ///*Deserialize the JSON and pass the values into variables*/
            var _image_details = JsonSerializer.Deserialize<ImageModel>(jsonContent);
            foreach (var ImgCreation in _image_details.UiSynthesizer)
            {

                List<string> InputTitleList = new List<string>()
                    {
                        ImgCreation.UiElement,
                        ImgCreation.TextValue,
                        ImgCreation.fontname,
                        ImgCreation.fontweight,
                        ImgCreation.fontsize,
                        ImgCreation.textalign,
                        ImgCreation.fontcolor,
                        ImgCreation.BGColor,
                        ImgCreation.Xcoord,
                        ImgCreation.Ycoord,
                        ImgCreation.FieldWidth,
                        ImgCreation.FieldHeight,
                        ImgCreation.TextValue2
                    };

                Imageprocessor(InputTitleList);
            }
            return View();
        }

        public void Imageprocessor(List<string> _Image_Ui_Element)
        {
            try
            {
                //coding starts here
                SKBitmap skb = new SKBitmap(150,60);
                // Create a SKImageInfo object to define the image properties
                var imageInfo = new SKImageInfo(300, 200);

                SKCanvas skv = new SKCanvas(skb);
                skv.Clear(SKColors.White);
                
                //using (var surface = SKSurface.Create(imageInfo))
                //{
                //    // Get the SKCanvas from the surface to draw on it
                //    var canvas = surface.Canvas;

                //    // Clear the canvas with a white background
                //    canvas.Clear(SKColors.White);

                //    //SKBitmap skbit = new SKBitmap(1, 1, true);

                    string textgen = "Discharge Date:";
                    // Create a paint object to define the appearance of the shapes
                    var paint = new SKPaint
                    {
                        Color = SKColors.Blue,
                        IsAntialias = true,
                        Style = SKPaintStyle.Fill,
                        TextAlign = SKTextAlign.Left,
                        TextEncoding = SKTextEncoding.Utf32,
                        HintingLevel = SKPaintHinting.Full
                        
                    };

                    // Draw a rectangle on the canvas
                    //canvas.DrawRect(new SKRect(50, 50, 250, 150), paint);
                    skv.DrawText(textgen, 30, 30, paint);


                //SKImage ski = SKImage.FromBitmap(skb);

                //Generatin a random name for the image
                //string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".Png";
                ////bitmap.Save(Server.MapPath("~/Filesave4-btnclk/") + fileName, ImageFormat.Png);

                ////ImageEncoder IEC = new PngEncoder();
                ////IEC.Encode(image);
                //string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "imagesave\\");

                //if (!Directory.Exists(folderPath))
                //{
                //    Directory.CreateDirectory(folderPath);
                //}
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".Png";
                string ImageFolder = "imagesave/";
                string FolderName = ImageFolder + fileName;

                //Create image Folder in the current directory if the folder is not available
                string RootPath = Path.Combine(Directory.GetCurrentDirectory(), ImageFolder);
                if (!Directory.Exists(RootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }

                //Save an image into the created folder 
                using (var image = SKImage.FromBitmap(skb))
                    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                        using (var stream = System.IO.File.OpenWrite(FolderName))
                        {
                            data.SaveTo(stream);
                        }

                //var uploadedFile = Request.Form.Files[0];

                //using (var stream = uploadedFile.OpenReadStream())
                //{
                //    // Load the image using SkiaSharp
                //    using (var bitmap = SKBitmap.Decode(stream))
                //    {

                //        string savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", uploadedFile.FileName);
                //        using (var output = File(savePath,))
                //        {
                //            bitmap.Encode(SKEncodedImageFormat.Png, 100).SaveTo(output);
                //        }
                //    }
                //}

                //// Save the SKImage from the surface
                //using (var image = surface.Snapshot())
                //{
                //    // Encode the image to a byte array (PNG format)
                //    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                //    {
                //        // Convert the byte array to a stream
                //        using (var stream = new MemoryStream(data.ToArray()))
                //        {
                //            // Return the image as a FileResult
                //            File(stream, "image/png", "generated_image.png");
                //        }
                //    }
                //}
                //}
            }
            catch (Exception ex)
            {
                //Response.Write(ex.Message);
            }
        }

    }
}
