﻿using System;
using System.Collections.Generic;
using OpenCvSharp;
using SampleBase;
using SampleBase.Console;

namespace SamplesCore;

/// <summary>
/// 
/// </summary>
class SolveEquation : ConsoleTestBase
{
    public override void RunTest()
    {
            ByMat();
            ByNormalArray();

            Console.Read();
        }

    /// <summary>
    /// Solve equation AX = Y
    /// </summary>
    private void ByMat()
    {
            // x + y = 10
            // 2x + 3y = 26
            // (x=4, y=6)

            double[,] av = {{1, 1}, 
                          {2, 3}};
            double[] yv = {10, 26};

            using var a = new Mat(2, 2, MatType.CV_64FC1, av);
            using var y = new Mat(2, 1, MatType.CV_64FC1, yv);
            using var x = new Mat();

            Cv2.Solve(a, y, x, DecompTypes.LU);

            Console.WriteLine("ByMat:");
            Console.WriteLine("X1 = {0}, X2 = {1}", x.At<double>(0), x.At<double>(1));
        }

    /// <summary>
    /// Solve equation AX = Y
    /// </summary>
    private void ByNormalArray()
    {
            // x + y = 10
            // 2x + 3y = 26
            // (x=4, y=6)

            double[,] a = {{1, 1}, 
                          {2, 3}};

            double[] y = { 10, 26 };

            var x = new List<double>();

            Cv2.Solve(
                InputArray.Create(a), InputArray.Create(y),
                OutputArray.Create(x),
                DecompTypes.LU);

            Console.WriteLine("ByNormalArray:");
            Console.WriteLine("X1 = {0}, X2 = {1}", x[0], x[1]);
        }
}
