using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;

namespace StackUnderflow.DatabaseModel.Models
{
    public partial class UserBadge
    {
        public int TenantId { get; set; }
        public int BadgeId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateEarned { get; set; }

        public virtual Badge Badge { get; set; }
        public virtual TenantUser TenantUser { get; set; }
    }
}
