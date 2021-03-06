﻿using System;
using System.Runtime.InteropServices;
using DlibDotNet.Extensions;

// ReSharper disable once CheckNamespace
namespace DlibDotNet
{

    public static partial class Dlib
    {

        #region Methods

        public static MatrixOp Heatmap(Array2DBase image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var array2DType = image.ImageType.ToNativeArray2DType();

            var ret = Native.heatmap(array2DType, image.NativePtr, out var matrix);
            if (ret == Native.ErrorType.ArrayTypeNotSupport)
                throw new ArgumentException($"{image.ImageType} is not supported.");

            return new MatrixOp(Native.ElementType.OpHeatmap, image.ImageType, matrix);
        }

        public static MatrixOp Heatmap(Array2DBase image, double maxValue, double minValue = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var array2DType = image.ImageType.ToNativeArray2DType();

            var ret = Native.heatmap2(array2DType, image.NativePtr, maxValue, minValue, out var matrix);
            if (ret == Native.ErrorType.ArrayTypeNotSupport)
                throw new ArgumentException($"{image.ImageType} is not supported.");

            return new MatrixOp(Native.ElementType.OpHeatmap, image.ImageType, matrix);
        }

        public static MatrixOp Jet(Array2DBase image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var array2DType = image.ImageType.ToNativeArray2DType();

            var ret = Native.jet(array2DType, image.NativePtr, out var matrix);
            if (ret == Native.ErrorType.ArrayTypeNotSupport)
                throw new ArgumentException($"{image.ImageType} is not supported.");

            return new MatrixOp(Native.ElementType.OpJet, image.ImageType, matrix);
        }

        public static MatrixOp Jet(Array2DBase image, double maxValue, double minValue = 0)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            var array2DType = image.ImageType.ToNativeArray2DType();

            var ret = Native.jet2(array2DType, image.NativePtr, maxValue, minValue, out var matrix);
            if (ret == Native.ErrorType.ArrayTypeNotSupport)
                throw new ArgumentException($"{image.ImageType} is not supported.");

            return new MatrixOp(Native.ElementType.OpJet, image.ImageType, matrix);
        }

        #endregion

        internal sealed partial class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ErrorType heatmap(Array2DType type, IntPtr img, out IntPtr matrix);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ErrorType heatmap2(Array2DType type, IntPtr img, double maxVal, double minVal, out IntPtr matrix);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ErrorType jet(Array2DType type, IntPtr img, out IntPtr matrix);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern ErrorType jet2(Array2DType type, IntPtr img, double maxVal, double minVal, out IntPtr matrix);

        }

    }

}