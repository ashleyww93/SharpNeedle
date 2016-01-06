using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binarysharp.MemoryManagement;
using Binarysharp.MemoryManagement.Assembly.CallingConvention;
using Binarysharp.MemoryManagement.Modules;

namespace SharpNeedle
{
    public class PayloadInjector
    {
        private Process targetProcess;
        private string domainPath;
        private string payloadPath;
        private string payloadArgs;
        private string domainName;
        private string payloadName;
        public PayloadInjector(Process _targetProcess, string _domainPath, string _domainName, string _payloadPath, string _payloadName, string _payloadArgs)
        {
            targetProcess = _targetProcess;
            domainPath = _domainPath;
            domainName = _domainName;
            payloadPath = _payloadPath;
            payloadArgs = _payloadArgs;
            payloadName = _payloadName;
            if (!payloadPath.EndsWith("\\"))
                payloadPath = payloadPath + "\\";

            if (!domainPath.EndsWith("\\"))
                domainPath = domainPath + "\\";
        }

        private MemorySharp MemorySharp;
        public void InjectAndWait()
        {
            this.MemorySharp = new MemorySharp(targetProcess);

            MemorySharp.Modules.Inject(domainPath + "\\" + domainName, true);
            RemoteFunction remoteFunction = this.MemorySharp[domainName]["LoadDomainHostSettings"];

            object[] arrayObjects = new[] { payloadPath, payloadName, payloadArgs };
            remoteFunction.Execute(CallingConventions.Cdecl, arrayObjects);
            this.MemorySharp[domainName]["HostDomain"].Execute(CallingConventions.Cdecl, new object[] {});

        }

        public void InjectAndForget()
        {
            ThreadPool.QueueUserWorkItem(callback => InjectAndWait());
        }






        #region Enums
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [Flags]
        public enum FreeType
        {
            Decommit = 0x4000,
            Release = 0x8000,
        }

        [Flags]
        public enum ThreadFlags
        {
            /// <summary>
            /// The thread will execute immediately.
            /// </summary>
            THREAD_EXECUTE_IMMEDIATELY = 0,
            /// <summary>
            /// The thread will be created in a suspended state.  Use <see cref="Imports.ResumeThread"/> to resume the thread.
            /// </summary>
            CREATE_SUSPENDED = 0x04,
            /// <summary>
            /// The dwStackSize parameter specifies the initial reserve size of the stack. If this flag is not specified, dwStackSize specifies the commit size.
            /// </summary>
            STACK_SIZE_PARAM_IS_A_RESERVATION = 0x00010000,
            /// <summary>
            /// The thread is still active.
            /// </summary>
            STILL_ACTIVE = 259,
        }

        [Flags]
        public enum ThreadWaitValues : uint
        {
            /// <summary>
            /// The object is in a signaled state.
            /// </summary>
            WAIT_OBJECT_0 = 0x00000000,
            /// <summary>
            /// The specified object is a mutex object that was not released by the thread that owned the mutex object before the owning thread terminated. Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
            /// </summary>
            WAIT_ABANDONED = 0x00000080,
            /// <summary>
            /// The time-out interval elapsed, and the object's state is nonsignaled.
            /// </summary>
            WAIT_TIMEOUT = 0x00000102,
            /// <summary>
            /// The wait has failed.
            /// </summary>
            WAIT_FAILED = 0xFFFFFFFF,
            /// <summary>
            /// Wait an infinite amount of time for the object to become signaled.
            /// </summary>
            INFINITE = 0xFFFFFFFF,
        }

        #endregion

        #region DLLImport

        [DllImport("kernel32.dll")]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess,
                                                    IntPtr lpAddress,
                                                    int dwSize,
                                                    AllocationType flAllocationType,
                                                    MemoryProtection flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags DesiredAccess,
                                                    bool bInheritHandle,
                                                    int dwProcessId);

