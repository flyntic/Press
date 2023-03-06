using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPress.SerializeService
{
    public class BinarrySerializeFormat : ISerializeType
    {
        private BinaryFormatter formatter = new BinaryFormatter();
        public ISerialize Deserialize(ISerialize obj, Type type = null)
        {
            if (File.Exists($"{obj.FileName}.bin") == false) return null;

            try
            {
                using (var fs = new FileStream($"{obj.FileName}.bin", FileMode.Open))
                {
                    return (ISerialize)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return null;
        }

        public void Serialize(ISerialize obj, Type type = null)
        {
            try
            {
                using (var fs = new FileStream($"{obj.FileName}.bin", FileMode.Create))
                {
                    formatter.Serialize(fs, obj);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
