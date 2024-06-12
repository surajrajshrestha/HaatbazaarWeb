using Microsoft.AspNetCore.Mvc;

namespace HaatBazaar.Web.Controllers
{
    public class ExcelExtractorController : Controller
    {
        //public async Task<IActionResult> ExtractItems()
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot/documents/Dataset.xlsx";

        //    var existingFile = new FileInfo(filePath);
        //    List<string> itemRecords = [];
        //    using (var excelPackage = new ExcelPackage(existingFile))
        //    {
        //        // Item
        //        var itemWorksheet = excelPackage.Workbook.Worksheets["Item"];

        //        var rowCount = itemWorksheet.Dimension.Rows;
        //        var colCount = itemWorksheet.Dimension.Columns;
        //        var categoryId = 0;
        //        var itemId = 0;

        //        for (var row = 2; row <= rowCount; row++)
        //        {
        //            for (var column = 1; column <= colCount; column += colCount)
        //            {
        //                var categoryName = Convert.ToString(itemWorksheet.Cells[row, column + 1].Value)!.ToLower();

        //                if (!context.Categories.Any(c =>
        //                        c.Name.ToLower().Equals(categoryName)))
        //                {
        //                    var category = new Category()
        //                    {
        //                        Name = categoryName
        //                    };
        //                    context.Categories.Add(category);
        //                    await context.SaveChangesAsync();
        //                    categoryId = category.Id;
        //                }

        //                var itemName = Convert.ToString(itemWorksheet.Cells[row, column].Value)!.ToLower();

        //                if (!context.Items.Any(i =>
        //                        i.Name.ToLower().Equals(itemName)))
        //                {
        //                    var item = new Item
        //                    {
        //                        Name = itemName
        //                    };
        //                    context.Items.Add(item);
        //                    await context.SaveChangesAsync();
        //                    itemId = item.Id;

        //                    var itemCategory = new ItemCategory()
        //                    {
        //                        RowGuid = Guid.NewGuid(),
        //                        CategoryId = categoryId,
        //                        ItemId = itemId
        //                    };
        //                    context.ItemCategories.AddRange(itemCategory);
        //                    await context.SaveChangesAsync();
        //                }

        //                var imagePath = Convert.ToString(itemWorksheet.Cells[row, column + 2].Value);

        //                if (!string.IsNullOrWhiteSpace(imagePath))
        //                {
        //                    if (!context.Images.Any(i =>
        //                            i.Path != null && i.Path.ToLower().Equals(imagePath)))
        //                    {
        //                        var image = new Image
        //                        {
        //                            Path = imagePath,
        //                            CreatedDate = DateTime.UtcNow
        //                        };
        //                        context.Images.Add(image);
        //                        await context.SaveChangesAsync();

        //                        var itemImage = new ItemImage()
        //                        {
        //                            RowGuid = Guid.NewGuid(),
        //                            ItemId = itemId,
        //                            ImageId = image.Id
        //                        };
        //                        context.ItemImages.Add(itemImage);
        //                        await context.SaveChangesAsync();
        //                    }
        //                }

        //                var tagName = Convert.ToString(itemWorksheet.Cells[row, column + 3].Value)!;
        //                if (!string.IsNullOrWhiteSpace(tagName))
        //                {
        //                    if (!context.Tags.Any(t => t.Name.Equals(tagName)))
        //                    {
        //                        var tag = new Tag
        //                        {
        //                            Name = tagName
        //                        };
        //                        context.Tags.Add(tag);
        //                        await context.SaveChangesAsync();

        //                        var itemTag = new ItemTag()
        //                        {
        //                            ItemId = itemId,
        //                            TagId = tag.Id
        //                        };
        //                        context.ItemTags.Add(itemTag);
        //                        await context.SaveChangesAsync();
        //                    }
        //                }

        //                itemRecords.Add($"{row}, {column}, {itemWorksheet.Cells[row, column].Value}, {itemWorksheet.Cells[row, column + 1].Value}, {itemWorksheet.Cells[row, column + 2].Value}, {itemWorksheet.Cells[row, column + 3].Value}");
        //            }
        //        }
        //    }

        //    return Ok(new { itemRecords });
        //}
        //public async Task<IActionResult> ExtractUsers()
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot/documents/Dataset.xlsx";
        //    var existingFile = new FileInfo(filePath);
        //    List<string> itemRecords = [];
            
