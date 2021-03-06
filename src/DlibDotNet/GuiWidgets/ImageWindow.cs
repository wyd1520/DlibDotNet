﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DlibDotNet.Extensions;

// ReSharper disable once CheckNamespace
namespace DlibDotNet
{

    public sealed partial class ImageWindow : DlibObject
    {

        #region Constructors

        public ImageWindow()
        {
            this.NativePtr = Native.image_window_new();
        }

        public ImageWindow(Array2DBase image)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));

            image.ThrowIfDisposed(nameof(image));

            this.NativePtr = Native.image_window_new_array2d1(image.ImageType.ToNativeArray2DType(), image.NativePtr);
        }

        public ImageWindow(Array2DBase image, string title)
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image));
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            image.ThrowIfDisposed(nameof(image));

            var str = Encoding.UTF8.GetBytes(title);
            this.NativePtr = Native.image_window_new_array2d2(image.ImageType.ToNativeArray2DType(), image.NativePtr, str);
        }

        public ImageWindow(MatrixBase matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            matrix.ThrowIfDisposed(nameof(matrix));

            var type = matrix.MatrixElementType.ToNativeMatrixElementType();
            this.NativePtr = Native.image_window_new_matrix1(type, matrix.NativePtr);
        }

        public ImageWindow(MatrixBase matrix, string title)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            matrix.ThrowIfDisposed(nameof(matrix));

            var type = matrix.MatrixElementType.ToNativeMatrixElementType();
            var str = Encoding.UTF8.GetBytes(title);
            this.NativePtr = Native.image_window_new_matrix2(type, matrix.NativePtr, str);
        }

        public ImageWindow(MatrixOp matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            matrix.ThrowIfDisposed(nameof(matrix));

            this.NativePtr = Native.image_window_new_matrix_op1(matrix.ElementType, matrix.Array2DType, matrix.NativePtr);
        }

        public ImageWindow(MatrixOp matrix, string title)
        {
            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));
            if (title == null)
                throw new ArgumentNullException(nameof(title));

            matrix.ThrowIfDisposed(nameof(matrix));

            var str = Encoding.UTF8.GetBytes(title);
            this.NativePtr = Native.image_window_new_matrix_op2(matrix.ElementType, matrix.Array2DType, matrix.NativePtr, str);
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region AddOverlay(Rectangle rect, pixel_type color)

        public void AddOverlay(Rectangle rect)
        {
            this.AddOverlay(rect, new RgbPixel
            {
                Red = 255
            });
        }

        public void AddOverlay(Rectangle rect, byte color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.UInt8, ref color);
        }

        public void AddOverlay(Rectangle rect, ushort color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.UInt16, ref color);
        }

        public void AddOverlay(Rectangle rect, float color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.Float, ref color);
        }

        public void AddOverlay(Rectangle rect, double color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.Double, ref color);
        }

        public void AddOverlay(Rectangle rect, RgbPixel color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.RgbPixel, ref color);
        }

        public void AddOverlay(Rectangle rect, RgbAlphaPixel color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.RgbAlphaPixel, ref color);
        }

        public void AddOverlay(Rectangle rect, HsiPixel color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.HsiPixel, ref color);
        }

        #endregion

        #region AddOverlay(IEnumerable<Rectangle> rects, pixel_type color)

        public void AddOverlay(IEnumerable<Rectangle> rects)
        {
            this.AddOverlay(rects, new RgbPixel
            {
                Red = 255
            });
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, byte color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.UInt8, ref color);
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, ushort color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.UInt16, ref color);
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, float color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.Float, ref color);
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, double color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.Double, ref color);
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, RgbPixel color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.RgbPixel, ref color);
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, RgbAlphaPixel color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.RgbAlphaPixel, ref color);
        }

        public void AddOverlay(IEnumerable<Rectangle> rects, HsiPixel color)
        {
            this.ThrowIfDisposed();

            if (rects == null)
                throw new ArgumentNullException(nameof(rects));

            using (var vector = new VectorOfRectangle(rects))
                Native.image_window_add_overlay2(this.NativePtr, vector.NativePtr, Dlib.Native.Array2DType.HsiPixel, ref color);
        }

        #endregion

        #region AddOverlay(DRectangle rect, pixel_type color)

        public void AddOverlay(DRectangle rect)
        {
            this.AddOverlay(rect, new RgbPixel
            {
                Red = 255
            });
        }

        public void AddOverlay(DRectangle rect, byte color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.UInt8, ref color);
        }

        public void AddOverlay(DRectangle rect, ushort color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.UInt16, ref color);
        }

        public void AddOverlay(DRectangle rect, float color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.Float, ref color);
        }

        public void AddOverlay(DRectangle rect, double color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.Double, ref color);
        }

        public void AddOverlay(DRectangle rect, RgbPixel color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.RgbPixel, ref color);
        }

        public void AddOverlay(DRectangle rect, RgbAlphaPixel color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.RgbAlphaPixel, ref color);
        }

        public void AddOverlay(DRectangle rect, HsiPixel color)
        {
            this.ThrowIfDisposed();

            if (rect == null)
                throw new ArgumentNullException(nameof(rect));

            rect.ThrowIfDisposed();

            Native.image_window_add_overlay3(this.NativePtr, rect.NativePtr, Dlib.Native.Array2DType.HsiPixel, ref color);
        }

        #endregion

        #region AddOverlay(OverlayLine line)

        public void AddOverlay(OverlayLine line)
        {
            this.ThrowIfDisposed();

            if (line == null)
                throw new ArgumentNullException(nameof(line));

            line.ThrowIfDisposed();

            Native.image_window_add_overlay4(this.NativePtr, line.NativePtr);
        }

        #endregion

        #region AddOverlay(IEnumerable<OverlayLine> lines)

        public void AddOverlay(IEnumerable<OverlayLine> lines)
        {
            this.ThrowIfDisposed();

            if (lines == null)
                throw new ArgumentNullException(nameof(lines));

            using (var vector = new VectorOfImageWindowOverlayLine(lines))
                Native.image_window_add_overlay5(this.NativePtr, vector.NativePtr);
        }

        #endregion

        public void ClearOverlay()
        {
            this.ThrowIfDisposed();
            Native.image_window_clear_overlay(this.NativePtr);
        }

        public void SetImage(Array2DBase image)
        {
            this.ThrowIfDisposed();

            if (image == null)
                throw new ArgumentNullException(nameof(image));

            image.ThrowIfDisposed();

            var ret = Native.image_window_set_image_array2d(this.NativePtr, image.ImageType.ToNativeArray2DType(), image.NativePtr);
            switch (ret)
            {
                case Dlib.Native.ErrorType.InputArrayTypeNotSupport:
                    throw new ArgumentException($"{image.ImageType} is not supported.");
            }
        }

        public void SetImage(MatrixBase matrix)
        {
            this.ThrowIfDisposed();

            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            matrix.ThrowIfDisposed();

            var ret = Native.image_window_set_image_matrix(this.NativePtr, matrix.MatrixElementType.ToNativeMatrixElementType(), matrix.NativePtr);
            switch (ret)
            {
                case Dlib.Native.ErrorType.InputElementTypeNotSupport:
                    throw new ArgumentException($"{matrix.MatrixElementType} is not supported.");
            }
        }

        public void SetImage(MatrixOp matrix)
        {
            this.ThrowIfDisposed();

            if (matrix == null)
                throw new ArgumentNullException(nameof(matrix));

            matrix.ThrowIfDisposed();

            var ret = Native.image_window_set_image_matrix_op(this.NativePtr, matrix.ElementType, matrix.Array2DType, matrix.NativePtr);
            switch (ret)
            {
                case Dlib.Native.ErrorType.InputElementTypeNotSupport:
                    throw new ArgumentException($"{matrix.ElementType} is not supported.");
            }
        }

        public void WaitUntilClosed()
        {
            this.ThrowIfDisposed();
            Native.image_window_wait_until_closed(this.NativePtr);
        }

        #region Overrides

        protected override void DisposeUnmanaged()
        {
            base.DisposeUnmanaged();
            Native.image_window_delete(this.NativePtr);
        }

        #endregion

        #region Event Handlers

        #endregion

        #region Helpers

        #endregion

        #endregion

        internal sealed class Native
        {

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void image_window_delete(IntPtr ptr);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new();

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new_array2d1(Dlib.Native.Array2DType type, IntPtr image);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new_array2d2(Dlib.Native.Array2DType type, IntPtr image, byte[] title);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new_matrix1(Dlib.Native.MatrixElementType type, IntPtr image);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new_matrix2(Dlib.Native.MatrixElementType type, IntPtr image, byte[] title);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new_matrix_op1(Dlib.Native.ElementType matrixElementType, Dlib.Native.Array2DType type, IntPtr image);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern IntPtr image_window_new_matrix_op2(Dlib.Native.ElementType matrixElementType, Dlib.Native.Array2DType type, IntPtr image, byte[] title);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void image_window_wait_until_closed(IntPtr window);

            #region image_window_add_overlay

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref byte color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref ushort color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref float color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref double color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref RgbPixel color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref RgbAlphaPixel color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref HsiPixel color);

            #endregion

            #region image_window_add_overlay2

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref byte color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref ushort color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref float color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref double color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref RgbPixel color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref RgbAlphaPixel color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay2(IntPtr window, IntPtr vectorOfRect, Dlib.Native.Array2DType type, ref HsiPixel color);

            #endregion

            #region image_window_add_overlay3

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref byte color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref ushort color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref float color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref double color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref RgbPixel color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref RgbAlphaPixel color);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay3(IntPtr window, IntPtr rect, Dlib.Native.Array2DType type, ref HsiPixel color);

            #endregion

            #region image_window_add_overlay4

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay4(IntPtr window, IntPtr line);

            #endregion

            #region image_window_add_overlay5

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_add_overlay5(IntPtr window, IntPtr vectorOfLine);

            #endregion

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern void image_window_clear_overlay(IntPtr window);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_set_image_array2d(IntPtr window, Dlib.Native.Array2DType type, IntPtr image);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_set_image_matrix_op(IntPtr window, Dlib.Native.ElementType matrixElementType, Dlib.Native.Array2DType type, IntPtr matrix);

            [DllImport(NativeMethods.NativeLibrary, CallingConvention = NativeMethods.CallingConvention)]
            public static extern Dlib.Native.ErrorType image_window_set_image_matrix(IntPtr window, Dlib.Native.MatrixElementType type, IntPtr matrix);

        }

    }

}
