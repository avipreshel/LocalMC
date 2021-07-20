using System;

namespace LocalMQ
{
	public class SafeDisposable : IDisposable
	{
		public object DisposeLock = new object();
		public bool IsDisposed { get; private set; }

		public void Dispose()
		{
			lock (DisposeLock)
				if (!IsDisposed)
				{
					IsDisposed = true;
					DisposeCore();
				}
		}

		protected virtual void DisposeCore() { }

		public void AssertSafe()
		{
			lock (DisposeLock)
				if (IsDisposed)
					throw new ObjectDisposedException(GetType().Name + " has been disposed");
		}
	}
}
