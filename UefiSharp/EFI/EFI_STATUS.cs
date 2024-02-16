using System;

namespace EFI;

/// <summary>
/// Function return status for EFI API.
/// </summary>
public struct EFI_STATUS
{
    /// <summary>
    /// 0 Success
    /// > 0 Warning
    /// < 0 Error
    /// </summary>
    public nuint Value;

    public readonly bool IsSuccess => Value == 0;
    public readonly bool IsError => Value < 0;
    public readonly bool IsWarning => Value > 0;

    public EFI_STATUS(nuint value)
        => Value = value;

    public EFI_STATUS(nint value)
        => Value = (UIntPtr)value;

    public static bool operator ==(EFI_STATUS left, EFI_STATUS right) => left.Value == right.Value;
    public static bool operator !=(EFI_STATUS left, EFI_STATUS right) => left.Value != right.Value;

    public EFI_STATUS EncodeError(nint StatusCode) => new EFI_STATUS(nint.MaxValue | StatusCode);
    public EFI_STATUS EncodeWarning(nint StatusCode) => new EFI_STATUS(StatusCode);


    /// <summary>
    /// Success
    /// </summary>
    public EFI_STATUS RETURN_SUCCESS => new EFI_STATUS(0);

    ///<summary>
    /// The image failed to load.
    /// </summary>
    public EFI_STATUS RETURN_LOAD_ERROR => EncodeError(1);

    /// <summary>
    /// The parameter was incorrect.
    /// </summary>
    public EFI_STATUS RETURN_INVALID_PARAMETER => EncodeError(2);

    /// <summary>
    /// The operation is not supported.
    /// </summary>
    public EFI_STATUS RETURN_UNSUPPORTED => EncodeError(3);

    /// <summary>
    /// The buffer was not the proper size for the request.
    /// </summary>
    public EFI_STATUS RETURN_BAD_BUFFER_SIZE => EncodeError(4);

    /// <summary>
    /// The buffer was not large enough to hold the requested data.
    /// The required buffer size is returned in the appropriate
    /// parameter when this error occurs.
    /// </summary>
    public EFI_STATUS RETURN_BUFFER_TOO_SMALL => EncodeError(5);

    /// <summary>
    /// There is no data pending upon return.
    /// </summary>
    public EFI_STATUS RETURN_NOT_READY => EncodeError(6);

    /// <summary>
    /// The physical device reported an error while attempting the
    /// operation.
    /// </summary>
    public EFI_STATUS RETURN_DEVICE_ERROR => EncodeError(7);

    /// <summary>
    /// The device can not be written to.
    /// </summary>
    public EFI_STATUS RETURN_WRITE_PROTECTED => EncodeError(8);

    /// <summary>
    /// The resource has run out.
    /// </summary>
    public EFI_STATUS RETURN_OUT_OF_RESOURCES => EncodeError(9);

    /// <summary>
    /// An inconsistency was detected on the file system causing the
    /// operation to fail.
    /// </summary>
    public EFI_STATUS RETURN_VOLUME_CORRUPTED => EncodeError(10);

    /// <summary>
    /// There is no more space on the file system.
    /// </summary>
    public EFI_STATUS RETURN_VOLUME_FULL => EncodeError(11);

    /// <summary>
    /// The device does not contain any medium to perform the
    /// operation.
    /// </summary>
    public EFI_STATUS RETURN_NO_MEDIA => EncodeError(12);

    /// <summary>
    /// The medium in the device has changed since the last
    /// access.
    /// </summary>
    public EFI_STATUS RETURN_MEDIA_CHANGED => EncodeError(13);

    /// <summary>
    /// The item was not found.
    /// </summary>
    public EFI_STATUS RETURN_NOT_FOUND => EncodeError(14);

    /// <summary>
    /// Access was denied.
    /// </summary>
    public EFI_STATUS RETURN_ACCESS_DENIED => EncodeError(15);

    /// <summary>
    /// The server was not found or did not respond to the request.
    /// </summary>
    public EFI_STATUS RETURN_NO_RESPONSE => EncodeError(16);

    /// <summary>
    /// A mapping to the device does not exist.
    /// </summary>
    public EFI_STATUS RETURN_NO_MAPPING => EncodeError(17);

    /// <summary>
    /// A timeout time expired.
    /// </summary>
    public EFI_STATUS RETURN_TIMEOUT => EncodeError(18);

    /// <summary>
    /// The protocol has not been started.
    /// </summary>
    public EFI_STATUS RETURN_NOT_STARTED => EncodeError(19);

    /// <summary>
    /// The protocol has already been started.
    /// </summary>
    public EFI_STATUS RETURN_ALREADY_STARTED => EncodeError(20);

    /// <summary>
    /// The operation was aborted.
    /// </summary>
    public EFI_STATUS RETURN_ABORTED => EncodeError(21);

    /// <summary>
    /// An ICMP error occurred during the network operation.
    /// </summary>
    public EFI_STATUS RETURN_ICMP_ERROR => EncodeError(22);

