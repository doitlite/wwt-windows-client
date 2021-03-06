﻿using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace TerraViewer
{
    class PushPin
    {
        static Dictionary<int,Texture11> pinTextureCache = new Dictionary<int,Texture11>();
        static Bitmap Pins = global::TerraViewer.Properties.Resources.pins;
        public static Texture11 GetPushPinTexture(int pinId)
        {
            if (pinTextureCache.ContainsKey(pinId))
            {
                return pinTextureCache[pinId];
            }

            Bitmap bmp = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics gOut = Graphics.FromImage(bmp);

            int row = pinId / 16;
            int col = pinId % 16;
            gOut.DrawImage(Pins, new Rectangle(0, 0, 32, 32), (col * 32), (row * 32), 32, 32, GraphicsUnit.Pixel);

            gOut.Flush();
            gOut.Dispose();
            Texture11 tex = Texture11.FromBitmap( bmp, 0xFF000000);
            bmp.Dispose();
            pinTextureCache.Add(pinId, tex);
            return tex;
        }

        static Dictionary<int, Bitmap> pinBitmapCache = new Dictionary<int, Bitmap>();

        public static Bitmap GetPushPinBitmap(int pinId)
        {
            if (pinBitmapCache.ContainsKey(pinId))
            {
                return pinBitmapCache[pinId];
            }

            Bitmap bmp = new Bitmap(32, 32, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics gOut = Graphics.FromImage(bmp);

            int row = pinId / 16;
            int col = pinId % 16;
            gOut.DrawImage(Pins, new Rectangle(0, 0, 32, 32), (col * 32), (row * 32), 32, 32, GraphicsUnit.Pixel);

            gOut.Flush();
            gOut.Dispose();
            pinBitmapCache.Add(pinId, bmp);
            return bmp;
        }

        public static void DrawAt(Graphics g, int pinId, int x, int y)
        {
            int row = pinId / 16;
            int col = pinId % 16;
            g.DrawImage(Pins, new Rectangle(x, y, 32, 32), (col * 32), (row * 32), 32, 32, GraphicsUnit.Pixel);

        }

        public static int PinCount
        {
            get
            {
                return 348;
            }
        }
    }
}
