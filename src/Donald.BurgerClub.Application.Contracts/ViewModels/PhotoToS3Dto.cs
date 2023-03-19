using System;

namespace Donald.BurgerClub.ViewModels
{
    public class PhotoToS3Dto
    {
        public string Name { get; set; }

        public string S3Url { get; set; }

        public DateTime CreateDate {  get; set; }

        public PhotoToS3Dto()
        {
            
        }

        public PhotoToS3Dto(string name, string s3Url)
        {
            this.Name = name;
            this.S3Url = s3Url;
            this.CreateDate = DateTime.Now;
        }
    }
}
