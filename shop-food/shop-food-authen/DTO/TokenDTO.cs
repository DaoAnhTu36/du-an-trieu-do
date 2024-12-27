namespace shop_food_authen.DTO
{
    public class TokenDTO
    {
        public string? AccessToken { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
