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

            nodes.ForEach(node =>
                {
                    if (node.EndsWith("/"))
                        throw new ForbiddenUseOfCharacterInAStringException("Slash in the end of a path");
                    String finalNode =
                        node.StartsWith("/") ? node : new StringBuilder().Append("/").Append(node).ToString();
                    finalRouteStringBuilder.Append(finalNode.ToLower());
                });

            uriRoute = uriRoute += finalRouteStringBuilder.ToString();
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
