using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LocalMQ
{
	public abstract class MutexFreePipe : SafeDisposable
	{
		protected const int MinimumBufferSize = 0x10000;
		protected readonly int MessageHeaderLength = sizeof(int);
		protected readonly int StartingOffset = sizeof(int) + sizeof(bool);

		public readonly string Name;
		protected readonly EventWaitHandle NewMessageSignal;
		protected SafeMemoryMappedFile Buffer;
		protected int Offset, Length;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        protected MutexFreePipe(string name)
		{
			Name = name;

			//0x800700B7
			var mmFile = MemoryMappedFile.CreateOrOpen(name + ".0", MinimumBufferSize, MemoryMappedFileAccess.ReadWrite);

			Buffer = new SafeMemoryMappedFile(mmFile);
			NewMessageSignal = new EventWaitHandle(false, EventResetMode.AutoReset, name + ".signal");

			Length = Buffer.Length;
			Offset = StartingOffset;
		}

		protected override void DisposeCore()
		{
			base.DisposeCore();
			Buffer.Dispose();
			NewMessageSignal.Dispose();
		}
	}
}
