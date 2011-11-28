﻿using NHibernate.Envers.Configuration.Attributes;

namespace NHibernate.Envers.Tests.Integration.SuperClass.AuditParents
{
	[Audited(AuditParents = new[] { typeof(MappedGrandParentEntity) })]
	public class ChildCompleteEntity : MappedParentEntity
	{
		public virtual string Child { get; set; }

		public override bool Equals(object obj)
		{
			var casted = obj as ChildCompleteEntity;
			if (casted == null)
				return false;
			if (!base.Equals(obj))
				return false;
			return Child != null ? Child.Equals(casted.Child) : casted.Child == null;
		}

		public override int GetHashCode()
		{
			var result = base.GetHashCode();
			result = 31 * result + (Child != null ? Child.GetHashCode() : 0);
			return result;
		}
	}
}