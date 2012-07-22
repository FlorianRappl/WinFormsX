using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Provides API calls for file management
    /// </summary>
    public class File
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr CreateFileW(IntPtr lpFileName, Int32 dwDesiredAccess, Int32 dwShareMode, IntPtr lpSecurityAttributes, Int32 dwCreationDisposition, UInt32 dwFlagsAndAttributes, IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean SetFilePointerEx(IntPtr hFile, long liDistanceToMove, [Out, Optional] IntPtr lpNewFilePointer, UInt32 dwMoveMethod);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 WriteFile(IntPtr hFile, IntPtr lpBuffer, UInt32 nNumberOfBytesToWrite, ref UInt32 lpNumberOfBytesWritten, IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 ReadFile(IntPtr hFile, IntPtr lpBuffer, UInt32 nNumberOfBytesToRead, ref UInt32 lpNumberOfBytesRead, IntPtr lpOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 FlushFileBuffers(IntPtr hFile);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 SetFileAttributesW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName, Int32 dwFileAttributes);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 GetShortPathNameW([MarshalAs(UnmanagedType.LPWStr)]string lLongPath, [MarshalAs(UnmanagedType.LPWStr)]string lShortPath, Int32 lBuffer);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean GetFileSizeEx(IntPtr hFile, out UInt32 lpFileSize);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 MoveFileExW([MarshalAs(UnmanagedType.LPWStr)]string lpExistingFileName, [MarshalAs(UnmanagedType.LPWStr)]string lpNewFileName, Int32 dwFlags);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 DeleteFileW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Int32 RemoveDirectoryW([MarshalAs(UnmanagedType.LPWStr)]string lpPathName);

        [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean DeviceIoControl(IntPtr hDevice, UInt32 dwIoControlCode, IntPtr lpInBuffer, UInt32 nInBufferSize, IntPtr lpOutBuffer, [Optional] UInt32 nOutBufferSize, out UInt32 lpBytesReturned, IntPtr lpOverlapped);

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr FindFirstFileW([MarshalAs(UnmanagedType.LPWStr)]string lpFileName, out WIN32_FIND_DATAW lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FindNextFileW(IntPtr hFindFile, out WIN32_FIND_DATAW lpFindFileData);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean FindClose(IntPtr hFindFile);
    }
}
