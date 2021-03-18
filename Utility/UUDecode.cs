using System;
using System.IO;
using System.Text;

namespace Utility
{
    public class UUDecode
    {
        /// <summary>
        /// Decodes a file attachment and saves it to a specified path.
        /// </summary>
        private const int SP1Header_Size = 20;
        private const int FIXED_HEADER = 16;

        private int fileSize;
        private int decodeNameLength;
        private string decodeName;
        private byte[] decoded;

        /// <summary>
        /// Accepts the Base64 encoded string
        /// that is the attachment.
        /// </summary>
        public UUDecode(string theBase64EncodedString)
        {
            byte[] theData = Convert.FromBase64String(theBase64EncodedString);
            using (MemoryStream ms = new MemoryStream(theData))
            {
                BinaryReader theReader = new BinaryReader(ms);
                Decode(theReader);
            }
        }

        private void Decode(BinaryReader theReader)
        {
            //Position the reader to get the file size.
            byte[] headerData = new byte[FIXED_HEADER];
            headerData = theReader.ReadBytes(headerData.Length);

            fileSize = (int)theReader.ReadUInt32();
            decodeNameLength = (int)theReader.ReadUInt32() * 2;

            byte[] fileNameBytes = theReader.ReadBytes(decodeNameLength);
            //InfoPath uses UTF8 encoding.
            Encoding enc = Encoding.Unicode;
            decodeName = enc.GetString(fileNameBytes, 0, decodeNameLength - 2);
            decoded = theReader.ReadBytes(fileSize);
        }

        public void SaveDecoded(string saveLocation)
        {
            string fullFileName = saveLocation;
            if (!fullFileName.EndsWith(Path.DirectorySeparatorChar))
            {
                fullFileName += Path.DirectorySeparatorChar;
            }

            fullFileName += decodeName;

            if (File.Exists(fullFileName))
                File.Delete(fullFileName);

            FileStream fs = new FileStream(fullFileName, FileMode.CreateNew);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(decoded);

            bw.Close();
            fs.Close();
        }

        public string Filename
        {
            get { return decodeName; }
        }

        public byte[] Decoded
        {
            get { return decoded; }
        }
    }
}
