using System;
using System.IO;


using Typography;
using Typography.OpenFont;



namespace LayoutFarm
{
    public class Class1
    {


        //public override FontGlyph GetGlyphByIndex(ushort glyphIndex)
        //{
        //    PixelFarm.Drawing.Fonts.FontGlyph fontGlyph = new PixelFarm.Drawing.Fonts.FontGlyph();
        //    // fontGlyph.flattenVxs = GetGlyphVxs(glyphIndex);
        //    //fontGlyph.horiz_adv_x = typeFace.GetHAdvanceWidthFromGlyphIndex(glyphIndex);

        //    return fontGlyph;
        //}

        public static PixelFarm.Drawing.Fonts.FontFace LoadFont(Typeface typeface)
        {

            

            var openFont = new PixelFarm.Drawing.Fonts.NOpenFontFace(typeface, typeface.Name, typeface.Filename);


            


            var af = openFont.GetFontAtPointSize(12);
            System.Console.WriteLine(af.GetGlyph('c').glyphMatrix.img_horiBearingX);
            System.Console.WriteLine(af.GetGlyph('c').glyphMatrix.img_horiBearingY);
            System.Console.WriteLine(af.GetGlyph('c').glyphMatrix.img_width);


            //       public override FontGlyph GetGlyph(char c)
            //        {
            //return GetGlyphByIndex(typeFace.LookupIndex(c));
            //}


            //openFont.GetFontAtPointSize
            // openFont.GetScale
            // openFont.RecommendedLineHeight
            // openFont.HasKerning

            return openFont;
        }


        // https://developer.apple.com/fonts/TrueType-Reference-Manual/
        // https://developer.apple.com/fonts/TrueType-Reference-Manual/RM06/Chap6OS2.html


        // https://docs.microsoft.com/en-us/typography/opentype/spec/
        // https://docs.microsoft.com/en-us/typography/opentype/spec/ttch01
        // https://docs.microsoft.com/en-us/typography/opentype/spec/ttinst

        // https://github.com/SixLabors/Fonts/tree/master/src/SixLabors.Fonts


        // https://github.com/topics/font-editor
        // https://github.com/Jolg42/awesome-typography#javascript
        // https://github.com/MikePopoloski/SharpFont



        // ULONG *status: ULONG: int32
        // https://github.com/SixLabors/Fonts/tree/master/src/SixLabors.Fonts
        static int TTGetEmbeddingType(Typeface t, ref int status)
        {
            // __MSABI_LONG
            // https://doxygen.reactos.org/de/d41/verrsrc_8h_source.html#l00028

            // https://doxygen.reactos.org/d6/d57/t2embapi_8h_source.html
            const int LICENSE_INSTALLABLE = 0x0000;
            const int LICENSE_DEFAULT = 0x0000;
            const int LICENSE_NOEMBEDDING = 0x0002;
            const int LICENSE_PREVIEWPRINT = 0x0004;
            const int LICENSE_EDITABLE = 0x0008;
            
            // https://doxygen.reactos.org/d6/d57/t2embapi_8h_source.html
            const int E_NONE = 0x0000;
            const int E_API_NOTIMPL = 0x0001;
            const int E_HDCINVALID = 0x0006;
            const int E_NOFREEMEMORY = 0x0007;
            const int E_NOTATRUETYPEFONT = 0x000a;
            const int E_ERRORACCESSINGFONTDATA = 0x000c;
            const int E_ERRORACCESSINGFACENAME = 0x000d;
            const int E_FACENAMEINVALID = 0x0113;
            const int E_PERMISSIONSINVALID = 0x0117;
            const int E_PBENABLEDINVALID = 0x0118;

            // https://doxygen.reactos.org/d6/d57/t2embapi_8h_source.html
            const int EMBED_PREVIEWPRINT  =1;
            const int EMBED_EDITABLE = 2;
            const int EMBED_INSTALLABLE = 3;
            const int EMBED_NOEMBEDDING = 4;

            if(t== null)
                return E_HDCINVALID;

            if(t.OS2Table == null)
                return E_NOTATRUETYPEFONT;

            // if (!status) return E_PERMISSIONSINVALID;

            // font->potm->otmfsType = pOS2->fsType & 0x30e;
            int otmfsType = t.OS2Table.fsType & 0x30e;
            otmfsType = otmfsType & 0xf;

            if (otmfsType == LICENSE_INSTALLABLE)
                status = EMBED_INSTALLABLE;
            else if ((otmfsType & LICENSE_EDITABLE) != 0)
                status = EMBED_EDITABLE;
            else if ((otmfsType & LICENSE_PREVIEWPRINT) != 0)
                status = EMBED_PREVIEWPRINT;
            else if ((otmfsType & LICENSE_NOEMBEDDING) != 0)
                status = EMBED_NOEMBEDDING;
            else
            {
                // WARN("unrecognized flags, %#x\n", otm.otmfsType);
                status = EMBED_INSTALLABLE;
            }

            return E_NONE;
        }


        public static PixelFarm.Drawing.Fonts.FontFace LoadFont(string fontpath)
        {
            // Typeface: Typography.OpenFont
            // GlyphPathBuilder: Typography.Contours
            // Typography.OpenFont: OpenFontReader


            using (FileStream fs = new FileStream(fontpath, FileMode.Open, FileAccess.Read))
            {
                var reader = new OpenFontReader();
                Typeface t = reader.Read(fs);
                t.Filename = fontpath;

                // t.IsCffFont // (CFF: Compact Font Format) https://www.linotype.com/8120/the-difference-between-cff-and-ttf.html
                t.GetAdvanceWidth(123);

                // font->potm->otmfsType = pOS2->fsType & 0x30e;
                int otmfsType = t.OS2Table.fsType & 0x30e;
                
                

                short a = t.Ascender;
                short b = t.Descender;
                short c = t.LineGap;
                // t.CalculateScaleToPixelFromPointSize
                // t.CalculateScaleToPixel

                // var list = t.GetRawGlyphList();
                //list[0].

                
                // t.GetGlyphByIndex(123);

                var gi = t.GetGlyphByIndex(t.LookupIndex('g'));


                

                // gi.Bounds.Equals
                // t.GetGlyphByIndex(t.LookupIndex('g')).MathGlyphInfo.

                var builder = new Typography.Contours.GlyphPathBuilder(t);
                


                return LoadFont(t);
            }
        }
        

    }
}