        [DllImport("kernel32", CharSet = CharSet.Ansi)]
        static extern IntPtr GetProcAddress(IntPtr hModule,
                                                    string procedureName);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess,
                                                    IntPtr lpBaseAddress,
                                                    IntPtr lpBuffer,
                                                    int nSize,
                                                    out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess,
                                                    IntPtr lpThreadAttributes,
                                                    uint dwStackSize,
                                                    IntPtr lpStartAddress,
                                                    IntPtr lpParameter,
                                                    ThreadFlags dwCreationFlags,
                                                    out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle,
                                                    UInt32 dwMilliseconds);

        [DllImport("kernel32.dll")]
        static extern bool GetExitCodeThread(IntPtr hThread,
                                                out IntPtr lpExitCode);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool VirtualFreeEx(IntPtr hProcess,
                                                IntPtr lpAddress,
                                                int dwSize,
                                                FreeType dwFreeType);

        #endregion

        #region Memory Write
        private static bool WriteUnicodeString(IntPtr hProcess, IntPtr dwAddress, string Value)
        {
            IntPtr lpBuffer = IntPtr.Zero;
            int iBytesWritten = 0;
            int nSize = 0;

            try
            {
                nSize = Value.Length * 2;
                lpBuffer = Marshal.StringToHGlobalUni(Value);

                WriteProcessMemory(hProcess, dwAddress, lpBuffer, nSize, out iBytesWritten);

                if (nSize != iBytesWritten)
                    throw new Exception("WriteUnicodeString failed!  Number of bytes actually written differed from request.");
            }
            catch
            {
                return false;
            }
            finally
            {
                if (lpBuffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(lpBuffer);
            }
            return true;
        }

        private static bool WriteAsciiString(IntPtr hProcess, IntPtr dwAddress, string Value)
        {
            IntPtr lpBuffer = IntPtr.Zero;
            int iBytesWritten = 0;
            int nSize = 0;

            try
            {
                nSize = Value.Length * 1;
                lpBuffer = Marshal.StringToHGlobalAnsi(Value);

                WriteProcessMemory(hProcess, dwAddress, lpBuffer, nSize, out iBytesWritten);

                if (nSize != iBytesWritten)
                    throw new Exception("WriteUnicodeString failed!  Number of bytes actually written differed from request.");
            }
            catch
            {
                return false;
            }
            finally
            {
                if (lpBuffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(lpBuffer);
            }

            return true;
        }

        private static bool WriteBytes(IntPtr hProcess, IntPtr dwAddress, byte[] lpBytes)
        {
            IntPtr lpBuffer = IntPtr.Zero;
            int iBytesWritten = 0;

            try
            {
                lpBuffer = Marshal.AllocHGlobal(Marshal.SizeOf(lpBytes[0]) * lpBytes.Length); //allocate unmanaged memory

                Marshal.Copy(lpBytes, 0, lpBuffer, lpBytes.Length);

                WriteProcessMemory(hProcess, dwAddress, lpBuffer, lpBytes.Length, out iBytesWritten);

                if (lpBytes.Length != iBytesWritten)
                    throw new Exception("WriteBytes failed!  Number of bytes actually written differed from request.");
            }
            catch
            {
                return false;
            }
            finally
            {
                if (lpBuffer != IntPtr.Zero)
                    Marshal.FreeHGlobal(lpBuffer);
            }

            return true;
        }

        #endregion

        #region InjectDLL

        private static IntPtr InjectDllCreateThread(IntPtr hProcess, string szDllPath)
        {
            if (hProcess == IntPtr.Zero)
                throw new ArgumentNullException("hProcess");

            if (szDllPath.Length == 0)
                throw new ArgumentNullException("szDllPath");

            if (!szDllPath.Contains("\\"))
                szDllPath = System.IO.Path.GetFullPath(szDllPath);

            if (!System.IO.File.Exists(szDllPath))
                throw new ArgumentException("DLL not found.", "szDllPath");

            IntPtr dwBaseAddress = IntPtr.Zero;
            IntPtr lpLoadLibrary;
            IntPtr lpDll;
            IntPtr hThread;

            lpLoadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (lpLoadLibrary != IntPtr.Zero)
            {
                lpDll = VirtualAllocEx(hProcess, IntPtr.Zero, 1000, AllocationType.Commit, MemoryProtection.ExecuteReadWrite);

                if (lpDll != IntPtr.Zero)
                {
                    if (WriteAsciiString(hProcess, lpDll, szDllPath))
                    {
                        IntPtr dwThreadId;
                        hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, lpLoadLibrary, lpDll, ThreadFlags.THREAD_EXECUTE_IMMEDIATELY, out dwThreadId);

                      //  IntPtr p = GetProcAddress(hThread, "HostDomain");

                        //wait for thread handle to have signaled state
                        //exit code will be equal to the base address of the dll
                        if (WaitForSingleObject(hThread, 5000) == (uint)ThreadWaitValues.WAIT_OBJECT_0)
                            GetExitCodeThread(hThread, out dwBaseAddress);

                        CloseHandle(hThread);
                    }

                    VirtualFreeEx(hProcess, lpDll, 0, FreeType.Release);
                }
            }

            return dwBaseAddress;
        }
        #endregion

    }
}
