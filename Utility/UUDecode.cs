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
            var theData = Convert.FromBase64String(theBase64EncodedString);
            using (MemoryStream ms = new MemoryStream(theData))
            {
                var theReader = new BinaryReader(ms);
                Decode(theReader);
            }
        }

        private void Decode(BinaryReader theReader)
        {
            //Position the reader to get the file size.
            var headerData = new byte[FIXED_HEADER];
            headerData = theReader.ReadBytes(headerData.Length);

            fileSize = (int)theReader.ReadUInt32();
            decodeNameLength = (int)theReader.ReadUInt32() * 2;

            var fileNameBytes = theReader.ReadBytes(decodeNameLength);
            //InfoPath uses UTF8 encoding.
            var enc = Encoding.Unicode;
            decodeName = enc.GetString(fileNameBytes, 0, decodeNameLength - 2);
            decoded = theReader.ReadBytes(fileSize);
        }

        public void SaveDecoded(string saveLocation)
        {
            var fullFileName = Path.Combine(saveLocation, decodeName);

            if (File.Exists(fullFileName))
                File.Delete(fullFileName);

            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                fs = new FileStream(fullFileName, FileMode.CreateNew);
                bw = new BinaryWriter(fs);
                bw.Write(decoded);
            }
            finally
            {               
                if(bw != null) bw.Close();
                if(fs != null) fs.Close();
            }
        }

        public string Filename => decodeName;
        public byte[] Decoded => decoded;
    }
}
