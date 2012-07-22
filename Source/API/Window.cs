using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace System.Windows.API
{
    /// <summary>
    /// Class containing API methods for Window handles
    /// </summary>
    public class Window
    {
        [DllImport("User32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        [DllImport("User32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("kernel32", EntryPoint = "GetVersionEx")]
        public static extern bool GetVersionEx(ref OSVERSIONINFO osvi);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CloseHandle", SetLastError = true)]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("user32")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32")]
        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);

        [DllImport("user32")]
        public static extern int GetKeyboardState(byte[] pbKeyState);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern short GetKeyState(int vKey);

        [DllImport("user32.dll")]
        public static extern int SetWindowsHookEx(int idHook, HOOK_PROC_CALLBACK lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(int idHook);

        [DllImport("user32.dll")]
        public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern int SaveDC(IntPtr hdc);

        [DllImport("user32.dll")]
        public static extern int ReleaseDC(IntPtr hdc, int state);

        [DllImport("UxTheme.dll", CharSet = CharSet.Unicode)]
        public static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);

        [DllImport("UxTheme.dll")]
        public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hdc, ref MARGINS marInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmDefWindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, out IntPtr result);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, Int32 Msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Checks if Windows is higher or equal than a minimum version.
        /// </summary>
        /// <param name="minimum">The lowest possible version.</param>
        /// <returns>Result of operation system check.</returns>
        public bool VersionCheck(VER_PLATFORM minimum)
        {
            OSVERSIONINFO tVer = new OSVERSIONINFO();
            tVer.dwVersionInfoSize = Marshal.SizeOf(tVer);
            GetVersionEx(ref tVer);
            return ((VER_PLATFORM)tVer.dwPlatformId & minimum) == minimum;
        }
    }
}
