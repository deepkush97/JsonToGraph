using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
    
namespace JsonToGraph.Library
{
    public class GraphNode
    {
        internal string FunctionName { get; set; }
        public string Name { get; set; }
        public object Value{ get; set; }
        public JTokenType Type { get; set; }
        public int ChildrenCount { get; set; }
        public List<GraphNode> ChildNodes { get; set; } = new List<GraphNode>();

        public static GraphNode GetInstance (string name, string functionName, JTokenType type)
        {
            return new GraphNode { Name = name, FunctionName = functionName, Type = type };
        }
    }
}
