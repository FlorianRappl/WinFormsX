using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Provides API access to memory allocation and other memory functions
    /// </summary>
    public class Memory
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualAlloc(IntPtr lpAddress, UInt32 dwSize, UInt32 flAllocationType, UInt32 flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean VirtualFree(IntPtr lpAddress, UInt32 dwSize, UInt32 dwFreeType);

        [DllImport("kernel32.dll", SetLastError = false)]
        public static extern void RtlZeroMemory(IntPtr dest, IntPtr size);

        [DllImport("ntdll.dll", SetLastError = false)]
        public static extern Int32 RtlFillMemory([In] IntPtr Destination, UInt32 length, byte fill);

        [DllImport("ntdll.dll", SetLastError = true)]
        public static extern void RtlZeroMemory(IntPtr Destination, uint length);

        [DllImport("ntdll.dll", SetLastError = false)]
        public static extern UInt32 RtlCompareMemory(IntPtr Source1, IntPtr Source2, UInt32 length);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 RtlMoveMemory(ref byte Destination, ref byte Source, IntPtr Length);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern Int32 RtlMoveMemory(ref byte Destination, ref IntPtr Source, IntPtr Length);
    }
}
