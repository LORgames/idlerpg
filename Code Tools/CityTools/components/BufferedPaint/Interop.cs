// Painting Controls With Fade Animations Using the Buffered Paint API
// 2011/10/23 - Bradley Smith

using System;
using System.Drawing;
using System.Runtime.InteropServices;

public static class Interop {

    [DllImport("uxtheme")]
    public static extern IntPtr BufferedPaintInit();

    [DllImport("uxtheme")]
    public static extern IntPtr BufferedPaintUnInit();

    [DllImport("uxtheme")]
    public static extern IntPtr BeginBufferedAnimation(
        IntPtr hwnd, 
        IntPtr hdcTarget, 
        ref Rectangle rcTarget, 
        BP_BUFFERFORMAT dwFormat, 
        IntPtr pPaintParams, 
        ref BP_ANIMATIONPARAMS pAnimationParams, 
        out IntPtr phdcFrom, 
        out IntPtr phdcTo
    );

    [DllImport("uxtheme")]
    public static extern IntPtr EndBufferedAnimation(IntPtr hbpAnimation, bool fUpdateTarget);

    [DllImport("uxtheme")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool BufferedPaintRenderAnimation(IntPtr hwnd, IntPtr hdcTarget);

    [DllImport("uxtheme")]
    public static extern IntPtr BufferedPaintStopAllAnimations(IntPtr hwnd);

}

[StructLayout(LayoutKind.Sequential)]
public struct BP_ANIMATIONPARAMS {
    public Int32 cbSize, dwFlags;
    public BP_ANIMATIONSTYLE style;
    public Int32 dwDuration;
}

public enum BP_BUFFERFORMAT {
    BPBF_COMPATIBLEBITMAP,
    BPBF_DIB,
    BPBF_TOPDOWNDIB,
    BPBF_TOPDOWNMONODIB
}

[Flags]
public enum BP_ANIMATIONSTYLE {
    BPAS_NONE = 0,
    BPAS_LINEAR = 1,
    BPAS_CUBIC = 2,
    BPAS_SINE = 3
}