using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpPracticum.Rashirenie
{
    public class FileWriter : IDisposable
    {
        private StreamWriter? _writer;
        private bool _disposed;

        public string FilePath { get; }

        public FileWriter(string path)
        {
            FilePath = path;
            _writer = new StreamWriter(path, append: false) { AutoFlush = true };
        }

        public void WriteLine(string text)
        {
            ThrowIfDisposed();
            _writer!.WriteLine(text);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(nameof(FileWriter));
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // Закрываем/освобождаем управляемый ресурс
                _writer?.Dispose();
                _writer = null;
            }

            _disposed = true;
        }
    }
}
