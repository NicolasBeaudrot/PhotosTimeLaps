﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PhotosTimeLaps.Models;

namespace PhotosTimeLaps.Photo
{
    public interface IPhotoManager
    {
        Task<IEnumerable<PhotoViewModel>> Get();
        Task<PhotoActionResult> Delete(string fileName);
        Task<IEnumerable<PhotoViewModel>> Add(HttpRequestMessage request);
        bool FileExists(string fileName);
    }
}
