namespace XmindLibrary
{
    public class Children
    {
        public List<Children> Subtopic { get; internal set; }

        public int ID { get; internal set; }
        public string? Type { get; internal set; }
        public string? Name { get; private set; }
        public double Height { get; internal set; }
        public double Width { get; internal set; }
        public string? Title { get; internal set; }
        public Children()
        {
            Subtopic = [];
        }

        public void SetID(int i)
        {
            ID = i + 1;
        }

        public void SetName(string type)
        {
            Name = type;
        }

        public void SetType(string v)
        {
            Type = v;
        }

        public List<Children> GetChildren()
        {
            return Subtopic;
        }

        internal static void SetHeight(Children child, double v)
        {
            child.Height = v;
        }

        internal static void SetWidth(Children child, double v)
        {
            child.Width = v;
        }
    }
}