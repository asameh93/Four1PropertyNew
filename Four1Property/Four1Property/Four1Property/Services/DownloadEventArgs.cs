﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Four1Property.Services
{
    public class DownloadEventArgs : EventArgs
    {
        public bool FileSaved = false;
        public DownloadEventArgs(bool fileSaved)
        {
            FileSaved = fileSaved;
        }
    }
}
