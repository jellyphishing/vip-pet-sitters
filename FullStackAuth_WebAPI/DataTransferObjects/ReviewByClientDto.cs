

namespace FullStackAuth_WebAPI.DataTransferObjects
{
    public class ReviewByClientDto
    {
        public int Id { get; set; }
        public string SitterId { get; set; }    
        public string Text { get; set; }

        public UserForDisplayDto User { get; set; }
    }
}
