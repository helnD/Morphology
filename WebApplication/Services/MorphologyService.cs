using Domain;

namespace WebApplication.Services
{
    public class MorphologyService
    {
        private StructuralElement _structuralElement = new StructuralElement(new[]
        {
            new[] {1, 1, 1},
            new[] {1, 1, 1},
            new[] {1, 1, 1}
        });

        public ImageModel Calculate(int[][] image, string operation)
        {
            switch (operation)
            {
                case "incr": return Increasing(image);
                case "eros": return Erosion(image);
                case "clos": return Closing(image);
                default: return Opening(image);
            }
        }
        
        private ImageModel Increasing(int[][] image)
        {
            return new WorkModel(new ImageModel(image)).Increasing(_structuralElement);
        }
        
        private ImageModel Erosion(int[][] image)
        {
            return new WorkModel(new ImageModel(image)).Erosion(_structuralElement);
        }
        
        private ImageModel Closing(int[][] image)
        {
            return new WorkModel(new ImageModel(image)).Closing(_structuralElement);
        }
        
        private ImageModel Opening(int[][] image)
        {
            return new WorkModel(new ImageModel(image)).Opening(_structuralElement);
        }
    }
}