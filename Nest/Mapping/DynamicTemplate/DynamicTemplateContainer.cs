﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Nest6
{
	[JsonConverter(typeof(DynamicTemplatesJsonConverter))]
	public interface IDynamicTemplateContainer : IIsADictionary<string, IDynamicTemplate> { }

	public class DynamicTemplateContainer : IsADictionaryBase<string, IDynamicTemplate>, IDynamicTemplateContainer
	{
		public DynamicTemplateContainer() { }

		public DynamicTemplateContainer(IDictionary<string, IDynamicTemplate> container) : base(container) { }

		public DynamicTemplateContainer(Dictionary<string, IDynamicTemplate> container) : base(container) { }

		/// <summary>
		/// Add any setting to the index
		/// </summary>
		public void Add(string name, IDynamicTemplate dynamicTemplate) => BackingDictionary.Add(name, dynamicTemplate);
	}

	public class DynamicTemplateContainerDescriptor<T>
		: IsADictionaryDescriptorBase<DynamicTemplateContainerDescriptor<T>, IDynamicTemplateContainer, string, IDynamicTemplate>
		where T : class
	{
		public DynamicTemplateContainerDescriptor() : base(new DynamicTemplateContainer()) { }

		public DynamicTemplateContainerDescriptor<T> DynamicTemplate(string name, Func<DynamicTemplateDescriptor<T>, IDynamicTemplate> selector) =>
			Assign(name, selector?.Invoke(new DynamicTemplateDescriptor<T>()));
	}
}
