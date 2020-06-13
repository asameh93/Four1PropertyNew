using System;
using System.Collections.Generic;
using System.Text;

namespace Four1Property.Services
{
    public interface ICopmressImage
    {
        byte[] ResizeImage(byte[] imageData, float width, float height);
    }
}
