using Newtonsoft.Json;

namespace Nest6
{
	[JsonObject]
	public interface IInput { }

	public abstract class InputBase : IInput
	{
		internal abstract void WrapInContainer(IInputContainer container);
	}
}
