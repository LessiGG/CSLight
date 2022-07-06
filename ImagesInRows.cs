using System;

namespace CSLight
{
    class ImagesInRows
    {
        static void Main(string[] args)
        {
            int imagesPerRow = 3;
            int imagesCount = 52;

            int completedRows = imagesCount / imagesPerRow;
            int imagesLeft = imagesCount % imagesPerRow;
            
            Console.WriteLine($"Заполнено рядов {completedRows}, осталось картинок {imagesLeft}");
        }
    }
}