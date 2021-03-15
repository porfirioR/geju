using GeJu.Api.Main.Models.Brands;

namespace GeJu.Api.Main.Test.Brand
{
    internal static class Mother
    {
        public static CreateBrandApiRequest NewBrand => new CreateBrandApiRequest
        {
            Description = "Test",
            Name = "test"
        };
        public static UpdateBrandApiRequest UpdateBrand => new UpdateBrandApiRequest
        {
            Description = "Test2",
            Name = "test"
        };
    }
}
