﻿using NHibernate.Envers.Configuration.Attributes;

namespace NHibernate.Envers.Tests.Integration.SuperClass.AuditOverride
{
	[Audited]
	[AuditOverride(ForClass = typeof(AuditedBaseEntity), IsAudited = false)]
	[AuditOverride(PropertyName = "Number1", IsAudited = true)]
	public class MixedOverrideEntity : AuditedBaseEntity
	{
		public virtual string Str2 { get; set; }

		public override bool Equals(object obj)
		{
			var other = obj as MixedOverrideEntity;
			if (other == null)
				return false;
			if (!base.Equals(obj))
				return false;

			return Str2 == null ? other.Str2 == null : Str2.Equals(other.Str2);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() ^ (Str2 == null ? 0 : Str2.GetHashCode());
		}
	}
}