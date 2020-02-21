/*
 
d:\stefan.steiger\documents\visual studio 2017\Projects\LayoutFarm\BackEnd.BurningMineCurve\CurveUtils\VectorHelper.cs

#elif false //PIXEL_FARM_NET20


D:\Stefan.Steiger\Documents\Visual Studio 2017\Projects\Typography\PixelFarm\PixelFarm.Drawing\7_CpuBlitPainter\Others\3_Filter

remove BrightnessAndContrastAdjustment.cs


D:\Stefan.Steiger\Documents\Visual Studio 2017\Projects\Typography\PixelFarm\PixelFarm.Painter\0_Base
Remove ForNet20.cs


D:\Stefan.Steiger\Documents\Visual Studio 2017\Projects\Typography\Typography.OpenFont\TrueTypeInterperter
Remove ForNet20.cs


 */
#if NET20

//for .NET 2.0 
namespace System.Runtime.CompilerServices
{
    public partial class ExtensionAttribute : Attribute { }
}


namespace System.Runtime.InteropServices
{
    public partial class TargetedPatchingOptOutAttribute : Attribute
    {
        public TargetedPatchingOptOutAttribute(string msg) { }
    }
}

namespace System
{
    public delegate R Func<R>();
    public delegate R Func<T, R>(T t1);
    public delegate R Func<T1, T2, R>(T1 t1, T2 t2);
    public delegate R Func<T1, T2, T3, R>(T1 t1, T2 t2, T3 t3);
}

#endif
