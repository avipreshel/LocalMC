using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalMQ
{
	public class SafeMemoryMappedFile : SafeDisposable
	{
		readonly MemoryMappedFile _mmFile;
		readonly MemoryMappedViewAccessor _accessor;
		unsafe byte* _pointer;

		public int Length { get; private set; }

		public MemoryMappedViewAccessor Accessor
		{
			get { AssertSafe(); return _accessor; }
		}

		public unsafe byte* Pointer
		{
			get { AssertSafe(); return _pointer; }
		}

		public unsafe SafeMemoryMappedFile(MemoryMappedFile mmFile)
		{
			_mmFile = mmFile;
			_accessor = _mmFile.CreateViewAccessor();
			_pointer = (byte*)_accessor.SafeMemoryMappedViewHandle.DangerousGetHandle().ToPointer();
			Length = (int)_accessor.Capacity;
		}

		unsafe protected override void DisposeCore()
		{
			base.DisposeCore();
			_accessor.Dispose();
			_mmFile.Dispose();
			_pointer = null;
		}
	}
}
