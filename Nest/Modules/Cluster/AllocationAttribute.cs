﻿using System.Collections.Generic;
using System.Linq;

namespace Nest6
{
	public interface IAllocationAttributes : IIsADictionary<string, IList<string>>
	{
		IDictionary<string, IList<string>> Attributes { get; }
	}

	public class AllocationAttributes : IsADictionaryBase<string, IList<string>>, IAllocationAttributes
	{
		IDictionary<string, IList<string>> IAllocationAttributes.Attributes => BackingDictionary;

		public void Add(string attribute, params string[] values) => BackingDictionary.Add(attribute, values.ToList());

		public void Add(string attribute, IEnumerable<string> values) => BackingDictionary.Add(attribute, values.ToList());
	}

	public class AllocationAttributesDescriptor
		: IsADictionaryDescriptorBase<AllocationAttributesDescriptor, IAllocationAttributes, string, IList<string>>
	{
		public AllocationAttributesDescriptor() : base(new AllocationAttributes()) { }
	}
}