        //    using (var excelPackage = new ExcelPackage(existingFile))
        //    {
        //       var itemWorksheet = excelPackage.Workbook.Worksheets["User"];

        //        var rowCount = itemWorksheet.Dimension.Rows;
        //        var colCount = itemWorksheet.Dimension.Columns;

        //        for (var row = 2; row <= rowCount; row++)
        //        {
        //            for (var column = 1; column <= colCount; column += colCount)
        //            {
        //                var phoneNumber = Convert.ToString(itemWorksheet.Cells[row, column].Value)!;
        //                var latitude = Convert.ToString(itemWorksheet.Cells[row, column + 1].Value)!;
        //                var longitude = Convert.ToString(itemWorksheet.Cells[row, column + 2].Value)!;

        //                if (!context.Users.Any(u => u.PhoneNumber.Equals(phoneNumber)))
        //                {
        //                    var user = new User()
        //                    {
        //                        Latitude = latitude,
        //                        Longitude = longitude,
        //                        PhoneNumber = phoneNumber,
        //                        Verified = true,
        //                        RegisteredDate = DateTime.UtcNow
        //                    };
        //                    context.Users.Add(user);
        //                    await context.SaveChangesAsync();
        //                }
        //                itemRecords.Add(@$"{row}, {column}, {itemWorksheet.Cells[row, column].Value}, {itemWorksheet.Cells[row, column + 1].Value}, {itemWorksheet.Cells[row, column + 2].Value}, {itemWorksheet.Cells[row, column + 3].Value}");
        //            }
        //        }
        //    }
        //    return Ok(itemRecords);
        //}
        //public async Task<IActionResult> MapUserItems()
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    var filePath = $"{Directory.GetCurrentDirectory()}/wwwroot/documents/Dataset.xlsx";
        //    var existingFile = new FileInfo(filePath);
        //    List<string> itemRecords = [];

        //    using (var excelPackage = new ExcelPackage(existingFile))
        //    {
        //        var itemWorksheet = excelPackage.Workbook.Worksheets["UserItem"];

        //        var rowCount = itemWorksheet.Dimension.Rows;
        //        var colCount = itemWorksheet.Dimension.Columns;

        //        for (var row = 2; row <= rowCount; row++)
        //        {
        //            for (var column = 1; column <= colCount; column += colCount)
        //            {
        //                var userIsValid = int.TryParse(Convert.ToString(itemWorksheet.Cells[row, column].Value!), out var userId);
        //                var itemIsValid = int.TryParse(Convert.ToString(itemWorksheet.Cells[row, column + 1].Value!), out var itemId);

        //                if (userIsValid)
        //                {
        //                    var user = await context.Users.FindAsync(userId);

        //                    if (user != null && itemIsValid)
        //                    {
        //                        var item = await context.Items.FindAsync(itemId);

        //                        if (item != null)
        //                        {
        //                            var quantityIsValid =
        //                                int.TryParse(Convert.ToString(itemWorksheet.Cells[row, column + 2].Value!),
        //                                    out var quantity);

        //                            var unit = Convert.ToString(itemWorksheet.Cells[row, column + 3].Value)!;
        //                            var priceIsValid = decimal.TryParse(Convert.ToString(itemWorksheet.Cells[row, column + 4].Value!), out decimal price);
        //                            var unitOfPrice = Convert.ToString(itemWorksheet.Cells[row, column + 5].Value)!;

        //                            await context.UserItems.AddAsync(new UserItem()
        //                            {
        //                                ItemId = item.Id,
        //                                UserId = user.Id,
        //                                Quantity = quantityIsValid ? quantity : 0,
        //                                Price = priceIsValid ? price : 0,
        //                                Unit = unit,
        //                                PriceUnit = unitOfPrice
        //                            });
        //                            await context.SaveChangesAsync();
        //                        }
        //                    }
        //                }
        //                itemRecords.Add(@$"{row}, {column}, {itemWorksheet.Cells[row, column].Value}, {itemWorksheet.Cells[row, column + 1].Value}, {itemWorksheet.Cells[row, column + 2].Value}, {itemWorksheet.Cells[row, column + 3].Value}");
        //            }
        //        }
        //    }
        //    return Ok(itemRecords);
        //}
    }
}
