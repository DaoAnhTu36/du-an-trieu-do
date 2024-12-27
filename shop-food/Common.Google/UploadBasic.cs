using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using File = Google.Apis.Drive.v3.Data.File;

namespace Common.Google
{
    public static class UploadBasic
    {
        public static void Upload(string clientId, string secretId, string filePath)
        {
            var service = AuthenticateGoogleDrive(clientId, secretId);
            UploadImageToDrive(service, filePath);
        }

        private static DriveService AuthenticateGoogleDrive(string clientId, string secretId)
        {
            UserCredential credential;
            string[] scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile };
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets
                {
                    ClientId = clientId,
                    ClientSecret = secretId
                },
                scopes,
                "user",
                CancellationToken.None
            ).Result;

            var service = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "ShopDaoAnhTu",
            });

            return service;
        }

        private static void UploadImageToDrive(DriveService service, string filePath)
        {
            var fileMetadata = new File
            {
                Name = Path.GetFileName(filePath),
                MimeType = "image/jpeg"
            };

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                var request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                var response = request.Upload();

                if (response.Status == UploadStatus.Completed)
                {
                    Console.WriteLine("Upload successful! File ID: " + request.ResponseBody.Id);
                }
                else
                {
                    Console.WriteLine("Upload failed. Status: " + response.Status);
                }
            }
        }
    }
}