using HRM_BE.Api.Services.Interfaces;
using HRM_BE.Core.Constants;
using HRM_BE.Core.Models.File;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

namespace HRM_BE.Api.Controllers.File
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpPost("upload-single-file")]
        public async Task<string> UpLoadSingleFile(IFormFile file)
        {
            return await _fileService.UploadFileAsync(file,PathFolderConstant.General);
        } 
        [HttpPost("upload-multiple-file")]
        public async Task<List<string>> UpLoadMultipleFile(List<IFormFile> file)
        {
            return await _fileService.UploadMultipleFilesAsync(new UploadMultipleFileRequest { Files = file},PathFolderConstant.General);
        }

        [HttpPost("delete-file")]
        public async Task<bool> DeleteFile(string fileUrl)
        {
            return await _fileService.DeleteFileAsync(fileUrl);
        }
        [HttpPost("delete-files")]
        public async Task<List<string>> DeleteFiles(List<string> fileUrls)
        {
            return await _fileService.DeleteFilesAsync(fileUrls);
        }
    }
}
