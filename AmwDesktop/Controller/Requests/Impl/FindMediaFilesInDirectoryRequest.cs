using System;
using System.Collections.Generic;
using System.Threading;
using AirMedia.Core.Log;
using AirMedia.Core.Requests.Abs;
using AirMedia.Core.Requests.Model;
using AmwDesktop.Data.Models;

namespace AmwDesktop.Controller.Requests.Impl
{
    public class FindMediaFilesInDirectoryRequest : BaseLoadRequest<List<MediaFile>>
    {
        private static readonly string[] Extensions = new[] {"mp3"};

        protected override LoadRequestResult<List<MediaFile>> DoLoad(out RequestStatus status)
        {
            var result = new List<MediaFile>();

            AmwLog.Info("tag", "WORKING...");
            Thread.Sleep(5000);

            status = RequestStatus.Ok;

            return new LoadRequestResult<List<MediaFile>>(RequestResult.ResultCodeOk, result);
        }
    }
}
