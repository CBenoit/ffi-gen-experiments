// Automatically generated by Interoptopus.

#pragma warning disable 0105
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Devolutions.Picky;
#pragma warning restore 0105

namespace Devolutions.Picky
{
    public static partial class Interop
    {
        public const string NativeLib = "picky_ffi";

        static Interop()
        {
        }


        [DllImport(NativeLib, CallingConvention = CallingConvention.Cdecl, EntryPoint = "picky_pem_parse")]
        public static extern PemError picky_pem_parse(string input, ref IntPtr ctx);

        public static void picky_pem_parse_checked(string input, ref IntPtr ctx) {
            var rval = picky_pem_parse(input, ref ctx);;
            if (rval != PemError.Ok)
            {
                throw new InteropException<PemError>(rval);
            }
        }

    }

    /// # Safety invariants:
    ///  - `flush()` and `grow()` will be passed `self` including `context` and it should always be safe to do so.
    ///     `context` may be  null, however `flush()` and `grow()` must then be ready to receive it as such.
    ///  - `buf` must be `cap` bytes long
    ///  - `grow()` must either return false or update `buf` and `cap` for a valid buffer
    ///    of at least the requested buffer size
    ///  - Rust code must call `DiplomatWriteable::flush()` before releasing to C
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DiplomatWriteable
    {
        /// Context pointer for additional data needed by `grow()` and `flush()`. May be `null`.
        ///
        /// The pointer may reference structured data on the foreign side,
        /// such as C++ std::string, used to reallocate buf.
        IntPtr context;
        /// The raw string buffer, which will be mutated on the Rust side.
        IntPtr buf;
        /// The current filled size of the buffer
        uint len;
        /// The current capacity of the buffer
        uint cap;
    }

    public enum PemError
    {
        Ok = 0,
        NullPassed = 1,
        Panic = 2,
        Other = 3,
    }



    public class InteropException<T> : Exception
    {
        public T Error { get; private set; }

        public InteropException(T error): base($"Something went wrong: {error}")
        {
            Error = error;
        }
    }

}
