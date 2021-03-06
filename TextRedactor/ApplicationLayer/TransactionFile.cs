﻿using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Transactions;
using Microsoft.Win32.SafeHandles;

namespace ApplicationLayer
{
    internal sealed class TransactionFile
    {
        [DllImport("Kernel32.Dll", EntryPoint = "CreateFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        protected static extern SafeFileHandle CreateFileTransacted(
            [In] String lpFileName,
            [In] SafeTransactionHandle.FileAccess dwDesiredAccess,
            [In] SafeTransactionHandle.FileShare dwShareMode,
            [In] IntPtr lpSecurityAttributes,
            [In] SafeTransactionHandle.FileMode dwCreationDisposition,
            [In] int dwFlagsAndAttributes,
            [In] IntPtr hTemplateFile,
            [In] SafeTransactionHandle hTransaction,
            [In] IntPtr pusMiniVersion,
            [In] IntPtr pExtendedParameter
        );

        [DllImport("Kernel32.Dll", EntryPoint = "CopyFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        protected static extern bool CopyFileTransacted(
           [In] String lpExistingFileName,
           [In] String lpNewFileName,
           [In] IntPtr lpProgressRoutine,
           [In] IntPtr lpData,
           [In] bool pbCancel,
           [In] SafeTransactionHandle.Copy dwCopyFlags,
           [In] SafeTransactionHandle hTransaction
       );

        [DllImport("Kernel32.Dll", EntryPoint = "OpenFile", CharSet = CharSet.Unicode, SetLastError = true)]
        protected static extern SafeFileHandle OpenFile(
          [In] String lpFileName,
          [In] _OFSTRUCT lpReOpenBuff,
          [In] IntPtr uStyle
      );

        [DllImport("Kernel32.Dll", EntryPoint = "MoveFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        protected static extern bool MoveFileTransacted(
           [In] String lpExistingFileName,
           [In] String lpNewFileName,
           [In] IntPtr lpProgressRoutine,
           [In] IntPtr lpData,
           [In] SafeTransactionHandle.Move dwFlags,
           [In] SafeTransactionHandle hTransaction
       );

        [DllImport("Kernel32.Dll", EntryPoint = "DeleteFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        protected static extern bool DeleteFileTransacted(
            [In] String lpFileName,
            [In] SafeTransactionHandle hTransaction
        );

        [ComImport]
        [Guid("79427A2B-F895-40e0-BE79-B57DC82ED231")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        protected interface IKernelTransaction
        {
            void GetHandle(out SafeTransactionHandle ktmHandle);
        }

        private static SafeFileHandle CreateFileHandled(string path, ref string message)
        {
           
            SafeTransactionHandle txHandle = null;
            SafeFileHandle fileHandle = null;
            try
            {
                IKernelTransaction kernelTx =
                    (IKernelTransaction)TransactionInterop.GetDtcTransaction(Transaction.Current);
                kernelTx.GetHandle(out txHandle);

                fileHandle
                    = CreateFileTransacted(
                        path
                        , SafeTransactionHandle.FileAccess.GENERIC_WRITE
                        , SafeTransactionHandle.FileShare.FILE_SHARE_NONE
                        , IntPtr.Zero
                        , SafeTransactionHandle.FileMode.CREATE_ALWAYS
                        , 0
                        , IntPtr.Zero
                        , txHandle
                        , IntPtr.Zero
                        , IntPtr.Zero);
                if (Path.GetExtension(path) == ".xaml")
                {
                    WriteToFile(Properties.Resources.Template, path, ref message, fileHandle);
                }
                if (fileHandle.IsInvalid)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            catch (Exception ex)
            {
                message = ex.Message;
                Transaction.Current.Rollback();
            }
            finally
            {
                if (txHandle != null)
                {
                    txHandle.Dispose();
                }
            }
            return fileHandle;
        }

        public static bool CreateFile(string path, ref string message)
        {
            return TransactionActionHelper.DoActionWithCheckOnTransaction((ref string s) =>
            {
                if (!TransactionActionHelper.CheckConditions((ref string mes) =>
                {
                    if (File.Exists(path) || !Directory.Exists(Path.GetDirectoryName(path)))
                    {
                        mes = "Wrong path or file exists";
                        Transaction.Current.Rollback();
                        return false;
                    }
                    return true;
                }, ref s))
                { 
                    return false;
                }
                var handle = CreateFileHandled(path, ref s);
                if (handle == null)
                {
                    return false;
                }
                handle.Dispose();
                return true;
            }, ref message);
        }

        public static bool CopyFileTo(string path, string pathCopy, ref string message)
        {
            return TransactionActionHelper.DoActionWithCheckOnTransaction((ref string s) =>
            {
                if (!TransactionActionHelper.CheckConditions((ref string mes) =>
                {
                    if (!File.Exists(path) || File.Exists(pathCopy))
                    {
                        mes = "Wrong path or file exists";
                        Transaction.Current.Rollback();
                        return false;
                    }
                    return true;
                }, ref s))
                {
                    return false;
                }
                bool response = false;
                SafeTransactionHandle txHandle = null;
                try
                {
                    IKernelTransaction kernelTx =
                       (IKernelTransaction)TransactionInterop.GetDtcTransaction(Transaction.Current);
                    kernelTx.GetHandle(out txHandle);
                    response = CopyFileTransacted(path, pathCopy, IntPtr.Zero, IntPtr.Zero, false,
                        SafeTransactionHandle.Copy.COPY_FILE_FAIL_IF_EXISTS, txHandle);
                }
                catch (Exception ex)
                {
                    s = ex.Message;
                    Transaction.Current.Rollback();
                }
                finally
                {
                    if (txHandle != null)
                    {
                        txHandle.Dispose();
                    }
                }
                return response;
            }, ref message);
        }

        public static bool DeleteFiles(FileArgs args)
        {
            bool response = true;
            string message = String.Empty;
            return TransactionActionHelper.DoActionWithCheckOnTransaction((ref string s) =>
            {
                foreach (var file in args.Files)
                {
                    if (!response) { return false; }
                    if (!TransactionActionHelper.CheckConditions((ref string mes) =>
                    {
                        if (!File.Exists(file))
                        {
                            mes = "Wrong path or file exists";
                            Transaction.Current.Rollback();
                            return false;
                        }
                        return true;
                    }, ref s))
                    {
                        return false;
                    }
                    SafeTransactionHandle txHandle = null;
                        try
                        {
                            IKernelTransaction kernelTx =
                                (IKernelTransaction)TransactionInterop.GetDtcTransaction(Transaction.Current);
                            kernelTx.GetHandle(out txHandle);
                            if(!DeleteFileTransacted(file, txHandle))
                            {
                                Transaction.Current.Rollback();
                                response = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            response = false;
                            s = ex.Message;
                            Transaction.Current.Rollback();
                        }
                        finally
                        {
                            if (txHandle != null && !txHandle.IsInvalid)
                            {
                                txHandle.Dispose();
                            }
                        }
                }
                return response;
            }, ref message);
        }

        public static bool MoveFile(string path, string pathCopy, ref string message)
        {
            return TransactionActionHelper.DoActionWithCheckOnTransaction((ref string s) =>
            {
                if (!TransactionActionHelper.CheckConditions((ref string mes) =>
                {
                    if (!File.Exists(path) || File.Exists(pathCopy))
                    {
                        mes = "Wrong path or file exists";
                        return false;
                    }
                    return true;
                }, ref s))
                {
                    return false;
                }
                bool response = true;
                SafeTransactionHandle txHandle = null;
                try
                {
                    IKernelTransaction kernelTx =
                       (IKernelTransaction)TransactionInterop.GetDtcTransaction(Transaction.Current);
                    kernelTx.GetHandle(out txHandle);
                    response = MoveFileTransacted(path, pathCopy, IntPtr.Zero, IntPtr.Zero, SafeTransactionHandle.Move.MOVEFILE_COPY_ALLOWED, txHandle);
                }
                catch (Exception ex)
                {
                    response = false;
                    s = ex.Message;
                    Transaction.Current.Rollback();
                }
                finally
                {
                    if (txHandle != null)
                    {
                        txHandle.Dispose();
                    }
                }
                return response;
            }, ref message);
        }

        public static bool WriteToFile(byte[] data, string path, ref string message, SafeFileHandle handle = null)
        {
            if (data == null)
            {
                message = "Empty data";
                return false;
            }
            bool response = true;
            try
            {
                var fileHandle = handle ?? OpenFile(path, new _OFSTRUCT { fFixedDisk = 1, szPathName = path, cBytes = Marshal.SizeOf(typeof(_OFSTRUCT)) }, IntPtr.Zero);
                if (fileHandle == null)
                {
                    Transaction.Current.Rollback();
                    return false;
                }
                using (var stream = new FileStream(fileHandle, FileAccess.Write, 20480, false))
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            catch (Exception ex)
            {
                response = false;
                message = ex.Message;
                Transaction.Current.Rollback();
            }
            finally
            {
                if (handle != null)
                {
                    handle.Dispose();
                }
            }
            return response;
        }
        protected struct _OFSTRUCT
        {
            public int cBytes;
            public byte fFixedDisk;
            public IntPtr nErrCode;
            public IntPtr Reserved1;
            public IntPtr Reserved2;
            public string szPathName;
        }

        protected sealed class SafeTransactionHandle : SafeHandleZeroOrMinusOneIsInvalid
        {
            [DllImport("Kernel32.dll", SetLastError = true)]
            private static extern bool CloseHandle(IntPtr handle);

            public SafeTransactionHandle() : base(true)
            {
            }

            public SafeTransactionHandle(IntPtr preexistingHandle, bool ownsHandle)
                : base(ownsHandle)
            {
                SetHandle(preexistingHandle);
            }

            public enum Move
            {
                MOVEFILE_COPY_ALLOWED = 0x2,
                MOVEFILE_CREATE_HARDLINK = 0x10,
                MOVEFILE_DELAY_UNTIL_REBOOT = 0x4,
                MOVEFILE_REPLACE_EXISTING = 0x1,
                MOVEFILE_WRITE_THROUGH = 0x8
            }

            public enum Copy
            {
                COPY_FILE_COPY_SYMLINK = unchecked((int)0x80000000),
                COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
                COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
                COPY_FILE_RESTARTABLE = 0x00000002
            }

            public enum FileAccess
            {
                GENERIC_READ = unchecked((int)0x80000000),
                GENERIC_WRITE = 0x40000000
            }

            [Flags]
            public enum FileShare
            {
                FILE_SHARE_NONE = 0x00,
                FILE_SHARE_READ = 0x01,
                FILE_SHARE_WRITE = 0x02,
                FILE_SHARE_DELETE = 0x04
            }

            public enum FileMode
            {
                CREATE_NEW = 1,
                CREATE_ALWAYS = 2,
                OPEN_EXISTING = 3,
                OPEN_ALWAYS = 4,
                TRUNCATE_EXISTING = 5
            }

            protected override bool ReleaseHandle()
            {
                return CloseHandle(handle);
            }
        }
    }
}
