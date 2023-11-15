namespace Demo.PL.Helper
{
    public static class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Files",folderName);
            var fileName =$"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}" ;
            var filePath = Path.Combine(folderPath,fileName);
            using var fileStream = new FileStream(filePath,FileMode.Create);

            file.CopyTo(fileStream);
            return fileName;
        }
    }
}
