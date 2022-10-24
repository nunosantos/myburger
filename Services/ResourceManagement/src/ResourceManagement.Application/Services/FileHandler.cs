namespace ResourceManagement.Application.Services
{
    public static class FileHandler
    {
        public static string GenerateFileName(string fileName, string customerName)
        {
            try
            {
                var strName = fileName.Split('.');
                fileName = customerName + DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/"
                   + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." +
                   strName[strName.Length - 1];
                return fileName;
            }
            catch (Exception ex)
            {
                return fileName;
            }
        }

        public static object GenerateFileName(object fileName1, object fileName2)
        {
            throw new NotImplementedException();
        }
    }
}