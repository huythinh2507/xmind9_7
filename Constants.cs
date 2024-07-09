using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmindLibrary
{
    public class Constants
    {
        public readonly string _FloatingTopic = "Floating Topic";
        public readonly string _SubTopic = "Sub Topic";
        public readonly int _defaultTopicNumber = 4;
        public readonly string _MainTopic = "Main Topic";
        public readonly string _RootTopic = "Root Topic";
        public readonly List<Children> _allChildren = [];
        public readonly List<Relationship> RelationshipList = [];
        public readonly string _SheetTitle = "Title";
        public readonly string _SheetDescription = "Description";
        public readonly double _DefaultRootHeight = 2.0;
        public readonly double _DefaultRootWidth = 5.0;
        public Children _child;
    }
}
