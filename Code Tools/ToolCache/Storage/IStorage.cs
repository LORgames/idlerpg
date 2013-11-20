using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolCache.Storage {
    public interface IStorage {
        void Encode(string filename);

        void AddInt(int number);
        int GetInt();

        void AddShort(short number);
        short GetShort();

        void AddUnsignedShort(ushort number);

        void AddByte(byte number);
        byte GetByte();

        void AddLong(long number);
        long GetLong();

        void AddFloat(float number);
        float GetFloat();

        void AddString(string Message);
        string GetString();

        void Dispose();

        bool IsEndOfFile();
    }
}
