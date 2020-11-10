﻿using System;
using System.Collections.Generic;

namespace Nest6
{
	public class RoleMappingRulesDescriptor
		: DescriptorPromiseBase<RoleMappingRulesDescriptor, List<RoleMappingRuleBase>>, IPromise<List<RoleMappingRuleBase>>
	{
		public RoleMappingRulesDescriptor() : base(new List<RoleMappingRuleBase>()) { }

		// TODO: Remove in 7.x as it's exposed on base
		List<RoleMappingRuleBase> IPromise<List<RoleMappingRuleBase>>.Value => PromisedValue;

		private RoleMappingRulesDescriptor Add(RoleMappingRuleBase m)
		{
			PromisedValue.AddIfNotNull(m);
			return this;
		}

		public RoleMappingRulesDescriptor DistinguishedName(string name) => Add(new DistinguishedNameRule(name));

		public RoleMappingRulesDescriptor Username(string username) => Add(new UsernameRule(username));

		public RoleMappingRulesDescriptor Groups(params string[] groups) => Add(new GroupsRule(groups));

		public RoleMappingRulesDescriptor Groups(IEnumerable<string> groups) => Add(new GroupsRule(groups));

		public RoleMappingRulesDescriptor Realm(string realm) => Add(new RealmRule(realm));

		public RoleMappingRulesDescriptor Metadata(string key, object value) => Add(new MetadataRule(key, value));

		public RoleMappingRulesDescriptor Any(Func<RoleMappingRulesDescriptor, IPromise<List<RoleMappingRuleBase>>> selector) =>
			Add(new AnyRoleMappingRule(selector?.Invoke(new RoleMappingRulesDescriptor())?.Value));

		public RoleMappingRulesDescriptor All(Func<RoleMappingRulesDescriptor, IPromise<List<RoleMappingRuleBase>>> selector) =>
			Add(new AllRoleMappingRule(selector?.Invoke(new RoleMappingRulesDescriptor())?.Value));

		public RoleMappingRulesDescriptor Except(Func<RoleMappingRuleDescriptor, RoleMappingRuleBase> selector) =>
			Add(new ExceptRoleMappingRole(selector?.Invoke(new RoleMappingRuleDescriptor())));
	}
}
