// Automatically generated by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

public partial class PickyPrivateKey: IDisposable
{
    private unsafe Raw.PickyPrivateKey* _inner;

    /// <summary>
    /// Creates a managed <c>PickyPrivateKey</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// </remarks>
    /// <remarks>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe PickyPrivateKey(Raw.PickyPrivateKey* handle)
    {
        _inner = handle;
    }

    /// <summary>
    /// Extracts private key from PEM object.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPrivateKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickyPrivateKey FromPem(PickyPem pem)
    {
        unsafe
        {
            Raw.PickyPem* pemRaw;
            pemRaw = pem.AsFFI();
            if (pemRaw == null)
            {
                throw new ObjectDisposedException("PickyPem");
            }
            Raw.KeyFfiResultBoxPickyPrivateKeyBoxPickyError result = Raw.PickyPrivateKey.FromPem(pemRaw);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.PickyPrivateKey* retVal = result.Ok;
            return new PickyPrivateKey(retVal);
        }
    }

    /// <summary>
    /// Reads a private key from its PKCS8 storage.
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPrivateKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickyPrivateKey FromPkcs8(byte[] pkcs8)
    {
        unsafe
        {
            nuint pkcs8Length = (nuint)pkcs8.Length;
            fixed (byte* pkcs8Ptr = pkcs8)
            {
                Raw.KeyFfiResultBoxPickyPrivateKeyBoxPickyError result = Raw.PickyPrivateKey.FromPkcs8(pkcs8Ptr, pkcs8Length);
                if (!result.isOk)
                {
                    throw new PickyException(new PickyError(result.Err));
                }
                Raw.PickyPrivateKey* retVal = result.Ok;
                return new PickyPrivateKey(retVal);
            }
        }
    }

    /// <summary>
    /// Generates a new RSA private key.
    /// </summary>
    /// <remarks>
    /// This is slow in debug builds.
    /// </remarks>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPrivateKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public static PickyPrivateKey GenerateRsa(nuint bits)
    {
        unsafe
        {
            Raw.KeyFfiResultBoxPickyPrivateKeyBoxPickyError result = Raw.PickyPrivateKey.GenerateRsa(bits);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.PickyPrivateKey* retVal = result.Ok;
            return new PickyPrivateKey(retVal);
        }
    }

    /// <summary>
    /// Exports the private key into a PEM object
    /// </summary>
    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>PickyPem</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickyPem ToPem()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickyPrivateKey");
            }
            Raw.KeyFfiResultBoxPickyPemBoxPickyError result = Raw.PickyPrivateKey.ToPem(_inner);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.PickyPem* retVal = result.Ok;
            return new PickyPem(retVal);
        }
    }

    /// <summary>
    /// Extracts the public part of this private key
    /// </summary>
    /// <returns>
    /// A <c>PickyPublicKey</c> allocated on Rust side.
    /// If a custom Drop implementation is implemented on Rust side, it WILL run on destruction.
    /// </returns>
    public PickyPublicKey ToPublicKey()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PickyPrivateKey");
            }
            Raw.PickyPublicKey* retVal = Raw.PickyPrivateKey.ToPublicKey(_inner);
            return new PickyPublicKey(retVal);
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.PickyPrivateKey* AsFFI()
    {
        return _inner;
    }

    /// <summary>
    /// Destroys the underlying object immediately.
    /// </summary>
    public void Dispose()
    {
        unsafe
        {
            if (_inner == null)
            {
                return;
            }

            Raw.PickyPrivateKey.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~PickyPrivateKey()
    {
        Dispose();
    }
}
