using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.ApiConsuption.Helpers
{
    public class CoreConvertions
    {

        public byte[] ObjectToByteArray(Object obj)
        {
            if (obj == null)
                return null;
#pragma warning disable SYSLIB0011
            var bf = new BinaryFormatter();
#pragma warning restore  SYSLIB0011
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);

            return ms.ToArray();
        }

        // Convert a byte array to an Object
        public Object ByteArrayToObject(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
#pragma warning disable SYSLIB0011
            var binForm = new BinaryFormatter();
#pragma warning restore SYSLIB0011
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            Object obj = (Object)binForm.Deserialize(memStream);

            return obj;
        }
    }
}
