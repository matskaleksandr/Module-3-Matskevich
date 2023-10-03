namespace Solution_1_Test
{
    abstract class Shape
    {
        private double area = 0;//переменная для хранения площади
        public double Area_//get/set значения площади
        {
            get { return area; }
            set { area = value; }
        }
        public double Area()//метод для возвращения площади
        {
            return area;
        }
    }
}
