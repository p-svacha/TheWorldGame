﻿using Svg;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;

namespace FlagGeneration
{
    class Program
    {
        public static string SavePath;
        // args[0] is file path where the flag gets saved to
        static void Main(string[] args)
        {
            SavePath = args[0];
            FlagGenerator Gen = new FlagGenerator();
            SvgDocument Svg = Gen.GenerateFlag();

            //Svg.Write(args[0]); // write to svg file
            Svg.Draw().Save(SavePath); // Write to png
        }
    }
}
