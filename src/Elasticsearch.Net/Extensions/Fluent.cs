using System;
using System.Runtime.CompilerServices;

namespace Elasticsearch.Net
{
	internal static class Fluent
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static TDescriptor Assign<TDescriptor, TInterface>(TDescriptor self, Action<TInterface> assign)
			where TDescriptor : class, TInterface
		{
			assign(self);
			return self;
		}
	}

}
