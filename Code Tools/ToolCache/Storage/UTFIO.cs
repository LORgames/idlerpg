using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;
using System.Net.Sockets;

namespace ToolCache.Storage {
    public class UTFIO : IStorage {

        private string data;
        private int seamlessReadIndex = 0;

        private const char SECTION_CHAR = ',';

        public UTFIO(string received) {
            data = received;
            seamlessReadIndex = 0;
        }

        public UTFIO() {
            data = "";
        }

        public void Encode(string filename) {
            File.WriteAllText(filename, data);
        }

        private string ReadSection() {
            int nextBreak = data.IndexOf(SECTION_CHAR, seamlessReadIndex);
            string section = data.Substring(seamlessReadIndex, nextBreak - seamlessReadIndex);
            seamlessReadIndex = nextBreak + 1;

            return section;
        }

        public void AddInt(int number) {
            data += number.ToString() + SECTION_CHAR;
        }

        public int GetInt() {
            string x = ReadSection();
            return int.Parse(x);
        }

        public void AddShort(short number) {
            data += number.ToString() + SECTION_CHAR;
        }

        public short GetShort() {
            string x = ReadSection();
            return short.Parse(x);
        }

        public void AddUnsignedShort(ushort number) {
            data += number.ToString() + SECTION_CHAR;
        }

        public void AddByte(byte number) {
            data += number.ToString() + SECTION_CHAR;
        }

        public byte GetByte() {
            string x = ReadSection();
            return byte.Parse(x);
        }

        public void AddLong(long number) {
            data += number.ToString() + SECTION_CHAR;
        }

        public long GetLong() {
            string x = ReadSection();
            return long.Parse(x);
        }

        public void AddFloat(float number) {
            data += number.ToString() + SECTION_CHAR;
        }

        public float GetFloat() {
            return float.Parse(ReadSection());
        }

        public void AddString(string Message) {
            AddInt(Message.Length);
            data += Message + SECTION_CHAR;
        }

        public string GetString() {
            int length = GetInt();
            string section = data.Substring(seamlessReadIndex, length);
            seamlessReadIndex = seamlessReadIndex + length + 1;

            return section;
        }

        public override string ToString() {
            return "[UTF8IO: " + data.Length + " characters]";
        }

        public void Dispose() {
            data = "";
        }

        public bool IsEndOfFile() {
            return (seamlessReadIndex == data.Length);
        }
    }
}
