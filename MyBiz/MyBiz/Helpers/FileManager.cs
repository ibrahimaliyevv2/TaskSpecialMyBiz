using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MyBiz.Helpers
{
	public static class FileManager
	{
		//Method to save file with unique name
		public static string Save(string root, string folder, IFormFile file)
        {
			//Creating new Guid -- guid is a string text that helps to make name of file unique
			//GUID -- Globally Unique Identifier or ID
			var guid = Guid.NewGuid().ToString();

			//Name of file can not be greater than 64 characters, so we should make it either 64 or less, like below:
			var newFileName = guid + (file.FileName.Length>64?file.FileName.Substring(file.FileName.Length - 64, 64):file.FileName);
			//But, anyway, with ternary if, we check length, because, possibly it can be less than 64 and there is no length less than zero


			//IWebHostEnvironment env is used to give dynamic path to the user. It identifies wwwroot folder from all projects.
			//string path = _env.WebRootPath + @"/uploads/teammembers/" + newFileName;

			string path = Path.Combine(root, folder, newFileName);

			using (FileStream stream = new FileStream(path, FileMode.Create))
            {
				//copies our file to the stream
				file.CopyTo(stream);
			}

			return newFileName;  //returns new name for the file
        }

		public static bool Delete(string root, string folder, string fileName)
        {
			string path = Path.Combine(root, folder, fileName);

			//In the controller class it can not identify, File is a method of ControllerBase or used in System.IO
			//So if you'll use it in such class write System.IO beforehand
            if (File.Exists(path))
            {
				File.Delete(path);
				return true;
            }
			return false;
			
        }
	}
}

