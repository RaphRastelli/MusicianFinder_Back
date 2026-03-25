using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace MusicianFinder.Domain.Models
{
    public class ProjectType
    {
        public int ProjectTypeId { get; private set; }
        public string TypeName { get; private set; } = null!;

        // Properties from other models
        public ICollection<MusicianProjectType> MM_MusicianProjectTypes { get; set; } = [];
        public ICollection<Musician> Musicians { get; set; } = [];

        // Ctor
        // Vide pour EntityFramework
        private ProjectType() { }

        // Ctor pour récupérer un type
        public ProjectType(int projectTypeId, string typeName)
        {
            ProjectTypeId = projectTypeId;
            TypeName = typeName;
        }
    }
}
