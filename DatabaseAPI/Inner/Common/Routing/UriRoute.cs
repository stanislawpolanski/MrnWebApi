using DatabaseAPI.Common.Exceptions;
using System;
using System.Linq;
using System.Text;

namespace DatabaseAPI.Common.Routing
{
    public class UriRoute
    {
        private String uriRoute = String.Empty;

        public static string GetRouteStringFromNodes(params string[] nodes)
        {
            return GetRouteFromNodes(nodes).ToString();
        }

        public static UriRoute GetRouteFromNodes(params string[] nodes)
        {
            UriRoute route = new UriRoute();
            route.AddNodesToTheRoute(nodes);
            return route;
        }

        public override string ToString()
        {
            return uriRoute;
        }

        public void AddNodesToTheRoute(params string[] nodes)
        {
            uriRoute += BuildRouteFromNodes(nodes).ToString();
        }

        private static StringBuilder BuildRouteFromNodes(string[] nodes)
        {
            StringBuilder temporaryRouteBuilder = new StringBuilder();

            nodes
                .OfType<string>()
                .ToList()
                .ForEach(node => AddNodeToTheTemporaryRoute(node, temporaryRouteBuilder));

            return temporaryRouteBuilder;
        }

        private static void AddNodeToTheTemporaryRoute(string node, StringBuilder finalRouteStringBuilder)
        {
            ValidateNode(node);
            String finalNode = node.StartsWith("/") ? node : GetNodeWithSlashInTheBeginning(node);
            finalRouteStringBuilder.Append(finalNode.ToLower());
        }

        private static string GetNodeWithSlashInTheBeginning(string node)
        {
            return new StringBuilder().Append("/").Append(node).ToString();
        }

        private static void ValidateNode(string node)
        {
            if (node.EndsWith("/"))
            {
                throw new ForbiddenUseOfCharacterInAStringException("Slash in the end of a path.");
            }
        }
    }
}
