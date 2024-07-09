using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmindLibrary
{
    public static class XmindService
    {
        public static Root CreateDefaultXmind()
        {
            var constants = new Constants();
            var xmind = new Root(constants._RootTopic);
            Root.SetHeight(xmind, constants._DefaultRootHeight);
            Root.SetWidth(xmind, constants._DefaultRootWidth);
            xmind.Sheet.Title = constants._SheetTitle;
            xmind.Sheet.Description = constants._SheetDescription;
            CreateMainTopic(xmind, new Constants()._defaultTopicNumber);
            return xmind;
        }

        public static Root CreateMainTopic(Root xmind, int v)
        {
            var mainTopics = GenerateTopics(xmind, v, new Constants()._MainTopic);
            foreach (var mainTopic in mainTopics)
            {
                xmind.Children.Add(mainTopic);
            }
            return xmind;
        }

        public static Root CreateFloatingTopic(Root xmind, int v)
        {
            var floatingTopics = GenerateTopics(xmind, v, new Constants()._FloatingTopic);
            foreach (var floatingTopic in floatingTopics)
            {
                xmind.Children.Add(floatingTopic);
            }

            return xmind;
        }

        private static List<Children> GenerateTopics(Root xmind, int count, string type)
        {
            var constants = new Constants();
            var existingTopicCount = xmind.Children.Count;

            for (int i = 0; i < count; i++)
            {
                int topicNumber = existingTopicCount + i + 1;
                var name = $"{type} {topicNumber}";

                var topic = new Children();
                topic.SetType(type);
                Children.SetHeight(topic, 1.0);
                Children.SetWidth(topic, 3.0);
                topic.SetID(i);
                topic.SetName(name);

                constants._allChildren.Add(topic);
            }

            return constants._allChildren;
        }


        public static Root DeleteTopic(Root xmind, List<int> idsToRemove)
        {
            var list = xmind.Children;
            list.RemoveAll(child => idsToRemove.Contains(child.ID));
            return xmind;
        }

        public static void Connect(Root xmind, int startID, int endID)
        {
            // Find the start and end nodes by their IDs
            var startNode = xmind.Children.Find(i => i.ID == startID);
            var endNode = xmind.Children.Find(i => i.ID == endID);

            // Create a relationship between the nodes (if both nodes are found)
            var relationship = startNode?.ID != null && endNode?.ID != null
                ? new Relationship("", startNode.ID, endNode.ID)
                : null;
            if (relationship != null)
            {
                AddRelationship(xmind, relationship);
            }
        }

        public static void AddRelationship(Root xmind, Relationship relationship)
        {
            xmind.RelationshipList.Add(relationship);
        }

        public static void ChangeRelationShipName(Root xmind, Guid ID, string newName)
        {
            var relationship = xmind.GetRelationship().Find(b => b.ID == ID);
            if (relationship != null)
            {
                relationship.title = newName;
            }
        }

        public static Children CreateSubTopic(Children main_topic_1, int v)
        {
            var constants = new Constants();
            var existingTopicCount = main_topic_1.Subtopic.Count;
            for (int i = 0; i < v; i++)
            {
                int topicNumber = existingTopicCount + i + 1; // Calculate the unique topic number
                constants._child = new Children();
                var name = $"{constants._SubTopic} {topicNumber}";
                constants._child.SetType(constants._SubTopic);
                Children.SetHeight(constants._child, 1.0);
                Children.SetWidth(constants._child, 3.0);
                constants._child.SetID(i);
                constants._child.SetName(name);
                main_topic_1.Subtopic.Add(constants._child);
            }
            return main_topic_1;
        }

        public static void ChangeRootName(Root xmind, string newname)
        {
            xmind.Title = newname;
        }

        public static void ChangeTopicName(Children children, string newname)
        {
            children.Title = newname;
        }

        public static void DeleteRelationship(Root xmind, Guid relationship_id1)
        {
            var List_of_rela = xmind.RelationshipList;

            var rela_to_be_deleted = List_of_rela.Find(b => b.ID.Equals(relationship_id1));

            if (rela_to_be_deleted != null)
            {
                List_of_rela.Remove(rela_to_be_deleted);
            }
        }


        public static void Test()
        {
            var a = 1;
            var b = 2;
            var c = 3;

        }
    }
}