    /// <summary>
    /// A TFTP error occurred during the network operation.
    /// </summary>
    public EFI_STATUS RETURN_TFTP_ERROR => EncodeError(23);

    /// <summary>
    /// A protocol error occurred during the network operation.
    /// </summary>
    public EFI_STATUS RETURN_PROTOCOL_ERROR => EncodeError(24);

    /// <summary>
    /// A function encountered an internal version that was
    /// incompatible with a version requested by the caller.
    /// </summary>
    public EFI_STATUS RETURN_INCOMPATIBLE_VERSION => EncodeError(25);

    /// <summary>
    /// The function was not performed due to a security violation.
    /// </summary>
    public EFI_STATUS RETURN_SECURITY_VIOLATION => EncodeError(26);

    /// <summary>
    /// A CRC error was detected.
    /// </summary>
    public EFI_STATUS RETURN_CRC_ERROR => EncodeError(27);

    /// <summary>
    /// The beginning or end of media was reached.
    /// </summary>
    public EFI_STATUS RETURN_END_OF_MEDIA => EncodeError(28);

    /// <summary>
    /// The end of the file was reached.
    /// </summary>
    public EFI_STATUS RETURN_END_OF_FILE => EncodeError(31);

    /// <summary>
    /// The language specified was invalid.
    /// </summary>
    public EFI_STATUS RETURN_INVALID_LANGUAGE => EncodeError(32);

    /// <summary>
    /// The security status of the data is unknown or compromised
    /// and the data must be updated or replaced to restore a valid
    /// security status.
    /// </summary>
    public EFI_STATUS RETURN_COMPROMISED_DATA => EncodeError(33);

    /// <summary>
    /// A HTTP error occurred during the network operation.
    /// </summary>
    public EFI_STATUS RETURN_HTTP_ERROR => EncodeError(35);






    /// <summary>
    /// The string contained one or more characters that
    /// the device could not render and were skipped.
    /// <summary>
    public EFI_STATUS RETURN_WARN_UNKNOWN_GLYPH => EncodeWarning(1);

    /// <summary>
    /// The handle was closed, but the file was not deleted.
    /// <summary>
    public EFI_STATUS RETURN_WARN_DELETE_FAILURE => EncodeWarning(2);

    /// <summary>
    /// The handle was closed, but the data to the file was not
    /// flushed properly.
    /// <summary>
    public EFI_STATUS RETURN_WARN_WRITE_FAILURE => EncodeWarning(3);

    /// <summary>
    /// The resulting buffer was too small, and the data was
    /// truncated to the buffer size.
    /// <summary>
    public EFI_STATUS RETURN_WARN_BUFFER_TOO_SMALL => EncodeWarning(4);

    /// <summary>
    /// The data has not been updated within the timeframe set by
    /// local policy for this type of data.
    /// <summary>
    public EFI_STATUS RETURN_WARN_STALE_DATA => EncodeWarning(5);

    /// <summary>
    /// The resulting buffer contains UEFI-compliant file system.
    /// <summary>
    public EFI_STATUS RETURN_WARN_FILE_SYSTEM => EncodeWarning(6);


















    /// <summary>
    /// Success
    /// </summary>
    public EFI_STATUS EFI_SUCCESS => new EFI_STATUS(0);


    ///<summary>
    /// The image failed to load.
    /// </summary>
    public EFI_STATUS EFI_LOAD_ERROR => EncodeError(1);

    /// <summary>
    /// The parameter was incorrect.
    /// </summary>
    public EFI_STATUS EFI_INVALID_PARAMETER => EncodeError(2);

    /// <summary>
    /// The operation is not supported.
    /// </summary>
    public EFI_STATUS EFI_UNSUPPORTED => EncodeError(3);

    /// <summary>
    /// The buffer was not the proper size for the request.
    /// </summary>
    public EFI_STATUS EFI_BAD_BUFFER_SIZE => EncodeError(4);

    /// <summary>
    /// The buffer was not large enough to hold the requested data.
    /// The required buffer size is returned in the appropriate
    /// parameter when this error occurs.
    /// </summary>
    public EFI_STATUS EFI_BUFFER_TOO_SMALL => EncodeError(5);

    /// <summary>
    /// There is no data pending upon return.
    /// </summary>
    public EFI_STATUS EFI_NOT_READY => EncodeError(6);

    /// <summary>
    /// The physical device reported an error while attempting the
    /// operation.
    /// </summary>
    public EFI_STATUS EFI_DEVICE_ERROR => EncodeError(7);

    /// <summary>
    /// The device can not be written to.
    /// </summary>
    public EFI_STATUS EFI_WRITE_PROTECTED => EncodeError(8);

    /// <summary>
    /// The resource has run out.
    /// </summary>
    public EFI_STATUS EFI_OUT_OF_RESOURCES => EncodeError(9);

    /// <summary>
    /// An inconsistency was detected on the file system causing the
    /// operation to fail.
    /// </summary>
    public EFI_STATUS EFI_VOLUME_CORRUPTED => EncodeError(10);

