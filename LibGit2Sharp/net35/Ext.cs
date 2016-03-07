using System;
using System.IO;

namespace net35
{

    internal static class Ext
    {
        internal static bool HasFlag(this Enum src, Enum flag)
        {
            try {
                return (((int)(object)src & (int)(object)flag) == (int)(object)flag);
            } catch {
                return false;
            }
        }

        internal static bool IsNullOrWhiteSpace(string value)
        {
            if (value == null) {
                return true;
            }
            for (int i = 0; i < value.Length; i++) {
                if (!char.IsWhiteSpace(value [i])) {
                    return false;
                }
            }
            return true;
        }

        internal static void CopyTo(this Stream source, Stream destination)
        {
            if (destination == null) {
                throw new ArgumentNullException("destination");
            }
            if (!source.CanRead && !source.CanWrite) {
                throw new ObjectDisposedException(null, "ObjectDisposed_StreamClosed");
            }
            if (!destination.CanRead && !destination.CanWrite) {
                throw new ObjectDisposedException("destination", "ObjectDisposed_StreamClosed");
            }
            if (!source.CanRead) {
                throw new NotSupportedException("NotSupported_UnreadableStream");
            }
            if (!destination.CanWrite) {
                throw new NotSupportedException("NotSupported_UnwritableStream");
            }

            const int bufferSize = 81920;
            var array = new byte[bufferSize];
            int count;
            while ((count = source.Read(array, 0, array.Length)) != 0) {
                destination.Write(array, 0, count);
            }
        }

    }
}


