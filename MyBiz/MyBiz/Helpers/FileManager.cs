using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MyBiz.Helpers
{
	public static class FileManager
	{
		public static string Save(string root, string folder, IFormFile file)
        {
			//Creating new Guid -- guid is a string text that helps to make name of file unique
			//GUID -- Globally Unique Identifier or ID
			var guid = Guid.NewGuid().ToString();
			var newFileName = guid + (file.FileName.Length>64?file.FileName.Substring(file.FileName.Length - 64, 64):file.FileName);

			//IWebHostEnvironment env is used to give dynamic path to user. It identifies wwwroot folder from all projects.
			//string path = _env.WebRootPath + @"/uploads/teammembers/" + newFileName;

			string path = Path.Combine(root, folder, newFileName);

            using FileStream stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);

			return newFileName;
        }
	}
}

