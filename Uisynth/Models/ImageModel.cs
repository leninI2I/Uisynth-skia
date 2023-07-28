namespace Uisynth.Models
{
    public class ImageModel
    {
        public List<Efields> UiSynthesizer { get; set; }
    }

    public class Efields
    {
        public string UiElement { get; set; }
        public string TextValue { get; set; }
        public string fontname { get; set; }
        public string fontweight { get; set; }
        public string fontsize { get; set; }
        public string textalign { get; set; }
        public string fontcolor { get; set; }
        public string BGColor { get; set; }
        public string Xcoord { get; set; }
        public string Ycoord { get; set; }
        public string FieldWidth { get; set; }
        public string FieldHeight { get; set; }
        public string TextValue2 { get; set; }
    }
}
