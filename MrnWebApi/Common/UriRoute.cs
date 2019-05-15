using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrnWebApi.Common
{
    public class UriRoute
    {
        private String uriRoute = String.Empty;

        public String GetRoute()
        {
            return uriRoute;
        }

        public void AddPaths(List<String> nodes)
        {
            StringBuilder finalRouteStringBuilder = new StringBuilder();
            nodes.ForEach(currentPath => finalRouteStringBuilder.Append("/" + currentPath));

            uriRoute = uriRoute + finalRouteStringBuilder.ToString();
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
