using GeJu.Common.DTO.Brands;

namespace GeJu.Api.Main.Test.Brand
{
    internal static class Mother
    {
        public static CreateBrandDTO NewBrand => new CreateBrandDTO
        {
            Description = "Test",
            Name = "test"
        };
        public static UpdateBrandDTO UpdateBrand => new UpdateBrandDTO
        {
            Description = "Test2",
            Name = "test"
        };
    }
}
