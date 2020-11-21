using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonToGraph.Library
{
    public class JsonToGraphParser
    {
        public GraphNode GetNode(string json)
        {
            GraphNode node = new GraphNode();
            JToken root = JToken.Parse(json);
            switch (root.Type)
            {
                case JTokenType.Object:
                    node = ParseObject(root as JObject);
                    break;
                case JTokenType.Array:
                    node.Type = JTokenType.Array;
                    node.ChildNodes.AddRange(ParseArray(root as JArray));
                    break;
            }
            return node;
        }


        internal GraphNode ParseProperty(JProperty token)
        {
            GraphNode node = GraphNode.GetInstance(token.Path, nameof(ParseProperty), token.Type);
            node.ChildrenCount = token.Count;
            if (token.Value.Type != JTokenType.Property && token.Value.Type != JTokenType.Object && token.Value.Type != JTokenType.Array)
            {
                node.Value = token.Value;
                return node;
            }
            foreach (var children in token.Children())
            {
                node.ChildNodes.Add(GetNodeFromToken(children));
            }
            return node;
        }

        internal GraphNode GetNodeFromToken(JToken children)
        {
            switch (children.Type)
            {
                case JTokenType.Object:
                    return ParseObject(children as JObject);
                case JTokenType.Array:
                    GraphNode node = GraphNode.GetInstance(children.Path, nameof(GetNodeFromToken), children.Type);
                    node.ChildNodes.AddRange(ParseArray(children as JArray));
                    return node;
                case JTokenType.Property:
                    return ParseProperty(children as JProperty);
                default: return null;
            }
        }

        internal List<GraphNode> ParseArray(JArray token)
        {
            List<GraphNode> nodes = new List<GraphNode>();

            foreach (var children in token.Children())
            {
                nodes.Add(GetNodeFromToken(children));
            }
            return nodes;
        }

        internal GraphNode ParseObject(JObject token)
        {
            if (token == null && token.Type != JTokenType.Object && token.HasValues == false) return null;

            GraphNode node = GraphNode.GetInstance(token.Path, nameof(ParseObject), token.Type);
            node.ChildrenCount = token.Count;
            foreach (var children in token.Children())
            {
                node.ChildNodes.Add(GetNodeFromToken(children));
            }
            return node;
        }
    }
}
