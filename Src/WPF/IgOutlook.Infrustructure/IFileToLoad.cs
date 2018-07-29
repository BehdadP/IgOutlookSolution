using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IgOutlook.Infrastructure
{
    public interface IFileToLoad
    {
        string FileName { get; set; } 
    }

    public class FileToLoad : IFileToLoad
    {
        private string _filename;
        public string FileName
        {
            get
            {
                return _filename;
            }

            set
            {
                _filename = value;
            }
        }
    }
}
