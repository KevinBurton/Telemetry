using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Utility
{
    public class UUEncode
    {
        /// <summary>
        /// InfoPathAttachment encodes file data into the format expected by InfoPath for use in file attachment nodes.
        /// </summary>
        private string base64EncodedFile = string.Empty;
        private readonly string fullyQualifiedFileName;

        /// <summary>
        /// Creates an encoder to create an InfoPath attachment string.
        /// </summary>
        /// <param name="fullyQualifiedFileName"></param>
        public UUEncode(string fullyQualifiedFileName)
        {
            if (fullyQualifiedFileName == string.Empty)
                throw new ArgumentException("Must specify file name", "fullyQualifiedFileName");

            if (!File.Exists(fullyQualifiedFileName))
                throw new FileNotFoundException("File does not exist: " + fullyQualifiedFileName, fullyQualifiedFileName);

            this.fullyQualifiedFileName = fullyQualifiedFileName;
        }

        /// <summary>
        /// Returns a Base64 encoded string.
        /// </summary>
        /// <returns>String</returns>
        public string ToBase64String()
        {
            if (base64EncodedFile != string.Empty)
                return base64EncodedFile;

            // This memory stream will hold the InfoPath file attachment buffer before Base64 encoding.
            var ms = new MemoryStream();

            // Get the file information.
            using (BinaryReader br = new BinaryReader(File.Open(fullyQualifiedFileName, FileMode.Open, FileAccess.Read, FileShare.Read)))
            {
                var fileName = Path.GetFileName(fullyQualifiedFileName);

                var fileNameLength = (uint)fileName.Length + 1;

                var fileNameBytes = Encoding.Unicode.GetBytes(fileName);

                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                    // Write the InfoPath attachment signature. 
                    bw.Write(new byte[] { 0xC7, 0x49, 0x46, 0x41 });

                    // Write the default header information.
                    bw.Write((uint)0x14);// size
                    bw.Write((uint)0x01);// version
                    bw.Write((uint)0x00);// reserved

                    // Write the file size.
                    bw.Write((uint)br.BaseStream.Length);

                    // Write the size of the file name.
                    bw.Write((uint)fileNameLength);

                    // Write the file name (Unicode encoded).
                    bw.Write(fileNameBytes);

                    // Write the file name terminator. This is two nulls in Unicode.
                    bw.Write(new byte[] { 0, 0 });

                    // Iterate through the file reading data and writing it to the outbuffer.
                    var data = new byte[64 * 1024];
                    var bytesRead = 1;

                    while (bytesRead > 0)
                    {
                        bytesRead = br.Read(data, 0, data.Length);
                        bw.Write(data, 0, bytesRead);
                    }
                }
            }

            // This memorystream will hold the Base64 encoded InfoPath attachment.
            var msOut = new MemoryStream();

            using (BinaryReader br = new BinaryReader(new MemoryStream(ms.ToArray())))
            {
                // Create a Base64 transform to do the encoding.
                var tf = new ToBase64Transform();

                var data = new byte[tf.InputBlockSize];
                var outData = new byte[tf.OutputBlockSize];

                var bytesRead = 1;

                while (bytesRead > 0)
                {
                    bytesRead = br.Read(data, 0, data.Length);

                    if (bytesRead == data.Length)
                        tf.TransformBlock(data, 0, bytesRead, outData, 0);
                    else
                        outData = tf.TransformFinalBlock(data, 0, bytesRead);

                    msOut.Write(outData, 0, outData.Length);
                }
            }

            msOut.Close();

            return base64EncodedFile = Encoding.ASCII.GetString(msOut.ToArray());
        }
    }
}