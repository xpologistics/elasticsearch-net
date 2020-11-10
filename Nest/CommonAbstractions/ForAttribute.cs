﻿using System;

namespace Nest6
{
	/// <summary>
	/// DescriptorFor is a marker to rename unintuitive generated elasticsearch operation names
	/// This is used by the code generator and is only meant for internal use to map our more aptly named requests to
	/// the original elasticsearch rest spec
	/// </summary>
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	internal class DescriptorForAttribute : Attribute
	{
// ReSharper disable once UnusedParameter.Local
		public DescriptorForAttribute(string operation) { }
	}

	/// <summary>
	/// DescriptorFor is a marker to rename unintuitive generated elasticsearch operation names
	/// This is used by the code generator and is only meant for internal use to map our more aptly named requests to
	/// the original elasticsearch rest spec
	/// </summary>
	[AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
	internal class MapsApiAttribute : Attribute
	{
// ReSharper disable once UnusedParameter.Local
		public MapsApiAttribute(string restSpecName) { }
	}
}
