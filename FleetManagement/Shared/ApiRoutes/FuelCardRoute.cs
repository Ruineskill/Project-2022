using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ApiRoutes
{
    public class FuelCardRoute
    {
        public const string Base = "FuelCard/";

        public const string GetAll = nameof(GetAll);
        public const string GetAllStream = nameof(GetAllStream);
        public const string GetById = nameof(GetById) + "/";
        public const string Update = nameof(Update);
        public const string Create = nameof(Create);
        public const string Delete = nameof(Delete) + "/";

        public const string GetAllPath = Base + GetAll;
        public const string GetAllStreamPath = Base + GetAllStream;
        public static readonly Func<int, string> GetByIdPath = id => Base + GetById + $"{id}";
        public const string UpdatePath = Base + Update;
        public const string CreatePath = Base + Create;
        public static readonly Func<int, string> DeletePath = id => Base + Delete + $"{id}";
    }
}
