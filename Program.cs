using ISO_IEC_3309_16_bit_CRC;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

string plainTextData = "20101021202164403849800004306041552202409801";

byte[] inputBytes = Encoding.UTF8.GetBytes(plainTextData);

int crcvalue = Crc.crc16(inputBytes);
Console.WriteLine(crcvalue);

ushort value = Crc.CRCCalc(inputBytes);
Console.WriteLine(value);

Crc.slowCrc16LsbFirst(inputBytes, 65535, 4129);
Crc.slowCrc16MsbFirst(inputBytes, 65535, 4129);

