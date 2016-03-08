namespace Fallout4Checklist.Entities
{
    public partial class AreaPath
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public decimal? Height { get; set; }
        public decimal? Width { get; set; }
        public decimal? CanvasTop { get; set; }
        public decimal? CanvasLeft { get; set; }

        public int AreaID { get; set; }
        public virtual Area Area { get; set; }
    }
}
