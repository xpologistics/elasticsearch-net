using System;

namespace Nest6
{
	public class RestoreObserver : CoordinatedRequestObserverBase<IRecoveryStatusResponse>
	{
		public RestoreObserver(
			Action<IRecoveryStatusResponse> onNext = null,
			Action<Exception> onError = null,
			Action completed = null
		)
			: base(onNext, onError, completed) { }
	}
}
