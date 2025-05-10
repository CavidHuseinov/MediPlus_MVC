
namespace MediPlus.Domain.Settings
{
    public class AWS
    {
        public string AccessKeyId { get; set; } = default!;
        public string SecretAccessKey { get; set; } = default!;
        public string EndPointUrl { get; set; } = default!;
        public string BucketName { get; set; } = default!;
        public string Region { get; set; } = default!;
    }
}
