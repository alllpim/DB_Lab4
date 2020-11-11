using System;
using System.Collections.Generic;

namespace KindergartenMVCWebApp.Models
{
    public partial class GroupType
    {
        public GroupType()
        {
            Groups = new HashSet<Group>();
        }

        public int Id { get; set; }
        public string NameOfType { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}
