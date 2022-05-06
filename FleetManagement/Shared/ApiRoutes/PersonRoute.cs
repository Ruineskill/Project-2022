using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.ApiRoutes
{
    public static class PersonRoute
    {
        public const string Base = "Person/";

        public const string GetAll =  nameof(GetAll);
        public const string GetAllStream =  nameof(GetAllStream);
        public const string GetById = nameof(GetById);
        public const string Update =  nameof(Update);
        public const string Create =  nameof(Create);
        public const string Delete =  nameof(Delete);
    }
}
