﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using DlibDotNet.Extensions;

// ReSharper disable once CheckNamespace
namespace DlibDotNet
{

    public sealed class ShapePredictor : DlibObject
    {

        #region Constructors

        public ShapePredictor()
        {
            this.NativePtr = Native.shape_predictor_new();
        }

        public ShapePredictor(string path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (!File.Exists(path))
                throw new FileNotFoundException($"{path} is not found", path);

            var str = Encoding.UTF8.GetBytes(path);
            this.NativePtr = Native.deserialize_shape_predictor(str);
        }

        #endregion

        #region Properties

        public uint Features
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.shape_predictor_num_parts(this.NativePtr);
            }
        }

        public uint Parts
        {
            get
            {
                this.ThrowIfDisposed();
                return Native.shape_predictor_num_parts(this.NativePtr);
            }
        }

        #endregion

        #region Methods

        public FullObjectDetection Detect(Array2DBase image, Rectangle rect)
        {
            this.ThrowIfDisposed();

            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            image.ThrowIfDisposed();
            rect.ThrowIfDisposed();

            var inType = image.ImageType.ToNativeArray2DType();
            var ret = Native.shape_predictor_operator(this.NativePtr, inType, image.NativePtr, rect.NativePtr, out var fullObjDetect);
            switch (ret)
            {
                case Dlib.Native.ErrorType.InputArrayTypeNotSupport:
                    throw new ArgumentException($"Input {inType} is not supported.");
            }

            return new FullObjectDetection(fullObjDetect);
        }

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            Native.shape_predictor_delete(this.NativePtr);
        }

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr shape_predictor_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern uint shape_predictor_num_parts(IntPtr predictor);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern uint shape_predictor_num_features(IntPtr predictor);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr deserialize_shape_predictor(byte[] filName);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType shape_predictor_operator(
                IntPtr detector,
                Dlib.Native.Array2DType imgType,
                IntPtr img,
                IntPtr rect,
                out IntPtr fullObjDetect);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void shape_predictor_delete(IntPtr point);

        }

    }

}