    /// <summary>
    /// There is no more space on the file system.
    /// </summary>
    public EFI_STATUS EFI_VOLUME_FULL => EncodeError(11);

    /// <summary>
    /// The device does not contain any medium to perform the
    /// operation.
    /// </summary>
    public EFI_STATUS EFI_NO_MEDIA => EncodeError(12);

    /// <summary>
    /// The medium in the device has changed since the last
    /// access.
    /// </summary>
    public EFI_STATUS EFI_MEDIA_CHANGED => EncodeError(13);

    /// <summary>
    /// The item was not found.
    /// </summary>
    public EFI_STATUS EFI_NOT_FOUND => EncodeError(14);

    /// <summary>
    /// Access was denied.
    /// </summary>
    public EFI_STATUS EFI_ACCESS_DENIED => EncodeError(15);

    /// <summary>
    /// The server was not found or did not respond to the request.
    /// </summary>
    public EFI_STATUS EFI_NO_RESPONSE => EncodeError(16);

    /// <summary>
    /// A mapping to the device does not exist.
    /// </summary>
    public EFI_STATUS EFI_NO_MAPPING => EncodeError(17);

    /// <summary>
    /// A timeout time expired.
    /// </summary>
    public EFI_STATUS EFI_TIMEOUT => EncodeError(18);

    /// <summary>
    /// The protocol has not been started.
    /// </summary>
    public EFI_STATUS EFI_NOT_STARTED => EncodeError(19);

    /// <summary>
    /// The protocol has already been started.
    /// </summary>
    public EFI_STATUS EFI_ALREADY_STARTED => EncodeError(20);

    /// <summary>
    /// The operation was aborted.
    /// </summary>
    public EFI_STATUS EFI_ABORTED => EncodeError(21);

    /// <summary>
    /// An ICMP error occurred during the network operation.
    /// </summary>
    public EFI_STATUS EFI_ICMP_ERROR => EncodeError(22);

    /// <summary>
    /// A TFTP error occurred during the network operation.
    /// </summary>
    public EFI_STATUS EFI_TFTP_ERROR => EncodeError(23);

    /// <summary>
    /// A protocol error occurred during the network operation.
    /// </summary>
    public EFI_STATUS EFI_PROTOCOL_ERROR => EncodeError(24);

    /// <summary>
    /// A function encountered an internal version that was
    /// incompatible with a version requested by the caller.
    /// </summary>
    public EFI_STATUS EFI_INCOMPATIBLE_VERSION => EncodeError(25);

    /// <summary>
    /// The function was not performed due to a security violation.
    /// </summary>
    public EFI_STATUS EFI_SECURITY_VIOLATION => EncodeError(26);

    /// <summary>
    /// A CRC error was detected.
    /// </summary>
    public EFI_STATUS EFI_CRC_ERROR => EncodeError(27);

    /// <summary>
    /// The beginning or end of media was reached.
    /// </summary>
    public EFI_STATUS EFI_END_OF_MEDIA => EncodeError(28);

    /// <summary>
    /// The end of the file was reached.
    /// </summary>
    public EFI_STATUS EFI_END_OF_FILE => EncodeError(31);

    /// <summary>
    /// The language specified was invalid.
    /// </summary>
    public EFI_STATUS EFI_INVALID_LANGUAGE => EncodeError(32);

    /// <summary>
    /// The security status of the data is unknown or compromised
    /// and the data must be updated or replaced to restore a valid
    /// security status.
    /// </summary>
    public EFI_STATUS EFI_COMPROMISED_DATA => EncodeError(33);

    /// <summary>
    /// A HTTP error occurred during the network operation.
    /// </summary>
    public EFI_STATUS EFI_HTTP_ERROR => EncodeError(35);






    /// <summary>
    /// The string contained one or more characters that
    /// the device could not render and were skipped.
    /// <summary>
    public EFI_STATUS EFI_WARN_UNKNOWN_GLYPH => EncodeWarning(1);

    /// <summary>
    /// The handle was closed, but the file was not deleted.
    /// <summary>
    public EFI_STATUS EFI_WARN_DELETE_FAILURE => EncodeWarning(2);

    /// <summary>
    /// The handle was closed, but the data to the file was not
    /// flushed properly.
    /// <summary>
    public EFI_STATUS EFI_WARN_WRITE_FAILURE => EncodeWarning(3);

    /// <summary>
    /// The resulting buffer was too small, and the data was
    /// truncated to the buffer size.
    /// <summary>
    public EFI_STATUS EFI_WARN_BUFFER_TOO_SMALL => EncodeWarning(4);

    /// <summary>
    /// The data has not been updated within the timeframe set by
    /// local policy for this type of data.
    /// <summary>
    public EFI_STATUS EFI_WARN_STALE_DATA => EncodeWarning(5);

    /// <summary>
    /// The resulting buffer contains UEFI-compliant file system.
    /// <summary>
    public EFI_STATUS EFI_WARN_FILE_SYSTEM => EncodeWarning(6);

}
