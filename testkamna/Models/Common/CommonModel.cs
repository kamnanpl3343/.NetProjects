namespace testkamna.Models.Common
{
    public class CommonModel<T>
    {
        public bool ResponseStatus { get; set; }
        public string Message { get; set; }
    
        public CommonModel()
        {
            this.List = new List<T>();
        }
        public List<T> List { get; set; }
    }
}
