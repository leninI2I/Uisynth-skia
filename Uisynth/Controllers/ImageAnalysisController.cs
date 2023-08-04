using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text.Json;
using Uisynth.Models;
using SkiaSharp;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using System;
using System.Diagnostics;

namespace Uisynth.Controllers
{
    public class ImageAnalysisController : Controller
    {
        public IActionResult Index()
        {
            Imageprocessor();

            //string Mainpath = Directory.GetCurrentDirectory();
            //string SecPath = @"wwwroot\Json\imageUI.json";
            //string filePath = Path.Combine(Mainpath, SecPath);
            //string jsonContent = System.IO.File.ReadAllText(filePath);

            /////*Deserialize the JSON and pass the values into variables*/
            //var _image_details = JsonSerializer.Deserialize<ImageModel>(jsonContent);
            //foreach (var ImgCreation in _image_details.UiSynthesizer)
            //{

            //    List<string> InputTitleList = new List<string>()
            //        {
            //            ImgCreation.UiElement,
            //            ImgCreation.TextValue,
            //            ImgCreation.fontname,
            //            ImgCreation.fontweight,
            //            ImgCreation.fontsize,
            //            ImgCreation.textalign,
            //            ImgCreation.fontcolor,
            //            ImgCreation.BGColor,
            //            ImgCreation.Xcoord,
            //            ImgCreation.Ycoord,
            //            ImgCreation.FieldWidth,
            //            ImgCreation.FieldHeight,
            //            ImgCreation.TextValue2
            //        };

            //    Imageprocessor(InputTitleList);
            //}
            return View();
        }

        public void Imageprocessor()
        {
            try
            {
                //coding starts here
                SKBitmap skb = new SKBitmap(150,30);
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
                
                //font.Size = 10;
                //font.Metrics.AverageCharacterWidth = 

                //SKTypefaceStyle sKFontStyleWeight = SKTypefaceStyle.Bold;

                //// Create a new SKTypeface object with the desired font family
                //SKTypeface typeface = SKTypeface.FromFamilyName("Microsoft Sans", sKFontStyleWeight);

                SKFontStyle style = new SKFontStyle();
                
                SKFontStyleWeight weight = SKFontStyleWeight.Bold; //Fontstyle
                SKFontStyleSlant sKFontStyleSL = new SKFontStyleSlant();
                SKTypeface typeface = SKTypeface.FromFamilyName("Microsoft Sans Serif",(int)weight,20,sKFontStyleSL);

                SKFont font = new SKFont(typeface, 14, 1, 0);

                //SKMaskFilter SKMF = SKMaskFilter.CreateBlur()
                string textgen = "Discharge Date:";
                //var shader = SKShader.CreateBitmap(skb, SKShaderTileMode.Clamp, SKShaderTileMode.Clamp);

                    // Create a paint object to define the appearance of the shapes
                    var paint = new SKPaint
                    {
                        //Color = SKColors.Black,
                        IsAntialias = true, //No Change - Equivalent to SmoothingMode
                        Style = SKPaintStyle.Fill,
                        TextAlign = SKTextAlign.Left,
                        TextEncoding = SKTextEncoding.GlyphId, //Equivalent to TextRenderingHint
                        HintingLevel = SKPaintHinting.Full,
                        BlendMode = SKBlendMode.Modulate, //No Change
                        Typeface = typeface,
                        FilterQuality = SKFilterQuality.High, //Equivalent to CompositingQuality
                        IsEmbeddedBitmapText = true,
                        TextScaleX = 5.0f,
                        SubpixelText = true,
                        StrokeWidth = 2.0f,
                        ColorF = SKColors.Black,
                        IsAutohinted = true,
                        IsDither = true
                        
                        
                        
                        
                    };

                    // Draw a rectangle on the canvas
                    //canvas.DrawRect(new SKRect(50, 50, 250, 150), paint);
                    //skv.DrawText(textgen, 30, 30, paint);
                    skv.DrawText(textgen, 20, 20, font, paint);


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
                string ImageFolder = "imagesave2/";
                string FolderName = ImageFolder + fileName;

                //Create image Folder in the current directory if the folder is not available
                string RootPath = Path.Combine(Directory.GetCurrentDirectory(), ImageFolder);
                if (!Directory.Exists(RootPath))
                {
                    Directory.CreateDirectory(RootPath);
                }

                ////Save an image into the created folder 
                //using (var image = SKImage.FromBitmap(skb))
                //    using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                //        using (var stream = File(RootPath, "image/png")
                //        {
                //            data.SaveTo(stream);
                //        }


                using (var imageStream = new MemoryStream())
                {
                    
                    var data = skb.Encode(SKEncodedImageFormat.Png, 100);
                    using (var imgstr = System.IO.File.OpenWrite(FolderName))
                    {
                        data.SaveTo(imgstr);
                    }
                        
                    //imageStream.Position = 0;

                    // Return the image as a FileResult (this will prompt the browser to download the image)
                    //return File(imageStream, "image/png", "rendered_text.png");
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
