using MrnWebApi.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MrnWebApi.Common.Routing
{
    public class UriRoute
    {
        private String uriRoute = String.Empty;

        public void AddPaths(List<String> nodes)
        {
            StringBuilder finalRouteStringBuilder = new StringBuilder();

            foreach (String node in nodes)
            {
                if(node.EndsWith("/"))
                {
                    throw new ForbiddenUseOfCharacterInAStringException("saa");
                }

                String finalNode;

                if (node.StartsWith("/"))
                {
                    finalNode = node;
                }
                else
                {
                    finalNode = new StringBuilder().Append("/").Append(node).ToString();
                    
                }
                finalRouteStringBuilder.Append(finalNode.ToLower());
            }

            uriRoute = uriRoute + finalRouteStringBuilder.ToString();
        }

        public override string ToString()
        {
            return uriRoute;
        }

        public class Builder
        {
            private List<String> Nodes = new List<String>();

            public Builder Path(String childNode)
            {
                Nodes.Add(childNode);
                return this;
            }

            public UriRoute Build()
            {
                UriRoute route = new UriRoute();
                route.AddPaths(Nodes);
                return route;
            }
        }
    }
}
