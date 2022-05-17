using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ApiRoutes
{
    public static class CarRoute
    {
        public const string Base = "Car/";

        public const string GetAll = nameof(GetAll);
        public const string GetAllStream = nameof(GetAllStream);
        public const string GetById = nameof(GetById) + "/";
        public const string Update = nameof(Update);
        public const string Create = nameof(Create);
        public const string Delete = nameof(Delete) + "/";

        // helpers
        public const string GetAllPath = Base + GetAll;
        public const string GetAllStreamPath = Base + GetAllStream;
        public static readonly Func<int, string> GetByIdPath = id => Base + GetById + $"{id}";
        public const string UpdatePath = Base + Update;
        public const string CreatePath = Base + Create;
        public static readonly Func<int, string> DeletePath = id => Base + Delete + $"{id}";
    }
}
