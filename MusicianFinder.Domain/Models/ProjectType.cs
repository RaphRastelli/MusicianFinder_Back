using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ProjectType
    {
        public long ProjectTypeId { get; private set; }
        public string TypeName { get; private set; } = null!;

        // Ctor
        // Vide pour EntityFramework
        private ProjectType() { }

        // Ctor pour récupérer un type
        public ProjectType(long projectTypeId, string typeName)
        {
            ProjectTypeId = projectTypeId;
            TypeName = typeName;
        }
    }
}
