namespace ISO_IEC_3309_16_bit_CRC
{
    public class Crc
    {
        private const int POLYNOMIAL = 4129;
        private const int PRESET_VALUE = 65535;

        public static int crc16(byte[] data)
        {
            var current_crc_value = PRESET_VALUE;
            for (int i = 0; i < data.Length; i++)
            {
                current_crc_value ^= data[i] & 255;
                for (int j = 0; j < 8; j++)
                {
                    if ((current_crc_value & 1) != 0)
                    {
                        current_crc_value = (current_crc_value >> 1) ^ POLYNOMIAL;
                    }
                    else
                    {
                        current_crc_value = current_crc_value >> 1;
                    }
                }
            }

            current_crc_value = ~current_crc_value;
            return current_crc_value & 65535;
        }

        public static ushort CRCCalc(byte[] data)
        {
            ushort wCRC = 0xFFFF;
            ushort polynomial = 0x1021;
            for (int i = 1; i < data.Length; i++)
            {
                wCRC = (ushort)(wCRC ^ (data[i] << 8));

                for (int j = 0; j < 8; j++)
                {
                    if ((wCRC & 0x8000) != 0)
                        wCRC = (ushort)((wCRC << 1) ^ polynomial);
                    else
                        wCRC <<= 1;
                }
            }
            Console.WriteLine(wCRC);
            return wCRC;
        }


        // Bit-order LSB first (right to left).
        public static int slowCrc16LsbFirst(byte[] data, int initialValue, int poly)
        {
            int crc = initialValue;
            for (int p = 0; p < data.Length; p++)
            {
                crc ^= (data[p] & 0xFF);
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 1) != 0)
                    {
                        crc = (crc >> 1) ^ poly;
                    }
                    else
                    {
                        crc = crc >> 1;
                    }
                }
            }
            Console.WriteLine($"value with lsb : {crc}");
            return crc;
        }

        // Bit-order MSB first (left to right).
        public static int slowCrc16MsbFirst(byte[] data, int initialValue, int poly)
        {
            int crc = initialValue;
            for (int p = 0; p < data.Length; p++)
            {
                crc ^= (data[p] & 0xFF) << 8;
                for (int i = 0; i < 8; i++)
                {
                    if ((crc & 0x8000) != 0)
                    {
                        crc = ((crc << 1) & 0xFFFF) ^ poly;
                    }
                    else
                    {
                        crc = (crc << 1) & 0xFFFF;
                    }
                }
            }
            Console.WriteLine($"value with msb : {crc}");
            return crc;
        }

    }
}
